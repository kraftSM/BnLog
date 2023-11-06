using System.ComponentModel.DataAnnotations;

<<<<<<< HEAD:DAL/Request/Security/RoleRequest.cs
namespace BnLog.DAL.Request.Security
=======
namespace BnLog.VAL.Request.Security
>>>>>>> ++ [Post, User ,Tag,Role] Edit -> Work:VAL/Request/Security/RoleRequest.cs
{
    public class RoleRequest
    {
        public Guid Id { get; set; }

        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }

        public bool IsSelected { get; set; }
    }
}
