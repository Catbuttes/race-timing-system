using System.Text;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.Identity.Web;
using Microsoft.Identity.Web.UI;
using frontend.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddAuthentication(OpenIdConnectDefaults.AuthenticationScheme)
    .AddMicrosoftIdentityWebApp(builder.Configuration.GetSection("AzureAdB2C"))
    .EnableTokenAcquisitionToCallDownstreamApi()
    .AddDownstreamWebApi("backend", builder.Configuration.GetSection("BackendConfig"))
    .AddInMemoryTokenCaches();

builder.Services.Configure<ForwardedHeadersOptions>(options =>
            {
                options.ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto;
            });


builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages()
    .AddMicrosoftIdentityUI();

builder.Services.AddTransient<BackendService>();

builder.Services.AddHealthChecks()
    .AddUrlGroup(
        uri: new Uri(builder.Configuration.GetValue<String>("BackendConfig:BaseUrl") + "/healthz"),
        name: "Backend API Status"
    );

var app = builder.Build();

app.Use((context, next) =>
            {
                context.Request.Scheme = "https";
                return next(context);
            });

app.UseForwardedHeaders();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

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

app.Run();
