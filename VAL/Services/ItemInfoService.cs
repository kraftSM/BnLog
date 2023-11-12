using AutoMapper;
using BnLog.DAL.IRepository;
using BnLog.DAL.Models.Entity;
using BnLog.DAL.Models.Info;
using BnLog.VAL.Services.IService;

namespace BnLog.VAL.Services
{
    public class ItemInfoService : IItemInfoService
    {
        private readonly IItemInfoRepository _itemRepo;
        private IMapper _mapper;

        public ItemInfoService(IItemInfoRepository repo, IMapper mapper)
        {
            _itemRepo = repo;
            _mapper = mapper;
        }

        public async Task<Guid> CreateItemInfo(ItemInfo model)
        {
            //var tag = _mapper.Map<Tag>(model);
            await _itemRepo.AddItem(model);

            return model.Id;
        }
        public async Task<List<ItemInfo>> GetAllItemInfo()
        {
            return _itemRepo.GetAllItems().ToList();
        }
    }
}
