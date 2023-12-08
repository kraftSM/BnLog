using BnLog.DAL.Models.Entity;
using BnLog.DAL.Models.Security;
using BnLog.VAL.Request.Entity;

namespace BnLog.VAL.Services.IService
    {
    public interface ICommentService
    {
        Task<Comment> CreateComment(CommentCreateRequest model, Guid UserId );
        Task EditComment( CommentRequest model );
        Task RemoveComment(Guid id);
        Task<List<Comment>> GetComments();
        Task<Comment> GetComment(Guid id);
    }
}
