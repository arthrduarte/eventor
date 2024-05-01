using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EventSystem.Models
{
    public class Registration
    {
        public int EventID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public Registration(string name, string email, int eventid)
        {
            this.EventID = eventid;
            this.Name = name;
            this.Email = email;
        }
    }
}