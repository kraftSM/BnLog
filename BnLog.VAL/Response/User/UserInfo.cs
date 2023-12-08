﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BnLog.VAL.Request.Security;
using System.Xml.Linq;

namespace BnLog.VAL.Response.User
{
    public class UserInfo
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }

        [Display(Name = "UserName - Псевдоним ")]
        public string? UserName { get; set; }

        [Display(Name = "registered Email")]
        public string? Email { get; set; }

        [Display(Name = "UserId")]
        public string Id { get; set; }
    }
}
