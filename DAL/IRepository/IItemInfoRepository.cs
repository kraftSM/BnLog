using System.Collections.Generic;
using BnLog.DAL.Repository;
using BnLog.DAL.Models.Info;

namespace BnLog.DAL.IRepository
{
    public interface IItemInfoRepository
    //public interface IItemRepository : IRepository<Item>
    {
        //HashSet<Item> GetAllItems();
        //Item GetItem(Guid id);
        List<ItemInfo> GetAllItems();
        //List<ItemInfo> GetAllItemsOfTypes(int ItemType);
        Task AddItem(ItemInfo item);
        //Task UpdateItem(Item item);
        //Task RemoveItem(Guid id);
        Task<bool> SaveChangesAsync();
    }
}
