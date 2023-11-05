using BnLog.DLL.Models.Entity;
using BnLog.DLL.Models.Items;
using Microsoft.EntityFrameworkCore;
using BnLog.DLL.IRepository;


namespace BnLog.DLL.Repository.Items
{
    public class ItemsRepository: IItemsRepository
    {
        private BlogDbContext _context; 
        public ItemsRepository(BlogDbContext context)
        {
            _context = context;
        }

        public List<Item> GetAllItems()
        {
            return _context.Items.Include(p => p.ItemType).ToList();
        }
        public List<Item> GetAllItemsOfTypes(int pItemType)
        {
            return _context.Items.Include(p => p.ItemType == pItemType).ToList();
        }

        public Item GetItem(Guid id)
        {
            return _context.Items.Include(p => p.ItemType).FirstOrDefault(p => p.Id == id);
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
