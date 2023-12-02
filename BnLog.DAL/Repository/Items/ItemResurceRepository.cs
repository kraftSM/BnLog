using BnLog.DAL.IRepository;
using BnLog.DAL.Models.Items;
using Microsoft.EntityFrameworkCore;

namespace BnLog.DAL.Repository.Items
{
        

    public class ItemResurceRepository : IItemResurceRepository
    {
        
        private readonly BlogDbContext _context;
        public ItemResurceRepository(BlogDbContext db)
        {
            _context = db;
        }
        public async Task Create(ItemResurce item)
        {
            var entry = _context.Entry(item);
            if (entry.State == EntityState.Detached)
                _context.ItemsResurce.Add(item);
            await _context.SaveChangesAsync();
        }
        public async Task Delete(ItemResurce item)
        {
            _context.ItemsResurce.Remove(item);
            await _context.SaveChangesAsync();
        }
        public async Task<ItemResurce> Get(Guid id)
        {
            return await _context.ItemsResurce
                .FirstOrDefaultAsync(x => x.Id == id);

            //.Include(x => x.intVal)
            //.Include(x => x.strVal)
            //.Include(x => x.TypeId)
            //.Include(x => x.Type)
            //.FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task<IEnumerable<ItemResurce>> GetAll()
        {
            return await _context.ItemsResurce.ToListAsync();
        }

        public async Task<IEnumerable<ItemResurce>> GetAllByItemId(Guid id)
        {
            return await _context.ItemsResurce.Where(x => x.ItemId == id).ToListAsync();
        }
        public async Task Update(ItemResurce item)
        {
            //? var oldItem = Get(item);
            // await _context.ItemsResurce.FindAsync(item.Id);
            var dbItem = _context.ItemsResurce.FindAsync(item);

            dbItem.Result.ItemId = item.ItemId;
            dbItem.Result.Type = item.Type;
            dbItem.Result.TypeId = item.TypeId;
            dbItem.Result.strVal = item.strVal;
            dbItem.Result.intVal = item.intVal;

            var entry = _context.Entry(dbItem);
            if (entry.State == EntityState.Detached)
                _context.ItemsResurce.Update(dbItem.Result);
            await _context.SaveChangesAsync();
        }
    }
}
