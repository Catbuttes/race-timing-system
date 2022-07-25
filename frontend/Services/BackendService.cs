namespace frontend.Services
{
    using Microsoft.Identity.Web;
    using System.Security.Claims;

    using backend.Models;

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
            var res = await _downstream.GetForUserAsync<IEnumerable<Driver>>(
                serviceName: "backend", 
                relativePath: "Driver/All", 
                user: user);

            if (res == null) return "";

            var dbytes = System.Text.Json.JsonSerializer.SerializeToUtf8Bytes(res);
            var dstring = System.Text.Encoding.UTF8.GetString(dbytes);

            return dstring;
        }



        public async Task<string?> GetDrivers(ClaimsPrincipal user)
        {
            var res = await _downstream.GetForUserAsync<Driver>(
                serviceName: "backend", 
                relativePath: "Driver", 
                user: user);

            if (res == null) return "";

            var dbytes = System.Text.Json.JsonSerializer.SerializeToUtf8Bytes(res);
            var dstring = System.Text.Encoding.UTF8.GetString(dbytes);

            return dstring;
        }

    }
}
