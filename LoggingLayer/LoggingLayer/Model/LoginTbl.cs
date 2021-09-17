using System;
using System.Collections.Generic;

#nullable disable

namespace LoggingLayer.Model
{
    public partial class LoginTbl
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public int Id { get; set; }
        public int UserId { get; set; }

        public virtual UsersTbl User { get; set; }
    }
}
