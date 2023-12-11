using AutoMapper.Internal;


namespace BnLog.VAL.Request.Entity

{
    public class PostInfoRequest
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        //public string AuthorId { get; set; }
        //public List<TagSelectInfo> Tags { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Body { get; set; }
    }
}
