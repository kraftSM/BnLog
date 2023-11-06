using BnLog.DAL.Models.Items;
using BnLog.DAL.Models.Entity;

namespace BnLog.DAL.IRepository
{
    public interface IItemsRepository
    {
        //HashSet<Item> GetAllItems();
        Item GetItem(Guid id);
        List<Item> GetAllItems();
        List<Item> GetAllItemsOfTypes(int ItemType);
        //Task AddItem(Item item);
        //Task UpdateItem(Item item);
        //Task RemoveItem(Guid id);
        Task<bool> SaveChangesAsync();
    }
}
