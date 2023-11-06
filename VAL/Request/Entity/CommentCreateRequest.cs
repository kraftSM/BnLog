using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

<<<<<<< HEAD:DAL/Request/Entity/CommentCreateRequest.cs
namespace BnLog.DAL.Request.Entity
=======
namespace BnLog.VAL.Request.Entity
>>>>>>> ++ [Post, User ,Tag,Role] Edit -> Work:VAL/Request/Entity/CommentCreateRequest.cs
{
    public class CommentCreateRequest
    {
        [Required(ErrorMessage = "Поле Заголовок обязательно для заполнения")]
        [DataType(DataType.Text)]
        [Display(Name = "Заголовок", Prompt = "Заголовок")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Поле Описание обязательно для заполнения")]
        [DataType(DataType.Text)]
        [Display(Name = "Описание", Prompt = "Описание")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Поле Автор обязательно для заполнения")]
        [DataType(DataType.Text)]
        [Display(Name = "Автор", Prompt = "Автор")]
        public string Author { get; set; }

        public Guid PostId;
    }
}
