using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;


namespace BnLog.VAL.Request.Entity

{
    public class TagRequest
    {
        public Guid Id { get; set; }

        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }

        public bool IsSelected { get; set; }
    }
}
