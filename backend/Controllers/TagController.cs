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
    public class TagController : ControllerBase
    {
        private readonly ILogger<TagController> _logger;


        public TagController(ILogger<TagController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("Category")]
        [Produces("application/json")]
        public async Task<IEnumerable<TagCategory>> GetCategories()
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        [Route("Category/{Id}")]
        [Produces("application/json")]
        public async Task<TagCategory?> GetCategory(Guid Id)
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        [Route("Category/{Id}/Definition")]
        [Produces("application/json")]
        public async Task<IEnumerable<TagDefinition>> GetDefinitions(Guid Id)
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        [Route("Category/{categoryId}/Definition/{Id}")]
        [Produces("application/json")]
        public async Task<TagDefinition?> GetDefinition(Guid categoryId, Guid Id)
        {
            throw new NotImplementedException();
        }

        [HttpPut]
        [RequiredScope("Tag.Manage")]
        [Route("Category")]
        [Produces("application/json")]
        public async Task<TagCategory> CreateCategory([FromBody] TagCategory tagCategory)
        {
            throw new NotImplementedException();
        }

        [HttpPatch]
        [RequiredScope("Tag.Manage")]
        [Route("Category/{Id}")]
        [Produces("application/json")]
        public async Task<TagCategory> UpdateCategory([FromBody] Tag Tag)
        {
            throw new NotImplementedException();
        }

        [HttpDelete]
        [RequiredScope("Tag.Manage")]
        [Route("Category/{Id}")]
        [Produces("application/json")]
        public async Task<string> DeleteCategory()
        {
            throw new NotImplementedException();
        }

        [HttpPut]
        [RequiredScope("Tag.Manage")]
        [Route("Category/{Id}/Definition")]
        [Produces("application/json")]
        public async Task<TagDefinition> CreateDefinition([FromBody] TagDefinition tagDefinition)
        {
            throw new NotImplementedException();
        }

        [HttpPatch]
        [RequiredScope("Tag.Manage")]
        [Route("Category/{categoryId}/Definition/{Id}")]
        [Produces("application/json")]
        public async Task<TagDefinition> UpdateDefinition([FromBody] TagDefinition Tag)
        {
            throw new NotImplementedException();
        }

        [HttpDelete]
        [RequiredScope("Tag.Manage")]
        [Route("Category/{categoryId}/Definition/{Id}")]
        [Produces("application/json")]
        public async Task<string> DeleteDefinition()
        {
            throw new NotImplementedException();
        }
    }

}