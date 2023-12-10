using AutoMapper;
using BnLog.DAL.IRepository;
using BnLog.DAL.Models.Security;
using BnLog.VAL.Services.IService;
using Microsoft.AspNetCore.Mvc;


using BnLog.VAL.Request.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using BnLog.DAL.Models.Entity;
using BnLog.VAL.Services;
using Microsoft.Extensions.Hosting;
//using Microsoft.AspNet.Identity;
//using Microsoft.AspNet.Identity;

namespace BnLog.API.Controllers
    {
    [ApiController]
    [Route("API/[controller]")]
    public class CommentController : Controller
        {
        private IMapper _mapper;
        //private ICommentRepository _commentRepo;
        private ICommentService _commentService;
        private readonly IPostService _postService;
        private readonly UserManager<User> _userManager;

        public CommentController ( IMapper mapper,  ICommentService commentService, IPostService postService, UserManager<User> userManager )//
            {
            _mapper = mapper;
            _commentService = commentService;
            _postService = postService;
            _userManager = userManager;
            }

        /// <summary>
        /// [Get] Метод, получения всех коментариев
        /// </summary>
        [Route("/[controller]/GetAll")]
        [HttpGet]
        public async Task<List<Comment>> GetComments ( )
            {
            var comments = await _commentService.GetComments();
            return comments;
            }

        /// <summary>
        /// [Get] Метод, получения тега
        /// </summary>
        [HttpGet("{id}")]
        //[Route("Tag/Get")]
        public ActionResult<CommentRequest> GetComment ( Guid id )
            {
            var existingEntity = _commentService.GetComment(id);
            if (existingEntity.Result is null)
                return NotFound();
            var entityInfo = _mapper.Map<CommentRequest>(existingEntity.Result);
            return entityInfo;
            //return NoContent();
            }

        /// <summary>
        /// [HttpPost] Метод, обновления/редактирования комментария
        /// </summary>
        [HttpPut("{id}")]
        public ActionResult<CommentRequest> EditComment ( Guid id, CommentRequest com)
            {
            if (id != com.Id)
                return BadRequest();
            var existingTag = _commentService.GetComment(id);
            if (existingTag.Result is null)
                return NotFound();
            _commentService.EditComment(com);

            //return NoContent();
            return com;
            }

        /// <summary>
        /// [HttpPost] Метод, создания комментария
        /// </summary>
        [HttpPost]
        //[Authorize]//(Roles = "Администратор")
        //[HttpPost("{postId}")]
        [Route("Create")]
        //[Authorize] //UNTIL not exists Identityfication fo API
        public ActionResult<CommentInfo> Create ( [FromBody] CommentCreateRequest newComment )
            {
            string DefTestUserName = "Test0"; //UNTIL not exists Identityfication fo API = Да это костыль :(

            var existPost = _postService.IsPostExist(newComment.PostId);
            //var existPost = _postService.GetPost(postId);
            if (! existPost.Result)
                return BadRequest();
            //newComment.PostId = existPost.Result.Id;

            //Task<User>? existUser =  _userManager.FindByNameAsync(User?.Identity?.Name);
            //if (System.String.IsNullOrEmpty(newComment.Author))
                //newComment.Author = DefTestUserName;

            Task<User>? existUser = _userManager.FindByNameAsync(DefTestUserName);
            if (existUser.Result is null)
                return BadRequest();            
                
            //newComment.Author = existUser.Result.UserName;

            var comNew = _commentService.CreateComment(newComment, new Guid(existUser.Result.Id));
            //_commentService.CreateComment(newComment, new Guid(existUser.Result.Id));
            return NoContent();
            

            }

        /// <summary>
        /// [HttpPost] Метод, удаления тега
        /// </summary>
        /// 
        [Authorize]
        [HttpDelete("{id}")]
        public IActionResult Delete ( Guid id )
            {
            if (id == null)
                return BadRequest();
            var existingTag = _commentService.GetComment(id);
            if (existingTag.Result is null)
                return NotFound();
            if (id != existingTag.Result.Id)
                return BadRequest();

            _commentService.RemoveComment(id);
            return NoContent();
            }
        }
    }
