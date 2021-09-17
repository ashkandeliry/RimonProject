using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EshopLoginManagment.GenaralCLS
{
    [Serializable]
    public class ITException : Exception
    {
        public ITException()
        {

        }
        public ITException(string mass) : base(mass)
        {

        }
        //public ITException(string message) : base(message)
        //{
        //}
        public class ITError
        {
            public int code { get; set; }
            public string massage { get; set; }
        }

    }
}