using AutoMapper;
using BnLog.DAL.IRepository;
using BnLog.DAL.Models.Security;
using BnLog.VAL.Request.Entity;
using BnLog.VAL.Services.IService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using BnLog.VAL.Request.Entity;
using BnLog.DAL.Models.Entity;
using BnLog.VAL.Services;


namespace BnLog.API.Controllers
    {
    [ApiController]
    [Route("API/[controller]")]
    public class PostController : Controller
        {
        //private readonly IPostRepository _postRepo;
        private readonly IPostService _postService;
        //private readonly ITagRepository _tagRepo;
        private readonly UserManager<User> _userManager;
        private IMapper _mapper;

        public PostController ( IMapper mapper, IPostService postService, UserManager<User> userManager )//ITagRepository tagRepository, 
            {
            //_tagRepo = tagRepository;
            _mapper = mapper;
            _postService = postService;
            _userManager = userManager;
            }
        /// <summary>
        /// [Get] Метод, получения всех постов
        /// </summary>
        [HttpGet]
        [Route("[controller]/Get")]
        public async Task<List<PostInfo>> GetPosts ( )
        {

            //    //var PostInfo = _mapper.Map<PostInfo>(Pos);
            var posts = await _postService.GetPosts();
            //    //Создание конфигурации сопоставления
            //   var config = new MapperConfiguration(cfg => cfg.CreateMap<Post, PostInfo>());
            //    //Настройка AutoMapper
            //var mapper = new Mapper(config);
            //    //сопоставление
            //   var postsInfo = mapper.Map<List<PostInfo>>(posts);



            //    //сопоставление by Map<List<Post, PostInfo>>;
            var postsInfo = _mapper.Map<List<PostInfo>>(posts);
            return postsInfo;
        }
        /// <summary>
        /// [Get] Метод, получения поста по его ID
        /// </summary>
        [HttpGet("{id}")]
        public ActionResult<PostInfo> GetPost ( Guid id )
        {
            var existingPost = _postService.GetPost(id);
            if (existingPost.Result is null)
                return NotFound();

            var postInfo = _mapper.Map<PostInfo>(existingPost.Result);
            return postInfo;
            //return NoContent();
            }

        }
    }
