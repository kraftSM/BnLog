using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BnLog.DAL.Models.Entity
{
    public class Tag
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public DateTime CreatedData { get; set; } = DateTime.Now.ToUniversalTime();
        public string Name { get; set; } = string.Empty;
        public List<Post> Posts { get; set; } = new List<Post>();
    }
}
