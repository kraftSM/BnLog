using BnLog.DAL.Models.Entity;
using BnLog.VAL.Request.Entity;

namespace BnLog.BLL.Services.IService
{
    public interface ITagService
    {    
        Task<Guid> CreateTag(TagCreateRequest model);
        Task EditTag(Guid id);
        Task EditTag(TagEditRequest model);
        Task RemoveTag(Guid id);
        Task<Tag> GetTag(Guid id);
        Task<List<Tag>> GetTags();
    }
}
