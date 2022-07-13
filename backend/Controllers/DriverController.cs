namespace backend.Controllers
{

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using backend.Models;
    using backend.Services;



    //[Authorize]
    [ApiController]
    [Route("[controller]")]
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
            var driver = await _driver.Get(Id);

            return driver;
        }

        [HttpGet]
        [Route("{Id}/Tag")]
        [Produces("application/json")]
        public async Task<IEnumerable<Tag>?> GetTags(Guid Id)
        {
            var tags = await _driver.GetTags(Id);

            return tags;
        }

        [HttpPut]
        [Route("{DriverId}/Tag/{TagId}")]
        [Produces("application/json")]
        public async Task<IEnumerable<Tag>?> TagDriver(Guid DriverId, Guid TagId)
        {
            var tags = await _driver.ApplyTag(DriverId, TagId);

            return tags;
        }

        [HttpDelete]
        [Route("{DriverId}/Tag/{TagId}")]
        [Produces("application/json")]
        public async Task<IEnumerable<Tag>?> DeTagDriver(Guid DriverId, Guid TagId)
        {
            var tags = await _driver.RemoveTag(DriverId, TagId);

            return tags;
        }

        [HttpPut]
        [Produces("application/json")]
        public async Task<Driver?> Create([FromBody] Driver driver)
        {
            //TODO: Replace this with the logged in user ID
            driver.User = Guid.NewGuid();

            var newDriver = await _driver.Create(driver);

            return newDriver;
        }

        [HttpPatch]
        [Route("{Id}")]
        [Produces("application/json")]
        public async Task<Driver?> Update([FromBody] Driver driver)
        {
            var newDriver = await _driver.Update(driver);

            return newDriver;
        }

        [HttpDelete]
        [Route("{Id}")]
        [Produces("application/json")]
        public async Task<Boolean> Delete(Guid Id)
        {
            return await _driver.Delete(Id);
        }
    }

}