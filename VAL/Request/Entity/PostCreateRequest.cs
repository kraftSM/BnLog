using AutoMapper.Internal;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

<<<<<<< HEAD:DAL/Request/Entity/PostCreateRequest.cs
namespace BnLog.DAL.Request.Entity
=======
namespace BnLog.VAL.Request.Entity
>>>>>>> ++ [Post, User ,Tag,Role] Edit -> Work:VAL/Request/Entity/PostCreateRequest.cs
{
    public class PostCreateRequest
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string AuthorId { get; set; }
        public List<TagRequest> Tags { get; set; }


        [Required(ErrorMessage = "Поле Заголовок обязательно для заполнения")]
        [DataType(DataType.Text)]
        [Display(Name = "Заголовок", Prompt = "Заголовок")]
        public string Title { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "Описание", Prompt = "Краткое описание поста")]
        public string? Description { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "Пост", Prompt = "Содержание поста")]
        public string Body { get; set; }
    }
}
