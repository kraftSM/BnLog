using BnLog.DAL.Models.Entity;
using BnLog.DAL.Models.Items;
using BnLog.VAL.Response.Items;

namespace BnLog.VAL.Services.IService
{
    public interface IItemService
    {
        ItemInfo GetItemInfo(string id);
        Task<IEnumerable<ItemInfo>> GetAsync();
    }
}
