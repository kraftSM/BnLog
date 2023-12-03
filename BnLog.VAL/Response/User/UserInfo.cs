using System;
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

        public string? UserName { get; set; }

        public string? Email { get; set; }

        public string Id { get; set; }
        }
    }
