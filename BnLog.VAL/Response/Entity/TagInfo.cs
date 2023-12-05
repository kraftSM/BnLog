using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;


namespace BnLog.VAL.Response.Entity

{
    public class TagInfo
    {
        public Guid Id { get; set; }

        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }
    }
}
