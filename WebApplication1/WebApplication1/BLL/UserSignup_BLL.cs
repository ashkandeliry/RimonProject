using EshopLoginManagment.BLL.IBLL;
using EshopLoginManagment.DAL.IDAL;
using Prototypes;
using SharedMethodsLib.Results.GeneralTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EshopLoginManagment.BLL
{
    public class UserSignup_BLL : IUserSignup_BLL
    {
        private readonly IUserSignUp_DAL DalInterface;
        public UserSignup_BLL(IUserSignUp_DAL userLogin_DAL)
        {
            DalInterface = userLogin_DAL;
        }
        public VoidResult UserManagment(UserSignUpVM UserData)
        {
            try
            {
                BoolResult CheckUserBySSNcode = DalInterface.CheckUserBySSNcode(UserData.SSNcode);
                if (!CheckUserBySSNcode.Obj)
                return VoidResult.GetSuccessResult("کاربر با کدملی وارد شده در سامانه ثبت نام شده است");
                BoolResult CheckUserByUsername = DalInterface.CheckUserByUsername(UserData.Username);
                if (!CheckUserByUsername.Obj)
                    return VoidResult.GetSuccessResult("کاربر با نام کاربری وارد شده در سامانه ثبت نام شده است");

                VoidResult SignUpUser = DalInterface.UserManagment(UserData);
                return VoidResult.GetSuccessResult(SignUpUser.ResultMessage);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
