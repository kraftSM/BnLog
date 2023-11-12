using BnLog.DAL.Models.Items;
using Microsoft.EntityFrameworkCore;

namespace BnLog.DAL.Repository.Items
{
    public class ItemOptionRepository : Repository<ItemOption>
    {
        public ItemOptionRepository(BlogDbContext context) : base(context)
        {
        }

        public async Task<List<ItemOption>> GetAllAsync(Item item)
        {
            return await Set.Include(x => x.ItemId == item.Id).ToListAsync();
            //return await Set.ToListAsync();
        }

        //public override async Task<ItemOption?> GetByIdAsync(int id)
        //{
        //    return await Set.Include(x => x.Articles).Where(x => x.Id == id).FirstOrDefaultAsync();
        //}

        //public async Task<List<ItemOption>> GetByItemdAsync(int articleId)
        //{
        //    return await Set.Include(x => x.Articles)
        //    .SelectMany(x => x.Articles, (x, a) => new { Tag = x, ArticleId = a.Id })
        //    .Where(x => x.ArticleId == articleId).Select(x => x.Tag).ToListAsync();
        //}
    }
}
