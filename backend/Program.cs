using System.Text;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.Identity.Web;
using Prometheus;
using backend.Database;
using backend.Services;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddMicrosoftIdentityWebApi(builder.Configuration.GetSection("AzureAdB2C"));

builder.Services.Configure<ForwardedHeadersOptions>(options =>
{
    options.ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto;
});

builder.Services.AddControllers();

builder.Services.AddHealthChecks()
    .AddCosmosDb(
        connectionString: builder.Configuration.GetConnectionString("RtsDb"),
        database: "rts-data",
        name: "RTS Database"
    )
    .AddCosmosDbCollection(
        connectionString: builder.Configuration.GetConnectionString("RtsDb"),
        database: "rts-data",
        collections: new List<String> { "RTSContext" },
        name: "RTS Database Collection"
    );

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(setupAction: options =>
{
    OpenApiSecurityScheme securityDefinition = new OpenApiSecurityScheme()
    {
        BearerFormat = "JWT",
        Scheme = "bearer",
        Description = "Specify the authorization token.",
        Type = SecuritySchemeType.Http,
    };

    options.AddSecurityDefinition("Bearer", securityDefinition);

    OpenApiSecurityRequirement securityRequirements = new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "Bearer" }
            },
            new string[] {}
        }
    };

    options.AddSecurityRequirement(securityRequirements);
});

builder.Services.AddDbContext<RTSContext>(options =>
{
    options.UseCosmos(
        connectionString: builder.Configuration.GetConnectionString("RtsDb"),
        databaseName: "rts-data"
    );
});

builder.Services.AddScoped<DriverService>();


var app = builder.Build();


app.UseHttpMetrics();
app.UseHttpLogging();

app.Use((context, next) =>
{
    context.Request.Scheme = "https";
    return next(context);
});

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.MapHealthChecks("/healthz", new Microsoft.AspNetCore.Diagnostics.HealthChecks.HealthCheckOptions
{
    ResponseWriter = (HttpContext context, HealthReport healthReport) =>
    {
        context.Response.ContentType = "text/plain; charset=utf-8";

        var statusResponse = new System.Text.StringBuilder();
        var timeResponse = new System.Text.StringBuilder();
        statusResponse.AppendFormat("# HELP healthcheck Shows raw health check status (0 = Unhealthy, 1 = Degraded, 2 = Healthy)\n# TYPE healthcheck gauge\n");
        timeResponse.AppendFormat("# HELP healthcheck_duration_seconds Shows duration of the health check execution in seconds\n# TYPE healthcheck_duration_seconds gauge\n");

        foreach (var healthReportEntry in healthReport.Entries)
        {
            switch (healthReportEntry.Value.Status.ToString())
            {
                case "Healthy":
                    statusResponse.AppendFormat("healthcheck{{healthcheck=\"{0}\"}} 2\n", healthReportEntry.Key);
                    break;
                case "Degraded":
                    statusResponse.AppendFormat("healthcheck{{healthcheck=\"{0}\"}} 1\n", healthReportEntry.Key);
                    break;
                default:
                    statusResponse.AppendFormat("healthcheck{{healthcheck=\"{0}\"}} 0\n", healthReportEntry.Key);
                    break;
            }

            timeResponse.AppendFormat("healthcheck_duration_seconds{{healthcheck=\"{0}\"}} {1}\n", healthReportEntry.Key, healthReportEntry.Value.Duration.TotalSeconds);
        }

        var response = statusResponse.ToString() + timeResponse.ToString();

        return context.Response.BodyWriter.WriteAsync(Encoding.UTF8.GetBytes(response.ToString())).AsTask();
    }
});

app.MapMetrics();


app.Run();
