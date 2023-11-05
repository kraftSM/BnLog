using BnLog.DLL.Models.Entity;
using BnLog.DLL.Models.Items;
using BnLog.DLL.Models.Security;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Xml;

namespace BnLog.DLL.Repository
{
    public class BlogDbContext : IdentityDbContext<User, Role, string>
    {
        public DbSet<Post> Posts { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Item> Items { get; set; }

        public BlogDbContext(DbContextOptions<BlogDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

    }
}
