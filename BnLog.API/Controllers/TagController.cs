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

        private readonly ITagRepository _repo;
        private readonly ITagService _tagService;
        private readonly ILogger<TagController> _logger;
        private IMapper _mapper;
        public TagController ( ITagRepository repo, IMapper mapper, ITagService tagService, ILogger<TagController> logger )
            {
            _repo = repo;
            _mapper = mapper;
            _tagService = tagService;
            _logger = logger;
            }
        /// <summary>
        /// [Get] Метод, получения всех тегов
        /// </summary>

        [Route("Tag/GetAll")]
        [HttpGet]
        public async Task<List<Tag>> GetTags ( )
            {
            //var tag = await _tagService.GetTags();

            //var resp = new TagInfo
            //    {
            //    Name = tag.n,
            //    TegView = _mapper.Map<Tag[ ], TagInfo[ ]>(tag)
            //    };

            //return StatusCode(200, resp);


            var tags = await _tagService.GetTags();
            return tags;
            }

        }
    }
