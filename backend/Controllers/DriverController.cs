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
        private DriverService _db;

        public DriverController(ILogger<DriverController> logger, DriverService db)
        {
            _logger = logger;
            _db = db;
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
            var drivers = await _db.GetDrivers();

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
            var driver = await _db.GetDriver(Id);

            return driver;
        }

        [HttpPut]
        [Produces("application/json")]
        public async Task<Driver> Create([FromBody] Driver driver)
        {
            throw new NotImplementedException();
        }

        [HttpPatch]
        [Route("{Id}")]
        [Produces("application/json")]
        public async Task<Driver> Update([FromBody] Driver driver)
        {
            throw new NotImplementedException();
        }

        [HttpDelete]
        [Route("{Id}")]
        [Produces("application/json")]
        public async Task<string> Delete()
        {
            throw new NotImplementedException();
        }
    }

}