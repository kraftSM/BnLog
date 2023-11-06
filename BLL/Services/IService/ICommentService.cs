using BnLog.DAL.Models.Entity;
using BnLog.DAL.Request.Entity;

namespace BnLog.BLL.Services.IService
{
    public interface ICommentService
    {
        Task<Guid> CreateComment(CommentCreateRequest model, Guid UserId);
        Task EditComment(CommentEditRequest model);
        Task RemoveComment(Guid id);
        Task<List<Comment>> GetComments();
    }
}
