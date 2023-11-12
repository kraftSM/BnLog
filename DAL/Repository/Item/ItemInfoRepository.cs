using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using BnLog.DAL.IRepository;
using BnLog.DAL.Repository;
using BnLog.DAL.Models.Info;
using BnLog.DAL.Models.Entity;

namespace BnLog.DAL.Repository.Item

{
    public class ItemInfoRepository : IItemInfoRepository
    {
        private BlogDbContext _context;
        public ItemInfoRepository(BlogDbContext context)
        {
            _context = context;
        }
        //public ItemRepository(BlogDbContext context) : base(context)
        //{
        //}
        //public override async Task<List<Item>> GetAllAsync()
        //{
        //    return await Set.ToListAsync();
        //}
        public List<ItemInfo> GetAllItems()
        {
            return _context.Items.ToList();
        }

        //public List<Item> GetAllItemsOfTypes(int pItemType)
        //{
        //    return _context.Items.Include(p => p.ItemType == pItemType).ToList();
        //}

        //public Item GetItem(Guid id)
        //{
        //    return _context.Items.Include(p => p.ItemType).FirstOrDefault(p => p.Id == id);
        //}
        public async Task AddItem(ItemInfo item)
        {
            _context.Items.Add(item);
        }
        public async Task<bool> SaveChangesAsync()
        {
            if (await _context.SaveChangesAsync() > 0)
            {
                return true;
            }
            return false;
        }
    }
}
