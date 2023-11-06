using System.ComponentModel.DataAnnotations;

<<<<<<< HEAD:DAL/Request/Security/UserLoginRequest.cs
namespace BnLog.DAL.Request.Security
=======
namespace BnLog.VAL.Request.Security
>>>>>>> ++ [Post, User ,Tag,Role] Edit -> Work:VAL/Request/Security/UserLoginRequest.cs
{
    public class UserLoginRequest
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email", Prompt = "Введите email")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль", Prompt = "Введите пароль")]
        public string Password { get; set; }

    }
}
