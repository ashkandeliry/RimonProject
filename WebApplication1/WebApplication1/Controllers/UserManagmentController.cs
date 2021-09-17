using EshopLoginManagment.BLL.IBLL;
using EshopLoginManagment.BusinessModels;
using EshopLoginManagment.GenaralCLS;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using Newtonsoft.Json;
using Prototypes;
using SharedMethodsLib;
using SharedMethodsLib.Results;
using SharedMethodsLib.Results.GeneralTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;


namespace EshopLoginManagment.Controllers
{
    public class UserManagmentController : BaseMainController
    {
        private readonly IUserSignup_BLL _IUserSignup_BLL;
        private readonly SecurityCheck _SecurityCheck = new SecurityCheck();
        public UserManagmentController(IUserSignup_BLL IuserSignup_BLL)
        {
            _IUserSignup_BLL = IuserSignup_BLL;
        }
        [HttpPost]
        [ActionName("SignUp")]
        public VoidResult UserManagmentservice([FromBody] UserSignUpVM UserData)
        {
            try
            {
                if (!ModelState.IsValid)
                    throw new Exception("اطلاعات اجباری فرم وارد نشده است");
                else
                {
                    BoolResult Result_SecurityCheck =  _SecurityCheck.ServiceLoginCheck(Request);
                    if (!Result_SecurityCheck.Obj)
                        throw new Exception(Result_SecurityCheck.ResultMessage);
                    else
                    {
                        TimeSpan Start = new TimeSpan(DateTime.Now.Ticks);
                        VoidResult Result = _IUserSignup_BLL.UserManagment(UserData);
                        TimeSpan End = new TimeSpan(DateTime.Now.Ticks);
                        LogHandler.LogData(MethodBase.GetCurrentMethod(), Result, End - Start, UserData);
                        return Result;
                    }
                }
            }
            catch (Exception ex)
            {
                return VoidResult.GetFailResult(ex);
            }
        }
    }
}
