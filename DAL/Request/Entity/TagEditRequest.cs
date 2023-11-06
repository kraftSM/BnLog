using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace BnLog.DAL.Request.Entity
{
    public class TagEditRequest
    {
        public Guid Id { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "Название", Prompt = "Введите Название tag'a")]
        public string Name { get; set; }
    }
}
