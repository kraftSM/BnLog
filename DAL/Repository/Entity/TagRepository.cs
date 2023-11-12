using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

using BnLog.DAL.IRepository;
using BnLog.DAL.Repository;
using BnLog.DAL.Models.Entity;


namespace BnLog.DAL.Repository.Entity
{
    public class TagRepository : ITagRepository
    //public class TagRepository : Repository<Tag>
    {
        private BlogDbContext _context;

        public TagRepository(BlogDbContext context)
        {
            _context = context;
        }
        //public TagRepository(BlogDbContext context) : base(context)
        //{
        //}
        //public override async Task<List<Tag>> GetAllAsync()
        //{
        //    return await Set.Include(x => x.Posts).ToListAsync();
        //}

        //public async Task<Tag?> GetByIdAsync(int id)
        //{
        //    return await Set.Include(x => x.Posts).Where(x => x.Id == id).FirstOrDefaultAsync();
        //}
        //public async Task<List<Tag>> GetByArticleIdAsync(int PostId)
        //{
        //    return await Set.Include(x => x.Posts)
        //    .SelectMany(x => x.Posts, (x, a) => new { Tag = x, ArticleId = a.Id })
        //    .Where(x => x.Id == PostId).Select(x => x.Tag).ToListAsync();
        //}

        //public async Task<List<Tag>> GetByArticleIdAsync(Guid PostId)
        //{
        //    return await Set.Include(x => x.Posts)
        //    .SelectMany(x => x.Posts, (x, a) => new { Tag = x, PostId = a.Id })
        //    .Where(x => x.PostId == PostId).Select(x => x.Tag).ToListAsync();
        //}
        //public override async Task<Tag?> GetByGuidAsync(Guid id)
        //{
        //    return await Set.Include(x => x.Posts).Where(x => x.Id == id).FirstOrDefaultAsync();
        //}
        //public override async Task<Tag?> GetByIdAsync(int id)
        //{
        //    //return await Set.Include(x => x.Posts).Where(x => x.Id == id).FirstOrDefaultAsync();
        //    return null;

        //}
        public HashSet<Tag> GetAllTags()
        {
            return _context.Tags.ToHashSet();
        }

        public Tag GetTag(Guid id)
        {
            return _context.Tags.FirstOrDefault(t => t.Id == id);
        }

        public async Task AddTag(Tag tag)
        {
            _context.Tags.Add(tag);
            await SaveChangesAsync();
        }

        public async Task UpdateTag(Tag tag)
        {
            _context.Tags.Update(tag);
            await SaveChangesAsync();
        }

        public async Task RemoveTag(Guid id)
        {
            _context.Tags.Remove(GetTag(id));
            await SaveChangesAsync();
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
