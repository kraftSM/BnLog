using AutoMapper;
using BnLog.VAL.Services;
using BnLog.VAL.Services.IService;
using BnLog.DAL.IRepository;
using BnLog.DAL.Models.Security;
using BnLog.VAL.Request.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BnLog.BLL.Controllers
{
    public class CommentController : Controller
    {       
        private IMapper _mapper;
        private ICommentRepository _commentRepo;
        private ICommentService _commentService;
        private readonly UserManager<User> _userManager;

        public CommentController(IMapper mapper, ICommentRepository commentRepo, ICommentService commentService, UserManager<User> userManager)
        {
            _mapper = mapper;
            _commentRepo = commentRepo;
            _commentService = commentService;
            _userManager = userManager;
        }

        // <summary>
        /// [Get] Метод, добавление комментария
        /// </summary>
        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpGet]
        [Route("Comment/CreateComment")]
        public IActionResult CreateComment(Guid postId)
        {
            var model = new CommentCreateRequest() { PostId = postId };
            return View(model);
        }

        // <summary>
        /// [Post] Метод, добавление комментария
        /// </summary>
        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpPost]
        [Route("Comment/CreateComment")]
        public async Task<IActionResult> CreateComment( CommentCreateRequest comment, Guid PostId)
        {
            comment.PostId = PostId;
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            comment.Author = user.FirstName;                   
            
            var post = _commentService.CreateComment(comment, new Guid(user.Id));
            return RedirectToAction("GetPosts", "Post");
            }

        /// <summary>
        /// [Get] Метод, редактирования коментария
        /// </summary>
        [ApiExplorerSettings(IgnoreApi = true)]
        [Route("Comment/Edit")]
        [HttpGet]
        public async Task<IActionResult> EditComment(Guid id)
        {
            if (id == null)
                return NotFound();
            var comm = await _commentService.GetComment(id);
            if (comm == null)
                return NotFound();

            var model = new CommentRequest { Id = id };
            model.Title = comm.Title;
            //model.Author = comm.Author;
            model.Body =  comm.Body;
            model.PostId = comm.PostId;

            return View(model);
        }

        /// <summary>
        /// [Post] Метод, редактирования коментария
        /// </summary>
        [ApiExplorerSettings(IgnoreApi = true)]
        [Authorize]
        [Route("Comment/Edit")]
        [HttpPost]
        public async Task<IActionResult> EditComment(CommentRequest model)
        {
            if (ModelState.IsValid)
            {
                await _commentService.EditComment(model);
                //var returnAdr = "/Post/Show?id=" + model.PostId.ToString();
                //return Redirect(returnAdr);
                return RedirectToAction("GetPosts", "Post");
            }
            else
            {
                ModelState.AddModelError("", "Некорректные данные");
                return View(model);
            }
        }

        /// <summary>
        /// [Get] Метод, удаления коментария
        /// </summary>
        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpGet]
        [Route("Comment/Remove")]
        public async Task<IActionResult> RemoveComment(Guid id, bool confirm = true)
        {
            if (confirm)
                await RemoveComment(id);
            return RedirectToAction("GetPosts", "Post");
            }

        /// <summary>
        /// [Delete] Метод, удаления коментария
        /// </summary>
        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpDelete]
        [Route("Comment/Remove")]
        public async Task<IActionResult> RemoveComment(Guid id)
        {
            await _commentService.RemoveComment(id);
            return RedirectToAction("GetPosts", "Post");
            }
    }
}

