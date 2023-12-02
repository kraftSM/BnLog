using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace BnLog.VAL.Request.Entity

{
    public class CommentRequest
    {
        [Required(ErrorMessage = "Поле Заголовок обязательно для заполнения")]
        [DataType(DataType.Text)]
        [Display(Name = "Заголовок", Prompt = "Заголовок")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Поле Текст обязательно для заполнения")]
        [DataType(DataType.Text)]
        [Display(Name = "Текст", Prompt = "Текст")]
        public string Body { get; set; }

        //[Required(ErrorMessage = "Поле Автор обязательно для заполнения")]
        //[DataType(DataType.Text)]
        //[Display(Name = "Автор", Prompt = "Автор")]
        public string Author { get; set; }
        public Guid Id { get; set; }
        public Guid PostId;
    }
}
