using AutoMapper;
using BnLog.DAL.IRepository;
using BnLog.DAL.Repository.Items;
using Microsoft.AspNetCore.Identity;
using BnLog.BLL.Services.IService;
using BnLog.VAL.Services.IService;

namespace BnLog.VAL.Services
{
    public class ItemService : IItemService
    {
        //private readonly RoleManager<Role> _roleManager;
        //private readonly UserManager<User> _userManager;
        //private readonly ITagRepository _tagRepo;
        public IMapper _mapper;
        private readonly IItemsRepository _itemRepo;
        private readonly ItemResurceRepository _itemResurceRepo;
        private readonly ItemOptionRepository _itemOptionRepo;

        public ItemService(IItemsRepository itemRepo, IMapper mapper)//ItemOptionRepository itemOptionRepo,   ItemResurceRepository itemResurceRepo,
        {
            _itemRepo = itemRepo;
            ////_tagRepo = tagRepo;
            _mapper = mapper;
            //_itemOptionRepo = itemOptionRepo;
            //_itemResurceRepo = itemResurceRepo;
        }
    }
}
