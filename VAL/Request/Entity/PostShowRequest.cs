using AutoMapper.Internal;

<<<<<<< HEAD:DAL/Request/Entity/PostShowRequest.cs
namespace BnLog.DAL.Request.Entity
=======
namespace BnLog.VAL.Request.Entity
>>>>>>> ++ [Post, User ,Tag,Role] Edit -> Work:VAL/Request/Entity/PostShowRequest.cs
{
    public class PostShowRequest
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public string AuthorId { get; set; }
        public List<TagRequest> Tags { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Body { get; set; }
    }
}
