using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Microsoft.Extensions.Logging;
using BnLog.VAL.Services.IService;
using BnLog.DAL.IRepository;
using BnLog.VAL.Services;
using BnLog.VAL.Request.Entity;
using BnLog.DAL.Models.Entity;



namespace BnLog.API.Controllers
{
    [ApiController]
    [Route("API/[controller]")]
    //[Produces("application/json")]
    public class TagController : Controller
    {

        //private readonly ITagRepository _repo;
        private readonly ITagService _tagService;
        private readonly ILogger<TagController> _logger;
        private IMapper _mapper;
        public TagController ( IMapper mapper, ITagService tagService, ILogger<TagController> logger )//ITagRepository repo, 
            {
            //_repo = repo;
            _mapper = mapper;
            _tagService = tagService;
            _logger = logger;
            }
        
        /// <summary>
        /// [Get] Метод, получения всех тегов
        /// </summary>
        [Route("GetAll")]
        [HttpGet]
        public async Task<List<Tag>> GetAll ( )
            {
            var tags = await _tagService.GetTags();
            return tags;
            }

        /// <summary>
        /// [Get] Метод, получения тега
        /// </summary>
        [HttpGet("{id}")]
        //[Route("GetTag")]
        public ActionResult<TagEditRequest> GetTag ( Guid id )
            {
            var existingTag = _tagService.GetTag(id);
            if(existingTag.Result is null)
                return NotFound();
            var tagInfo = _mapper.Map<TagEditRequest>(existingTag.Result);
            return tagInfo;
            //return NoContent();
            }

        /// <summary>
        /// [HttpPost] Метод, обновления/редактирования тега
        /// </summary>
        //[Route("EditTag")]
        [HttpPost("{id}")]
        public ActionResult<TagEditRequest> EditTag ( Guid id, [FromBody] TagEditRequest tag )
            {
            if (id != tag.Id)
                return BadRequest();
            var existingTag = _tagService.GetTag(id);
            if (existingTag.Result is null)
                return NotFound();
            _tagService.EditTag(tag);

            //return NoContent();
            return tag;
            }

        /// <summary>
        /// [HttpPost] Метод, создания тегов
        /// </summary>
        //[Route("Create")]
        [HttpPost]
        public IActionResult Create ( TagCreateRequest tag )
            {
            _tagService.CreateTag(tag);
            return CreatedAtAction(nameof(GetTag), new { id = tag.Name }, tag);
            }

        /// <summary>
        /// [HttpPost] Метод, удаления тега
        /// </summary>
        //[Route("Delete")]
        [HttpDelete("{id}")]
        public IActionResult Delete ( Guid id )
            {
            if (id == null)
                return BadRequest();
            var existingTag = _tagService.GetTag(id);
            if (existingTag.Result is null)
                return NotFound();
            if (id != existingTag.Result.Id)
                return BadRequest();

            _tagService.RemoveTag(id);
            return NoContent();
            }
    }
}   
