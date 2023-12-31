﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BnLog.DAL.Models.Entity
{
    public class Comment
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public DateTime CreatedData { get; set; } = DateTime.Now.ToUniversalTime();
        public string Title { get; set; }
        public string Body { get; set; }
        public string Author { get; set; }

        public Guid PostId { get; set; }
        public Guid AuthorId { get; set; }
    }
}
