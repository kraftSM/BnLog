﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BnLog.Repo.Models.Security;

namespace BnLog.Repo.Models.Entitys
{
    public class Post
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public string Title { get; set; } = string.Empty;
        public string Body { get; set; } = string.Empty;
        public string AuthorId { get; set; } = string.Empty;

        public DateTime CreatedData { get; set; } = DateTime.Now;
        public List<Tag> Tags { get; set; } = new List<Tag>();
        public List<Comment> Comments { get; set; } = new List<Comment>();
        public List<User> Users { get; set; } = new List<User>();

    }
}