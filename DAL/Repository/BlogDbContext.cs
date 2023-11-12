using BnLog.DAL.Models.Entity;
using BnLog.DAL.Models.Items;
using BnLog.DAL.Models.Security;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Xml;

namespace BnLog.DAL.Repository
{
    public class BlogDbContext : IdentityDbContext<User, Role, string>
    {
        public DbSet<Post> Posts { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<ItemOption> ItemsOption { get; set; }
        public DbSet<ItemResurce> ItemsResurce { get; set; }
        public BlogDbContext(DbContextOptions<BlogDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

    }
}
