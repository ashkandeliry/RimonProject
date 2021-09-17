using EshopLoginManagment.BLL.IBLL;
using EshopLoginManagment.BusinessModels;
using EshopLoginManagment.GenaralCLS;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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
    public class AuthrnticationController : BaseController
    {
        private readonly IUserLogin_BLL _IUserLogin_BLL;
        private readonly ILogger<AuthrnticationController> _logger;
        private readonly SecurityCheck _SecurityCheck = new SecurityCheck();
        public AuthrnticationController(IUserLogin_BLL IUserLogin_BLL, ILogger<AuthrnticationController> logger)
        {
            _IUserLogin_BLL = IUserLogin_BLL;
            _logger = logger;
        }

        

        [HttpPost]
        [ActionName("Login")]
        public DynamicResult<UserDataOutput> UserLogin([FromBody] LoginVM UserData)
        {
            try
            {
                if (!ModelState.IsValid)
                    return new DynamicResult<UserDataOutput> { Code = -1, Message = "اطلاعات اجباری فرم وارد نشده است", ObjList = null };
                else
                {
                    BoolResult Result_SecurityCheck = _SecurityCheck.ServiceLoginCheck(Request);
                    if (!Result_SecurityCheck.Obj)
                        return new DynamicResult<UserDataOutput> { Code = -1, Message = Result_SecurityCheck.ResultMessage, ObjList = null };
                    else
                    {
                        TimeSpan Start = new TimeSpan(DateTime.Now.Ticks);
                        DynamicResult<UserDataOutput> Result = _IUserLogin_BLL.LoginUser(UserData);
                        TimeSpan End = new TimeSpan(DateTime.Now.Ticks);
                        LogHandler.LogData(MethodBase.GetCurrentMethod(), Result, End - Start, UserData);
                        string Json = JsonConvert.SerializeObject(UserData);
                        _logger.LogInformation(Json);
                        return Result;
                    }
                }
            }
            catch (Exception ex)
            {
                return new DynamicResult<UserDataOutput> { Code = -1, Message = ex.Message, ObjList = null };
            }
        }

    }
}
