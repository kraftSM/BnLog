using BnLog.DAL.Models.Items;

namespace BnLog.DAL.IRepository
{
    public interface IItemsRepository
    {
        Task<IEnumerable<Item>> GetAll();
        Task<Item> Get(Guid id);
        Task Create(Item item);
        Task Update(Item item);
        Task Delete(Item item);
        Task<IEnumerable<Item>> GetAllByItemId(Guid guidItem);
    }
}
