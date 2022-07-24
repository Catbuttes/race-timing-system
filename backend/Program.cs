using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.HttpOverrides;

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
    .AddDbContextCheck<RTSContext>();

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

// builder.Services.AddDbContext<RTSContext>(options =>
// {
//     options.UseSqlite(builder.Configuration.GetConnectionString("RtsDb"));
// });

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


// using (var scope = app.Services.CreateScope())
// {
//     var db = scope.ServiceProvider.GetRequiredService<RTSContext>();
//     db.Database.Migrate();
// }



app.Use((context, next) =>
{
    context.Request.Scheme = "https";
    return next(context);
});

// Configure the HTTP request pipeline.
// if (app.Environment.IsDevelopment())
// {
app.UseSwagger();
app.UseSwaggerUI();
//}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.MapHealthChecks("/healthz");
app.MapMetrics();


app.Run();
