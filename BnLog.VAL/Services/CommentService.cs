using AutoMapper;
using BnLog.BLL.Services.IService;
using BnLog.DAL.IRepository;
using BnLog.DAL.Models.Entity;
using BnLog.DAL.Models.Security;
using BnLog.VAL.Request.Entity;
using Microsoft.AspNetCore.Identity;
using System;

namespace BnLog.BLL.Services
{
    public class CommentService : ICommentService
    {
        public IMapper _mapper;
        private ICommentRepository _commentRepo;
        private UserManager<User> _userManager;

        public CommentService(IMapper mapper, ICommentRepository commentRepo, UserManager<User> userManager)
        {
            _mapper = mapper;
            _commentRepo = commentRepo;
            _userManager = userManager;
        }

        public async Task<Guid> CreateComment(CommentRequest model, Guid UserId)
        {
            Comment comment = new Comment
            {
                Title = model.Title,
                Body = model.Body,
                Author = model.Author,
                PostId = model.PostId,
                AuthorId = UserId,
                //realAuthorName = _userManager.FindByIdAsync(UserId.ToString()).Result.UserName,
            };

            await _commentRepo.AddComment(comment);
            return comment.Id;
        }

        public async Task EditComment( CommentRequest model )
        {
            var comment = _commentRepo.GetComment(model.Id);

            comment.Title = model.Title;
            comment.Body = model.Body;
            comment.Author = model.Author;

            await _commentRepo.UpdateComment(comment);
        }
        public async Task<Comment> GetComment(Guid Id)
        {
            var comment = _commentRepo.GetComment(Id);
            return comment;
        }
        public async Task RemoveComment(Guid id)
        {
            await _commentRepo.RemoveComment(id);
        }

        public async Task<List<Comment>> GetComments()
        {
            return _commentRepo.GetAllComments().ToList();
        }
    }
}
