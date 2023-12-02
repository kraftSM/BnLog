using BnLog.DAL.Models.Entity;
using BnLog.DAL.Models.Items;

namespace BnLog.DAL.IRepository
{
    public interface IItemOptionRepository
    {
        Task<IEnumerable<ItemOption>> GetAll();
        Task<ItemOption> Get(Guid id);
        Task Create(ItemOption item);
        Task Update(ItemOption item);
        Task Delete(ItemOption item);
        Task<IEnumerable<ItemOption>> GetAllByItemId(Guid guidItem);
    }
}
