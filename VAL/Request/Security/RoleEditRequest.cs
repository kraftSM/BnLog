using System.ComponentModel.DataAnnotations;

<<<<<<< HEAD:DAL/Request/Security/RoleEditRequest.cs
namespace BnLog.DAL.Request.Security
=======
namespace BnLog.VAL.Request.Security
>>>>>>> ++ [Post, User ,Tag,Role] Edit -> Work:VAL/Request/Security/RoleEditRequest.cs
{
    public class RoleEditRequest
    {
        public Guid Id { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "Название", Prompt = "Название")]
        public string Name { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "Уровень доступа", Prompt = "Уровень")]
        public int? SecurityLvl { get; set; } = null;
    }
}
