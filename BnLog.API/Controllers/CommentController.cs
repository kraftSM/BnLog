using AutoMapper;
using BnLog.DAL.IRepository;
using BnLog.DAL.Models.Security;
using BnLog.VAL.Services.IService;
using Microsoft.AspNetCore.Mvc;


using BnLog.VAL.Request.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace BnLog.API.Controllers
    {
    public class CommentController : Controller
        {
        private IMapper _mapper;
        private ICommentRepository _commentRepo;
        private ICommentService _commentService;
        private readonly UserManager<User> _userManager;

        public CommentController ( IMapper mapper, ICommentRepository commentRepo, ICommentService commentService, UserManager<User> userManager )
            {
            _mapper = mapper;
            _commentRepo = commentRepo;
            _commentService = commentService;
            _userManager = userManager;
            }

        //public IActionResult Index ( )
        //    {
        //    return View();
        //    }
        }
    }
