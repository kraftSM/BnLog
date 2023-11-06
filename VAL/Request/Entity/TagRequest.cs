using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

<<<<<<< HEAD:DAL/Request/Entity/TagRequest.cs
namespace BnLog.DAL.Request.Entity
=======
namespace BnLog.VAL.Request.Entity
>>>>>>> ++ [Post, User ,Tag,Role] Edit -> Work:VAL/Request/Entity/TagRequest.cs
{
    public class TagRequest
    {
        public Guid Id { get; set; }

        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }

        public bool IsSelected { get; set; }
    }
}
