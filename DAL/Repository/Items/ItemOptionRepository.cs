using BnLog.DAL.IRepository;
using BnLog.DAL.Models.Entity;
using BnLog.DAL.Models.Items;
//using BnLog.Migrations;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

namespace BnLog.DAL.Repository.Items
{
    public class ItemOptionRepository : IItemOptionRepository
    {
        private readonly BlogDbContext _context;
        public ItemOptionRepository(BlogDbContext db)
        {
            _context = db;
        }
        public async Task Create(ItemOption item)
        {
            var entry = _context.Entry(item);
            if (entry.State == EntityState.Detached)
                _context.ItemsOption.Add(item);
            await _context.SaveChangesAsync();
        }
        public async Task Delete(ItemOption item)
        {
            _context.ItemsOption.Remove(item);
            await _context.SaveChangesAsync();
        }
        public async Task<ItemOption> Get(Guid id)
        {
            return await _context.ItemsOption
                .FirstOrDefaultAsync(x => x.Id == id);

                //.Include(x => x.intVal)
                //.Include(x => x.strVal)
                //.Include(x => x.TypeId)
                //.Include(x => x.Type)
                //.FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task<IEnumerable<ItemOption>> GetAll()
        {
            return await _context.ItemsOption.ToListAsync();
        }

        public async Task<IEnumerable<ItemOption>> GetAllByItemId(Guid id)
        {
            return await _context.ItemsOption.Where(x => x.ItemId == id).ToListAsync();
        }
        public async Task Update(ItemOption item)
        {
            //await _context.ItemsOption.FindAsync(item.Id);
            var oldItem = _context.ItemsOption.FindAsync(item);

            var entry = _context.Entry(oldItem);

            if (entry.State == EntityState.Detached)
                _context.ItemsOption.Update(item);
            await _context.SaveChangesAsync();
        }
    }
}

