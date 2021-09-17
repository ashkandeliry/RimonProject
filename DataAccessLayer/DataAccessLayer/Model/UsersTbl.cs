using System;
using System.Collections.Generic;

#nullable disable

namespace DataAccessLayer.Model
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
        public string Ssncode { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        public virtual ICollection<LoginTbl> LoginTbls { get; set; }
    }
}
