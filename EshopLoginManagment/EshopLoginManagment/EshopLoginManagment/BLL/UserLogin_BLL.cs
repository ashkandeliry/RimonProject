using EshopLoginManagment.BLL.IBLL;
using EshopLoginManagment.BusinessModels;
using EshopLoginManagment.DAL.IDAL;
using SharedMethodsLib.Results.GeneralTypes;
using SharedMethodsLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using Prototypes;
using Common.CustomValidations;
using Cmn.Encryptions;

namespace EshopLoginManagment.BLL
{
    public class UserLogin_BLL : IUserLogin_BLL
    {
        private readonly IUserLogin_DAL DalInterface;
        public UserLogin_BLL(IUserLogin_DAL userLogin_DAL)
        {
            DalInterface = userLogin_DAL;
        }
        
        public DynamicResult<UserDataOutput> LoginUser(LoginVM UserData)
        {
            try
            {
                //EncryptionsMethodes encryptions = new EncryptionsMethodes();
                //string Username = new Encryptor().Decrypt(UserData.Username, Hash_.EncryptionHashKey());
                //string Password = new Encryptor().Decrypt(UserData.Password, Hash_.EncryptionHashKey());
                //Get User ID
                DynamicResult<UserDataOutput> GetUserByUserName = DalInterface.GetUserByUsername_DAL(UserData.Username);
                //Check User is Exists
                if (GetUserByUserName == null || (GetUserByUserName.ObjList == null))
                    throw new Exception("نام کاربری یافت نشد برای ورود به پنل کاربری لطفا ثبت نام فرمایید");
                //CheckUSername and Password maching
                BoolResult CheckUsername_Password = DalInterface.CheckUsername_Password(GetUserByUserName.ObjList.User_Id , UserData.Password);
                if (!CheckUsername_Password.Obj)
                    throw new Exception("نام کاربری و کلمه عبور نامعتبر است");
                    TokenManager tokenManager = new TokenManager();
                    JwtSecurityToken JWTtoken = tokenManager.GenerateToken(GetUserByUserName.ObjList.Username);
                //Send Final Result To User
                UserDataOutput UpdteUserData = new UserDataOutput { Token = JWTtoken };
                return new DynamicResult<UserDataOutput> { ObjList = UpdteUserData, Code = 0, Message = "ورود به حساب کاربری با موفقیت انجام شد" };
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
