using BnLog.DAL.Models.Items;
using BnLog.DAL.Models.Entity;

namespace BnLog.DAL.IRepository
{
    public interface IItemsRepository0
    {
        //HashSet<Item> GetAllItems();
        Item GetItem(Guid id);
        List<Item> GetAllItems();
        public Task AddItem(Item? item);
        List<Item> GetAllItemsOfTypes( itType ItemType );
        //Task AddItem(Item item);
        //Task UpdateItem(Item item);
        //Task RemoveItem(Guid id);
        Task<bool> SaveChangesAsync();
    }
}
