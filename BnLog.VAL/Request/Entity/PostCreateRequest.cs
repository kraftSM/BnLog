using AutoMapper.Internal;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;


namespace BnLog.VAL.Request.Entity

{
    public class PostCreateRequest
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string AuthorId { get; set; }
        public List<TagInfo> Tags { get; set; }


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
