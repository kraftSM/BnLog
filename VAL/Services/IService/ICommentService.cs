using BnLog.DAL.Models.Entity;
using BnLog.VAL.Request.Entity;

namespace BnLog.VAL.Services.IService
{
    public interface ICommentService
    {
        Task<Guid> CreateComment(CommentCreateRequest model, Guid UserId);
        Task EditComment(CommentEditRequest model);
        Task RemoveComment(Guid id);
        Task<List<Comment>> GetComments();
        Task<Comment> GetComment(Guid id);
    }
}
