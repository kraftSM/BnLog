﻿using AutoMapper.Internal;

namespace BnLog.DLL.Request.Entity
{
    public class PostShowRequest
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public string AuthorId { get; set; }
        public List<TagRequest> Tags { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
    }
}
