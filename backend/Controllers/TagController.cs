namespace backend.Controllers
{

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using backend.Models;
    using backend.Services;



    //[Authorize]
    [ApiController]
    [Route("[controller]")]
    public class TagController : ControllerBase
    {
        private readonly ILogger<TagController> _logger;


        public TagController(ILogger<TagController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Get a list of all configured tags
        /// </summary>
        /// <returns>A list of tags</returns>
        /// <exception cref="NotImplementedException"></exception>
        [HttpGet]
        [Produces("application/json")]
        public async Task<IEnumerable<Driver>> Get()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets a specific tag configuration
        /// </summary>
        /// <param name="Id">The tag ID</param>
        /// <returns>The details of a specific tag</returns>
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