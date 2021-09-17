using System;
using System.Collections.Generic;

#nullable disable

namespace LoggingLayer.Model
{
    public partial class UsersTbl
    {
        public UsersTbl()
        {
            LoginTbls = new HashSet<LoginTbl>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Lname { get; set; }
        public int Ssncode { get; set; }
        public int Phone { get; set; }
        public string Email { get; set; }

        public virtual ICollection<LoginTbl> LoginTbls { get; set; }
    }
}
