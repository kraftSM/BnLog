using AutoMapper.Internal;

namespace BnLog.DAL.Request.Entity
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
