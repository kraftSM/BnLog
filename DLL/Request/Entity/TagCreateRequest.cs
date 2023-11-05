using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace BnLog.DLL.Request.Entity
{    public class TagCreateRequest
    {
        [Required(ErrorMessage = "Поле Название обязательно для заполнения")]
        [DataType(DataType.Text)]
        [Display(Name = "Название", Prompt = "Название")]
        public string Name { get; set; }
    }
}
