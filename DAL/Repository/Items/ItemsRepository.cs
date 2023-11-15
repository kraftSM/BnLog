using BnLog.DAL.IRepository;
using BnLog.DAL.Models.Items;
using Microsoft.EntityFrameworkCore;

namespace BnLog.DAL.Repository.Items
{
    public class ItemsRepository : IItemsRepository
    {
        private readonly BlogDbContext _context;
        public ItemsRepository(BlogDbContext db)
        {
            _context = db;
        }
        public async Task Create(Item item)
        {
            var entry = _context.Entry(item);
            if (entry.State == EntityState.Detached)
                _context.Items.Add(item);
            await _context.SaveChangesAsync();
        }
        public async Task Delete(Item item)
        {
            _context.Items.Remove(item);
            await _context.SaveChangesAsync();
        }
        public async Task<Item> Get(Guid id)
        {
            return await _context.Items
                .FirstOrDefaultAsync(x => x.Id == id);

            //.Include(x => x.intVal)
            //.Include(x => x.strVal)
            //.Include(x => x.TypeId)
            //.Include(x => x.Type)
            //.FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task<IEnumerable<Item>> GetAll()
        {
            return await _context.Items
                .ToListAsync();
        }

        public async Task<IEnumerable<Item>> GetAllByItemId(Guid id)
        {
            return await _context.Items.Where(x => x.ItemId == id).ToListAsync();
        }
        public async Task Update(Item item)
        {
            await _context.Items.FindAsync(item.Id);
            var oldItem = _context.Items.FindAsync(item);

            var entry = _context.Entry(oldItem);

            if (entry.State == EntityState.Detached)
                _context.Items.Update(item);
            await _context.SaveChangesAsync();
        }
    }
}
