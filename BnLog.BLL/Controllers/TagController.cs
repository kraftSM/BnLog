using AutoMapper;
using Microsoft.Extensions.Logging;
using BnLog.BLL.Services.IService;
using BnLog.DAL.IRepository;
using BnLog.BLL.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using BnLog.VAL.Request.Entity;

namespace BnLog.BLL.Controllers
{
    [ApiController]
        [Route("api/[controller]")]
        //[Produces("application/json")]
    public class TagController : Controller
    {

        private readonly ITagRepository _repo;
        private readonly ITagService _tagService;
        private readonly ILogger<TagController> _logger;
        private IMapper _mapper;
        public TagController(ITagRepository repo, IMapper mapper, ITagService tagService, ILogger<TagController> logger)
        {
            _repo = repo;
            _mapper = mapper;
            _tagService = tagService;
            _logger = logger;
        }
        
        
        /// <summary>
        /// [Get] Метод, создания тега
        /// </summary>
        [Route("Tag/Create")]
        [Authorize(Roles = "Администратор, Модератор")]
        [HttpGet]
        public IActionResult CreateTag()
        {
            return View();
        }

        /// <summary>
        /// [Post] Метод, создания тега
        /// </summary>
        [Route("Tag/Create")]
        [Authorize(Roles = "Администратор, Модератор")]
        [HttpPost]
        public async Task<IActionResult> CreateTag(TagCreateRequest model)
        {
            if (ModelState.IsValid)
            {
                var tagId = _tagService.CreateTag(model);
                _logger.LogInformation($"Создан тег - {model.Name}");
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("", "Некорректные данные");
                return View(model);
            }
        }

        /// <summary>
        /// [Get] Метод просмотра тега
        /// </summary>
        [Route("Tag/Info")]
        [Authorize(Roles = "Администратор, Модератор")]
        [HttpGet, ActionName("ViewTag")]
        public async Task<IActionResult> TagInfo(Guid id)
        {
            if (id == null)
                return NotFound();
            var eTag = await _tagService.GetTag(id);
            if (eTag == null)
                return NotFound();
            return View("TagInfo",eTag);
        }
        /// <summary>
        /// [Get] Метод, редактирования тега
        /// </summary>
        [Route("Tag/Edit")]
        [Authorize(Roles = "Администратор, Модератор")]
        [HttpGet]
        public async Task<IActionResult> EditTag(Guid id)
        {
            if (id == null)
                return NotFound();
            var eTag = await _tagService.GetTag(id);
            if (eTag == null)
                return NotFound();
            return View(eTag);
        }

        /// <summary>
        /// [Post] Метод, редактирования тега
        /// </summary>
        [Route("Tag/Edit")]
        [Authorize(Roles = "Администратор, Модератор")]
        [HttpPost]
        public async Task<IActionResult> EditTag(TagEditRequest model)
        {
            if (ModelState.IsValid)
            {
                await _tagService.EditTag(model);
                _logger.LogDebug($"Изменен тег - {model.Name}");
                //return RedirectToAction("Index", "Home");
                return RedirectToAction("GetTags", "Tag");
            }
            else
            {
                ModelState.AddModelError("", "Некорректные данные");
                return View(model);
            }
        }

        /// <summary>
        /// [Get] Метод, удаления тега
        /// </summary>
        [Route("Tag/Remove")]
        [Authorize(Roles = "Администратор, Модератор")]
        [HttpGet]
        public async Task<IActionResult> RemoveTag(Guid id, bool isConfirm = true)
        {
            if (isConfirm)
                await RemoveTag(id);
            //return RedirectToAction("Index", "Home");
            return RedirectToAction("GetTags", "Tag");
        }

        /// <summary>
        /// [Post] Метод, удаления тега
        /// </summary>
        [Route("Tag/Remove")]
        [Authorize(Roles = "Администратор, Модератор")]
        [HttpPost]
        public async Task<IActionResult> RemoveTag(Guid id)
        {
            await _tagService.RemoveTag(id);
            _logger.LogDebug($"Удаленн тег - {id}");
            //return RedirectToAction("Index", "Home");
            return RedirectToAction("GetTags", "Tag");
        }

        /// <summary>
        /// [Get] Метод, получения всех тегов
        /// </summary>
        [Route("Tag/GetAll")]
        [Authorize(Roles = "Администратор, Модератор")]
        [HttpGet]
        public async Task<IActionResult> GetTags()
        {
            var tags = await _tagService.GetTags();
            return View(tags);
        }

    }
}
