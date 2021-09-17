using System;
using System.Collections.Generic;
using System.Text;

namespace SharedMethodsLib.Results
{
    class GeneralResultCode
    {
        public class Results_Cls
        {
            public static int ResultCode= 0;
            public static string ResultMessage = "عملیات با موفقیت انجام شد";
            public static int SingleResultTotalCount = -1;
            public static int FailResultTotalCount = -1000;
        }
        public class Results_HandeledFaild
        {
            public static int ResultCode= -1;
            public static string ResultMessage = "مشکلی در عملیات سامانه بوجود آمده است";
            public static int SingleResultTotalCount = -1;
            public static int FailResultTotalCount = -1000;
        }
        public class Results_Exception
        {
            public static int ResultCode= -2;
            public static string ResultMessage = "خطا در سامانه";
            public static int SingleResultTotalCount = -1;
            public static int FailResultTotalCount = -1000;
        }
    }
}
