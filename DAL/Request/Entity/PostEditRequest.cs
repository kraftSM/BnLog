using AutoMapper.Internal;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace BnLog.DAL.Request.Entity
{
    public class PostEditRequest
    {
        public Guid id { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "Заголовок", Prompt = "Заголовок")]
        public string? Title { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "Описание", Prompt = "Краткое описание поста")]
        public string? Description { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "Пост", Prompt = "Содержание поста")]
        public string? Body { get; set; }

        [Display(Name = "Теги", Prompt = "Теги")]
        public List<TagRequest>? Tags { get; set; }
    }
}
