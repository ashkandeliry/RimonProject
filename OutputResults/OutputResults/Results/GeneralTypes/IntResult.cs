using System;
using System.Collections.Generic;
using System.Text;

namespace SharedMethodsLib.Results.GeneralTypes
{
    public class IntResult : MasterResult<int>
    {
        public static IntResult GetListSuccessfulResult(List<int> list, int totalCount)
        {
            return new IntResult()
            {
                ObjList = list,
                TotalCount = totalCount,
                ResultCode = GeneralResultCode.Results_Cls.ResultCode,
                ResultMessage = GeneralResultCode.Results_Cls.ResultMessage
            };
        }
        public static IntResult GetListSuccessfulResult(List<int> list, int totalCount, string successMessage)
        {
            return new IntResult()
            {
                ObjList = list,
                TotalCount = totalCount,
                ResultCode = GeneralResultCode.Results_Cls.ResultCode,
                ResultMessage = successMessage
            };
        }
        public static IntResult GetSingleSuccessfulResult(int obj)
        {
            return new IntResult()
            {
                ObjList = new List<int>() { obj },
                TotalCount = GeneralResultCode.Results_Cls.SingleResultTotalCount,
                ResultCode = GeneralResultCode.Results_Cls.ResultCode,
                ResultMessage = GeneralResultCode.Results_Cls.ResultMessage
            };
        }

        public static IntResult GetSingleSuccessfulResult(int obj, string successMessage)
        {
            return new IntResult()
            {
                ObjList = new List<int>() { obj },
                TotalCount = GeneralResultCode.Results_Cls.SingleResultTotalCount,
                ResultCode = GeneralResultCode.Results_Cls.ResultCode,
                ResultMessage = successMessage
            };
        }

        public static IntResult GetFailResult(Exception ex)
        {
            BusinessException exc = BusinessException.TryParseAndTranslate(ex);
            return new IntResult()
            {
                ObjList = null,
                // TotalCount = General.Results_.FailResultTotalCount(),
                ResultCode = exc.Code,
                ResultMessage = exc.Message
            };
        }
    }
}
