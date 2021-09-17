using System;
using System.Collections.Generic;
using System.Text;

namespace SharedMethodsLib.Results.GeneralTypes
{
    public class BoolResult : MasterResult<bool>
    {
        public static BoolResult GetListSuccessfulResult(List<bool> list, int totalCount)
        {
            return new BoolResult()
            {
                ObjList = list,
                TotalCount = totalCount,
                ResultCode = GeneralResultCode.Results_Cls.ResultCode,
                ResultMessage = GeneralResultCode.Results_Cls.ResultMessage
            };
        }
        public static BoolResult GetListSuccessfulResult(List<bool> list, int totalCount, string successMessage)
        {
            return new BoolResult()
            {
                ObjList = list,
                TotalCount = totalCount,
                ResultCode = GeneralResultCode.Results_Cls.ResultCode,
                ResultMessage = successMessage
            };
        }
        public static BoolResult GetSingleSuccessfulResult(bool obj)
        {
            return new BoolResult()
            {
                ObjList = new List<bool>() { obj },
                TotalCount = GeneralResultCode.Results_Cls.SingleResultTotalCount,
                ResultCode = GeneralResultCode.Results_Cls.ResultCode,
                ResultMessage = GeneralResultCode.Results_Cls.ResultMessage
            };
        }

        public static BoolResult GetSingleSuccessfulResult(bool obj, string successMessage)
        {
            return new BoolResult()
            {
                ObjList = new List<bool>() { obj },
                TotalCount = GeneralResultCode.Results_Cls.SingleResultTotalCount,
                ResultCode = GeneralResultCode.Results_Cls.ResultCode,
                ResultMessage = successMessage
            };
        }

        public static BoolResult GetFailResult(Exception ex)
        {
            BusinessException exc = BusinessException.TryParseAndTranslate(ex);
            return new BoolResult()
            {
                ObjList = null,
                // TotalCount = GeneralResultCode.Results_Cls.FailResultTotalCount(),
                ResultCode = exc.Code,
                ResultMessage = exc.Message
            };
        }
    }
}
