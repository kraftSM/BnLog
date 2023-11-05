using AutoMapper.Internal;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace BnLog.DLL.Request.Entity
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

        [Required(ErrorMessage = "Поле Описание обязательно для заполнения")]
        [DataType(DataType.Text)]
        [Display(Name = "Описание", Prompt = "Описание")]
        public string Body { get; set; }
    }
}
