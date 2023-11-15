using AutoMapper;
using BnLog.DAL.IRepository;
using BnLog.DAL.Models.Items;
using Microsoft.AspNetCore.Identity;
using BnLog.BLL.Services.IService;
using BnLog.VAL.Services.IService;
using BnLog.VAL.Response.Items;
using System.Net.Http;
using System.Net;
using System.Collections.Generic;

namespace BnLog.VAL.Services
{
    public class ItemService : IItemService
    {
        //private readonly RoleManager<Role> _roleManager;
        //private readonly UserManager<User> _userManager;
        //private readonly ITagRepository _tagRepo;
        public IMapper _mapper;
        private readonly IItemsRepository _itemRepo;
        private readonly IItemResurceRepository _itemResurceRepo;
        private readonly IItemOptionRepository _itemOptionRepo;

        public ItemService(IItemOptionRepository itemOptionRepo,   IItemResurceRepository itemResurceRepo,IItemsRepository itemRepo, IMapper mapper)////IItemsRepository0 itemRepo,
        {
            _itemRepo = itemRepo;
            ////_tagRepo = tagRepo;
            _mapper = mapper;
            _itemOptionRepo = itemOptionRepo;
            _itemResurceRepo = itemResurceRepo;
        }

        public ItemInfo GetItemInfo(string id)
        {
            var itemInfoMain = new ItemInfo();
            itemInfoMain.Id = Guid.NewGuid();
            itemInfoMain.CreatedData = DateTime.Now.ToUniversalTime();
            itemInfoMain.ItemType = 0;
            itemInfoMain.ItemId = Guid.NewGuid();

            //var itemGUID = System.itemInfoMain.Parse(id);

            //var itemMain = _itemRepo.Get(itemGUID);
            ////itemInfoMain.i
            return itemInfoMain;
        }
        public async Task<IEnumerable<ItemInfo>> GetAsync()
        {
            var itemsFromRepo = await _itemRepo.GetAll();
            //var itemForContent = new ItemInfo();
           var  itemsForContent = new List<ItemInfo>();
            if (itemsFromRepo != null)
            {
                foreach (Item item in itemsFromRepo)
                {
                    var itemForContent = new ItemInfo()
                    {
                        Id = item.Id,
                        ItemId = item.ItemId,
                        CreatedData = item.CreatedData,
                        ItemType = item.ItemType
                    };
                    itemsForContent.Add(itemForContent);
                    
                }

                //itemForContent = itemFromRepo;
                //return itemsForContent;

            }
            return itemsForContent;  

        }
                     
            

            //var content   await _itemRepo.GetAll();
            //return content;

            //< IEnumerable < Item >> content = _itemRepo.GetAll(); 
            //var content =_itemRepo.GetAll();
            
            //await PrepareAuthenticatedClient();
            //var response = await _httpClient.GetAsync($"{_TodoListBaseAddress}/api/todolist");
            //if (response.StatusCode == HttpStatusCode.OK)
            //{
            //    var content = await response.Content.ReadAsStringAsync();
            //    IEnumerable<Todo> todolist = JsonConvert.DeserializeObject<IEnumerable<Todo>>(content);

            //    return todolist;
            //}

            //throw new HttpRequestException($"Invalid status code in the HttpResponseMessage: {response.StatusCode}.");
        
    }
}
