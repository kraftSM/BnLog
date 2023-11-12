using BnLog.DAL.Models.Entity;
using BnLog.DAL.Models.Info;
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
        public DbSet<ItemInfo> Items { get; set; }

        public BlogDbContext(DbContextOptions<BlogDbContext> options) : base(options)
        {
            //Database.EnsureDeleted();
            Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            //builder.Ignore<IdentityUserToken<int>>();
            //builder.Ignore<IdentityUserLogin<int>>();

            //builder.Entity<Post>().ToTable("post");
            //builder.Entity<Role>().ToTable("roles").HasKey(x => x.Id);
            //builder.Entity<Tag>().ToTable("tags");
            //builder.Entity<User>().ToTable("users");

            //builder.Entity<IdentityUserRole<int>>()
            //  .HasOne<User>()
            //  .WithMany()
            //  .HasForeignKey(ur => ur.UserId)
            //  .IsRequired();

            //builder.Entity<Comment>()
            //.ToTable("Comments")
            //.HasOne(a => a.User)
            //.WithMany(b => b.Comments)
            //.HasForeignKey(c => c.UserId)
            //.HasPrincipalKey(d => d.Id)
            //.IsRequired(false);
        }

    }
}
