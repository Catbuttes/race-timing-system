namespace backend.Controllers
{

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using backend.Models;
    using backend.Services;



    //[Authorize]
    [ApiController]
    [Route("[controller]")]
    public class LapController : ControllerBase
    {
        private readonly ILogger<LapController> _logger;

        public LapController(ILogger<LapController> logger)
        {
            _logger = logger;

        }

        /// <summary>
        /// Get a list of all laps for the logger in user
        /// </summary>
        /// <returns>A list of laps</returns>
        /// <exception cref="NotImplementedException"></exception>
        [HttpGet]
        [Produces("application/json")]
        public async Task<IEnumerable<Driver>> Get()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets a specific lap
        /// </summary>
        /// <param name="Id">The lap ID</param>
        /// <returns>The details of a specific lap</returns>
        /// <exception cref="NotImplementedException"></exception>
        [HttpGet]
        [Route("{Id}")]
        [Produces("application/json")]
        public async Task<Driver?> Get(long Id)
        {
            throw new NotImplementedException();
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