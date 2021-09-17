using SharedMethodsLib;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;

namespace EshopLoginManagment.BusinessModels
{
    public class LoginVM//: SecurityPasswordStructure
    {
        [Required]
        [MaxLength(12)]
        public string Username { get; set; }
        [Required]
        [MaxLength(20)]
        public string Password { get; set; }
        [Required]
        public byte UserType { get; set; }
    }

}
