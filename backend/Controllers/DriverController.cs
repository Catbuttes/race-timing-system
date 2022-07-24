namespace backend.Controllers
{

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Identity.Web.Resource;
    using backend.Models;
    using backend.Services;



    [Authorize]
    [ApiController]
    [Route("[controller]")]
    [RequiredScope("Api.Access")]
    public class DriverController : ControllerBase
    {
        private readonly ILogger<DriverController> _logger;
        private DriverService _driver;

        public DriverController(ILogger<DriverController> logger, DriverService driver)
        {
            _logger = logger;
            _driver = driver;
        }

        /// <summary>
        /// Get a list of all drivers for the logger in user
        /// </summary>
        /// <returns>A list of drivers</returns>
        /// <exception cref="NotImplementedException"></exception>
        [HttpGet]
        [Produces("application/json")]
        public async Task<IEnumerable<Driver>> Get()
        {
            var uid = GetUserObjectId();

            var drivers = await _driver.GetAllMine(uid);

            return drivers;
        }

        /// <summary>
        /// Get a list of all drivers
        /// </summary>
        /// <returns>A list of drivers</returns>
        /// <exception cref="NotImplementedException"></exception>
        [HttpGet]
        [Route("All")]
        [Produces("application/json")]
        public async Task<IEnumerable<Driver>> GetAll()
        {
            var drivers = await _driver.GetAll();

            return drivers;
        }

        /// <summary>
        /// Gets a specific driver
        /// </summary>
        /// <param name="Id">The driver ID</param>
        /// <returns>The details of a specific driver</returns>
        /// <exception cref="NotImplementedException"></exception>
        [HttpGet]
        [Route("{Id}")]
        [Produces("application/json")]
        public async Task<Driver?> Get(Guid Id)
        {
            var uid = GetUserObjectId();
            var driver = await _driver.Get(uid, Id);

            return driver;
        }

        [HttpGet]
        [Route("{Id}/Tag")]
        [Produces("application/json")]
        public async Task<IEnumerable<Tag>?> GetTags(Guid Id)
        {
            var uid = GetUserObjectId();
            var tags = await _driver.GetTags(uid, Id);

            return tags;
        }

        [HttpPut]
        [RequiredScope("Driver.Manage")]
        [Route("{DriverId}/Tag/{TagId}")]
        [Produces("application/json")]
        public async Task<IEnumerable<Tag>?> TagDriver(Guid DriverId, Guid TagId)
        {
            var uid = GetUserObjectId();
            var tags = await _driver.ApplyTag(uid, DriverId, TagId);

            return tags;
        }

        [HttpDelete]
        [RequiredScope("Driver.Manage")]
        [Route("{DriverId}/Tag/{TagId}")]
        [Produces("application/json")]
        public async Task<IEnumerable<Tag>?> DeTagDriver(Guid DriverId, Guid TagId)
        {
            var uid = GetUserObjectId();
            var tags = await _driver.RemoveTag(uid, DriverId, TagId);

            return tags;
        }

        [HttpPut]
        [RequiredScope("Driver.Manage")]
        [Produces("application/json")]
        public async Task<Driver?> Create([FromBody] Driver driver)
        {
            var uid = GetUserObjectId();
            //TODO: Replace this with the logged in user ID
            driver.User = uid;

            var newDriver = await _driver.Create(uid, driver);

            return newDriver;
        }

        [HttpPatch]
        [RequiredScope("Driver.Manage")]
        [Route("{Id}")]
        [Produces("application/json")]
        public async Task<Driver?> Update([FromBody] Driver driver)
        {
            var uid = GetUserObjectId();
            var newDriver = await _driver.Update(uid, driver);

            return newDriver;
        }

        [HttpDelete]
        [RequiredScope("Driver.Manage")]
        [Route("{Id}")]
        [Produces("application/json")]
        public async Task<Boolean> Delete(Guid Id)
        {
            var uid = GetUserObjectId();
            return await _driver.Delete(uid, Id);
        }

        private Guid GetUserObjectId()
        {
            var uid = User.Claims
                .Where(c => c.Type == "http://schemas.microsoft.com/identity/claims/objectidentifier")
                .First();

            return new Guid(uid.Value);
        }
    }

}