namespace frontend.Services
{
    using Microsoft.Identity.Web;
    using System.Security.Claims;

    public class BackendService
    {
        private readonly ILogger<BackendService> _logger;
        private IDownstreamWebApi _downstream;
        public BackendService(ILogger<BackendService> logger, IDownstreamWebApi downstream)
        {
            _logger = logger;
            _downstream = downstream;
        }

        public async Task<string?> GetAllDrivers(ClaimsPrincipal user)
        {
            var res = await _downstream.GetForUserAsync<System.Text.Json.JsonDocument>(serviceName: "backend", relativePath: "Driver/All", user: user);

            if (res == null) return "";


            return res.RootElement.ToString();
        }



        public async Task<string?> GetDrivers(ClaimsPrincipal user)
        {
            var res = await _downstream.GetForUserAsync<System.Text.Json.JsonDocument>(serviceName: "backend", relativePath: "Driver", user: user);

            if (res == null) return "";


            return res.RootElement.ToString();
        }

    }
}
