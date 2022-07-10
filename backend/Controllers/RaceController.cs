namespace backend.Controllers
{

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using backend.Models;
    using backend.Services;



    //[Authorize]
    [ApiController]
    [Route("[controller]")]
    public class RaceController : ControllerBase
    {
        private readonly ILogger<RaceController> _logger;

        public RaceController(ILogger<RaceController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Get a list of all race for the logger in user
        /// </summary>
        /// <returns>A list of race</returns>
        /// <exception cref="NotImplementedException"></exception>
        [HttpGet]
        [Produces("application/json")]
        public async Task<IEnumerable<Driver>> Get()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets a specific race
        /// </summary>
        /// <param name="Id">The race ID</param>
        /// <returns>The details of a specific race</returns>
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