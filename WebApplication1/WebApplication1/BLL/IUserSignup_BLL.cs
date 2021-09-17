using Prototypes;
using SharedMethodsLib.Results.GeneralTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EshopLoginManagment.BLL.IBLL
{
    public interface IUserSignup_BLL
    {
        VoidResult UserManagment(UserSignUpVM UserData);
    }
}
