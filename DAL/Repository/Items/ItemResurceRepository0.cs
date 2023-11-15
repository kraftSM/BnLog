using BnLog.DAL.Models.Items;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace BnLog.DAL.Repository.Items
{
    public class ItemResurceRepository0 : Repository<ItemResurce>
    {
        public ItemResurceRepository0(BlogDbContext context) : base(context)
        {
        }

    public async Task<List<ItemResurce>> GetAllAsync(Item item)
        {
            return await Set.Include(x => x.ItemId == item.Id).ToListAsync();
 
        }
 
    }
}
