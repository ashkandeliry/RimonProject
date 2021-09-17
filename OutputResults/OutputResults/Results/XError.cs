using System;
using System.Collections.Generic;
using System.Text;

namespace SharedMethodsLib.Results
{
    public class XError
    {
        public int Code { get; set; }
        public string Message { get; set; }
        public XError() { }
        public XError(int code, string message)
        {
            Code = code;
            Message = message;
        }

        public static XError GeneralError
        {
            get { return new XError(1, "خطا در سامانه"); }
        }
        public class InputErrors_
        {
            public static XError PostalCodeFieldIsNull() { return new XError(105, "فیلد کد پستی خالی است."); }
            public static XError MobileNumberNotValid() { return new XError(102, "شماره تلفن همراه نامعتبر است."); }
            public static XError NationalCodeNotValid(string nationalcode) { return new XError(103, "کد ملی " + nationalcode + " نامعتبر است."); }
            public static XError NationalCodeFieldIsNull() { return new XError(108, "فیلد کد ملی خالی است."); }
        }

        public class AuthenticationErrors_
        {
            public static XError UserNameOrPasswordIsWrong() { return new XError(2001, "خطا در احراز هویت کاربر"); }
            public static XError LoginFirst() { return new XError(2002, "لطفا ابتدا وارد شوید"); }
            public static XError NeedLoginAgain() { return new XError(2003, "لطفا جهت ادامه کار مجددا وارد شوید"); }
            public static XError SessionTimedOut() { return new XError(2004, "زمان شما به اتمام رسیده است"); }
        }


    }
}
