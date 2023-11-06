using System.ComponentModel.DataAnnotations;

<<<<<<< HEAD:DAL/Request/Security/RoleCreateRequest.cs
namespace BnLog.DAL.Request.Security
=======
namespace BnLog.VAL.Request.Security
>>>>>>> ++ [Post, User ,Tag,Role] Edit -> Work:VAL/Request/Security/RoleCreateRequest.cs
{
    public class RoleCreateRequest
    {
        [Required(ErrorMessage = "Поле Название обязательно для заполнения")]
        [DataType(DataType.Text)]
        [Display(Name = "Название", Prompt = "Название")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Уровень доступа обязательно для заполнения")]
        [DataType(DataType.Text)]
        [Display(Name = "Уровень доступа", Prompt = "Уровень")]
        public int SecurityLvl { get; set; }
    }
}
