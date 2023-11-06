using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

<<<<<<< HEAD:DAL/Request/Entity/TagEditRequest.cs
namespace BnLog.DAL.Request.Entity
=======
namespace BnLog.VAL.Request.Entity
>>>>>>> ++ [Post, User ,Tag,Role] Edit -> Work:VAL/Request/Entity/TagEditRequest.cs
{
    public class TagEditRequest
    {
        public Guid Id { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "Название", Prompt = "Введите Название tag'a")]
        public string Name { get; set; }
    }
}
