using AutoMapper;
using BnLog.DAL.IRepository;
using BnLog.DAL.Models.Entity;
using BnLog.DAL.Models.Info;
using BnLog.VAL.Request.Entity;

namespace BnLog.VAL.Services.IService
{
    public interface IItemInfoService
    {
        Task<Guid> CreateItemInfo(ItemInfo model);
        Task<List<ItemInfo>> GetAllItemInfo();
    }
}
