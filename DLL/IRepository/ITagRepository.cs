using BnLog.DLL.Models.Entitys;

namespace BnLog.DLL.IRepository
{
    public interface ITagRepository
    {
        //HashSet<Tag> GetAllTags();
        Tag GetTag(Guid id);
        Task AddTag(Tag tag);
        Task UpdateTag(Tag tag);
        Task RemoveTag(Guid id);
        Task<bool> SaveChangesAsync();
    }
}
