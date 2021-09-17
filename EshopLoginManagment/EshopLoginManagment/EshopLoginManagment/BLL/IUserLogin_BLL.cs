using EshopLoginManagment.BusinessModels;
using Prototypes;
using SharedMethodsLib.Results.GeneralTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EshopLoginManagment.BLL.IBLL
{
    public interface IUserLogin_BLL
    {
        DynamicResult<UserDataOutput> LoginUser(LoginVM UserData);
    }
}
