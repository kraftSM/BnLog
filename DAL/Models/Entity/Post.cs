using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BnLog.DAL.Models.Security;

namespace BnLog.DAL.Models.Entity
{
    public class Post
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public DateTime CreatedData { get; set; } = DateTime.Now.ToUniversalTime();
        public string AuthorId { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Body { get; set; } = string.Empty;
        public bool IsComplex { get; set; } = false;

        public List<Tag> Tags { get; set; } = new List<Tag>();
        public List<Comment> Comments { get; set; } = new List<Comment>();
        public List<User> Users { get; set; } = new List<User>();

    }
}
