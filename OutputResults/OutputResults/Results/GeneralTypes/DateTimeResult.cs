using System;
using System.Collections.Generic;
using System.Text;

namespace SharedMethodsLib.Results.GeneralTypes
{
    public class DateTimeResult : MasterResult<DateTime>
    {
        public static DateTimeResult GetListSuccessfulResult(List<DateTime> list, int totalCount)
        {
            return new DateTimeResult()
            {
                ObjList = list,
                TotalCount = totalCount,
                ResultCode = GeneralResultCode.Results_Cls.ResultCode,
                ResultMessage = GeneralResultCode.Results_Cls.ResultMessage
            };
        }
        public static DateTimeResult GetListSuccessfulResult(List<DateTime> list, int totalCount, string successMessage)
        {
            return new DateTimeResult()
            {
                ObjList = list,
                TotalCount = totalCount,
                ResultCode = GeneralResultCode.Results_Cls.ResultCode,
                ResultMessage = successMessage
            };
        }
        public static DateTimeResult GetSingleSuccessfulResult(DateTime obj)
        {
            return new DateTimeResult()
            {
                ObjList = new List<DateTime>() { obj },
                TotalCount = GeneralResultCode.Results_Cls.SingleResultTotalCount,
                ResultCode = GeneralResultCode.Results_Cls.ResultCode,
                ResultMessage = GeneralResultCode.Results_Cls.ResultMessage
            };
        }

        public static DateTimeResult GetSingleSuccessfulResult(DateTime obj, string successMessage)
        {
            return new DateTimeResult()
            {
                ObjList = new List<DateTime>() { obj },
                TotalCount = GeneralResultCode.Results_Cls.SingleResultTotalCount,
                ResultCode = GeneralResultCode.Results_Cls.ResultCode,
                ResultMessage = successMessage
            };
        }

        public static DateTimeResult GetFailResult(Exception ex)
        {
            BusinessException exc = BusinessException.TryParseAndTranslate(ex);
            return new DateTimeResult()
            {
                ObjList = null,
                // TotalCount = GeneralResultCode.Results_Cls.FailResultTotalCount(),
                ResultCode = exc.Code,
                ResultMessage = exc.Message
            };
        }
    }
}
