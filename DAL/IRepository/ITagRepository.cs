using BnLog.DAL.IRepository;
using BnLog.DAL.Models.Entity;
using BnLog.DAL.Repository;

namespace BnLog.DAL.IRepository
{
 
   public interface ITagRepository 
  //public interface ITagRepository : IRepository<Tag>
    {
        HashSet<Tag> GetAllTags();
        Tag GetTag(Guid id);
        Task AddTag(Tag tag);
        Task UpdateTag(Tag tag);
        Task RemoveTag(Guid id);
        Task<bool> SaveChangesAsync();
    }
}
