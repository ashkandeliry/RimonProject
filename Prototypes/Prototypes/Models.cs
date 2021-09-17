using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.IdentityModel.Tokens.Jwt;

namespace Prototypes
{
    public enum CudTypes
    {
        Insert = 1,
        Update = 2,
        Remove = 3
    }

    public class Hash_
    {
        public static string EncryptionHashKey() { return "Mix.6810"; }
    }
    [NotMapped]
    public class UserData
    {
        public string Name { get; set; }
        public string Lname { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int User_Id { get; set; }
        public string SSNcode { get; set; }
        //public JwtSecurityToken Token { get; set; }
    }
    public class UserDataOutput
    {
        public string Name { get; set; }
        public string Lname { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int User_Id { get; set; }
        public string SSNcode { get; set; }
        public JwtSecurityToken Token { get; set; }
    }

    public class UserSignUpVM
    {
        [MaxLength(20)]
        public string Name { get; set; }
        [MaxLength(30)]
        public string Lname { get; set; }
        [Required]
        [MaxLength(20)]
        public string Username { get; set; }
        [Required]
        [MaxLength(20)]
        public string Password { get; set; }
        [Required]
        [MaxLength(15)]
        public string SSNcode { get; set; }
        [Required]
        [MaxLength(12)]
        public string Phone { get; set; }
        [Required]
        [MaxLength(30)]
        public string Email { get; set; }
        public int UserId { get; set; }
    
    }
    public class CityWeatherData
    {
        public string CityName { get; set; }
        public int WeatherNo { get; set; }
    }
}
