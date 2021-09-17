using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Cmn.Encryptions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;
using Prototypes;
using SharedMethodsLib.Results.GeneralTypes;

namespace SharedMethodsLib
{
    public class SecurityPasswords
    {
        public string LoginServiceUsername { get; set; } = "Ashkan(Login)";
        public string LoginServicePassword { get; set; } = "Deliry(Login)";
    }
    public class SecurityPasswordStructure
    {
        public string ServiceUsername { get; set; }
        public string ServicePassword { get; set; }
    }
    public class SecurityCheck
    {
        public BoolResult ServiceLoginCheck(HttpRequest headerDictionary)
        {
            StringValues serviceUsername, ServicePassword;
            string Jwt = string.Empty, Username = string.Empty, Password = string.Empty;
            bool UsernameCheck = false, PasswordCheck = false;
            //if (JwtValidationRequires)
            //{
            //    if (headerDictionary.Headers.TryGetValue("X-JwtValue", out JwtValue))
            //    {
            //        Jwt = JwtValue.FirstOrDefault();
            //    }

            //    //string JwtValidateResult = SharedMethodsLib.TokenManager.ValidateToken(Jwt);
            //}
            if (headerDictionary.Headers.TryGetValue("X-serviceUsername", out serviceUsername))
            {
                Username = serviceUsername.FirstOrDefault();
            }
            if (headerDictionary.Headers.TryGetValue("X-ServicePassword", out ServicePassword))
            {
                Password = ServicePassword.FirstOrDefault();
            }



            if (string.IsNullOrWhiteSpace(Password) || string.IsNullOrWhiteSpace(Username))
                return new BoolResult { ResultCode = -1, Obj = false, ResultMessage = "نام کاربری و کلمه عبور سرویس را وارد نمایید" };
            else
            {
                string EnccyptionUsername = new Encryptor().Encrypt(Username , Hash_.EncryptionHashKey());
                string EnccyptionPassword = new Encryptor().Encrypt(Password , Hash_.EncryptionHashKey());
                
                string DecyptionUsername = new Encryptor().Decrypt(EnccyptionUsername, Hash_.EncryptionHashKey());
                string DecyptionPassword = new Encryptor().Decrypt(EnccyptionPassword, Hash_.EncryptionHashKey());

                UsernameCheck = new SecurityPasswords().LoginServiceUsername == new Encryptor().Decrypt(EnccyptionUsername, Hash_.EncryptionHashKey()) ? true : false;
                PasswordCheck = new SecurityPasswords().LoginServicePassword == new Encryptor().Decrypt(EnccyptionPassword, Hash_.EncryptionHashKey()) ? true : false;
            }
            if (UsernameCheck == true && PasswordCheck == true)
                return new BoolResult { ResultCode = 0, Obj = true, ResultMessage = "عملیات با موفقیت انجام شد" };
            else
                return new BoolResult { ResultCode = -1, Obj = false, ResultMessage = "نام کاربری یا کلمه عبور وارد شده نامعتبر است" };
        }
    }






}
