using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace BnLog.DLL.Request.Entity
{
    public class TagEditRequest
    {
        public Guid Id { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "Название", Prompt = "Название")]
        public string Name { get; set; }
    }
}
