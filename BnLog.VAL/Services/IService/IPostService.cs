using BnLog.DAL.Models.Entity;
using BnLog.VAL.Request.Entity;

namespace BnLog.VAL.Services.IService
{
    public interface IPostService
  {
        Task<PostCreateRequest> CreatePost();
    Task<Guid> CreatePost(PostCreateRequest model);
    Task<PostEditRequest> EditPost(Guid Id);
    Task EditPost(PostEditRequest model, Guid Id);
    Task RemovePost(Guid id);
    Task<List<Post>> GetPosts();
    Task<Post> GetPost(Guid id);
}
}
