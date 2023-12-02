using BnLog.DAL.Models.Items;

namespace BnLog.DAL.IRepository
{
    public interface IItemResurceRepository
    {
        Task<IEnumerable<ItemResurce>> GetAll();
        Task<ItemResurce> Get(Guid id);
        Task Create(ItemResurce item);
        Task Update(ItemResurce item);
        Task Delete(ItemResurce item);
        Task<IEnumerable<ItemResurce>> GetAllByItemId(Guid guidItem);
    }
}
