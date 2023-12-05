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


namespace BnLog.API.Controllers
    {
    [ApiController]
    [Route("API/[controller]")]
    public class PostController : Controller
        {
        private readonly IPostRepository _postRepo;
        private readonly IPostService _postService;
        private readonly ITagRepository _tagRepo;
        private readonly UserManager<User> _userManager;
        private IMapper _mapper;

        public PostController ( ITagRepository tagRepository, IPostRepository repo, IMapper mapper, IPostService postService, UserManager<User> userManager )
            {
            _tagRepo = tagRepository;
            _postRepo = repo;
            _mapper = mapper;
            _postService = postService;
            _userManager = userManager;
            }
        /// <summary>
        /// [Get] Метод, получения всех постов
        /// </summary>
        [HttpGet]
        [Route("Post/Get")]
        public async Task<List<PostInfo>> GetPosts ( )
            {
            
            //var PostInfo = _mapper.Map<PostInfo>(Pos);
            var posts = await _postService.GetPosts();
            //Создание конфигурации сопоставления
           var config = new MapperConfiguration(cfg => cfg.CreateMap<Post, PostInfo>());
            //Настройка AutoMapper
        var mapper = new Mapper(config);
            //сопоставление
           var postsInfo = mapper.Map<List<PostInfo>>(posts);



            //var postsInfo = _mapper.Map<PostInfo>(posts);
            return postsInfo;
            }

        }
    }
