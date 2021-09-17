using EshopLoginManagment.BusinessModels;
using Prototypes;
using SharedMethodsLib.Results.GeneralTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EshopLoginManagment.DAL.IDAL
{
    public interface IUserLogin_DAL
    {
        DynamicResult<UserDataOutput> LoginUser_DAL(int UserID);
        DynamicResult<UserDataOutput> GetUserByUsername_DAL(string Username);
        BoolResult CheckUsername_Password(int Userid , string Password);
    }
}
