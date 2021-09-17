using EshopLoginManagment.BusinessModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SharedMethodsLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rimon_Main.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StartupMainController : ControllerBase
    {
        [HttpGet]
        public string Get()
        {
            LoginVM UserData = new LoginVM();
            UserData.Password = "123";
            UserData.Username = "sdfsdf";
            string Json = JsonConvert.SerializeObject(UserData);

            SecurityPasswordStructure UserData1 = new SecurityPasswordStructure();
            UserData1.ServicePassword = "Ashkan(Login)";
            UserData1.ServiceUsername = "Deliry(Login)";
            string Json2 = JsonConvert.SerializeObject(UserData1);

            return Json + " ( " + Json2 + " ) ";
        }
    }
}
