using System;
using System.Collections.Generic;
using System.Text;

namespace SharedMethodsLib.Results.GeneralTypes
{
    public class VoidResult
    {
        public int ResultCode { get; set; }
        public string ResultMessage { get; set; }

        public static VoidResult GetSuccessResult(string Message)
        {
            return new VoidResult()
            {
                ResultCode = GeneralResultCode.Results_Cls.ResultCode,
                ResultMessage = string.IsNullOrWhiteSpace(Message) ? GeneralResultCode.Results_Cls.ResultMessage : Message
            };
        }
        public static VoidResult GetFailResult(Exception ex)
        {
            BusinessException exc = BusinessException.TryParseAndTranslate(ex);
            return new VoidResult()
            {
                ResultCode = exc.Code,
                ResultMessage = exc.Message
            };
        }
    }
}
