using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UserAPI.Models
{
    public class User
    {
        public string UserPrincipalName { get; set; }
        public string DisplayName { get; set; }
        public bool AccountEnabled { get; set; }
    }
}