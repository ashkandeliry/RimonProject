using Prototypes;
using SharedMethodsLib.Results.GeneralTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EshopLoginManagment.DAL.IDAL
{
    public interface IUserSignUp_DAL
    {
        BoolResult CheckUserBySSNcode(string SSNcode);
        BoolResult CheckUserByUsername(string Username);
        VoidResult UserManagment(UserSignUpVM _userSignUpVM);
    }
}
