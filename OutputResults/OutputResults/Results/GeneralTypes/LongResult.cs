using System;
using System.Collections.Generic;
using System.Text;

namespace SharedMethodsLib.Results.GeneralTypes
{
    public class LongResult : MasterResult<long>
    {
        public static LongResult GetListSuccessfulResult(List<long> list, int totalCount)
        {
            return new LongResult()
            {
                ObjList = list,
                TotalCount = totalCount,
                ResultCode = GeneralResultCode.Results_Cls.ResultCode,
                ResultMessage = GeneralResultCode.Results_Cls.ResultMessage 
            };
        }
        public static LongResult GetListSuccessfulResult(List<long> list, int totalCount, string ResultMessage )
        {
            return new LongResult()
            {
                ObjList = list,
                TotalCount = totalCount,
                ResultCode = GeneralResultCode.Results_Cls.ResultCode,
                ResultMessage = ResultMessage 
            };
        }
        public static LongResult GetSingleSuccessfulResult(long obj)
        {
            return new LongResult()
            {
                ObjList = new List<long>() { obj },
                TotalCount = GeneralResultCode.Results_Cls.SingleResultTotalCount,
                ResultCode = GeneralResultCode.Results_Cls.ResultCode,
                ResultMessage = GeneralResultCode.Results_Cls.ResultMessage 
            };
        }
        public static LongResult GetSingleSuccessfulResult(long obj, string ResultMessage )
        {
            return new LongResult()
            {
                ObjList = new List<long>() { obj },
                TotalCount = GeneralResultCode.Results_Cls.SingleResultTotalCount,
                ResultCode = GeneralResultCode.Results_Cls.ResultCode,
                ResultMessage = ResultMessage 
            };
        }
        public static LongResult GetFailResult(Exception ex)
        {
            BusinessException exc = BusinessException.TryParseAndTranslate(ex);
            return new LongResult()
            {
                ObjList = null,
                // TotalCount = GeneralResultCode.Results_Cls.FailResultTotalCount(),
                ResultCode = exc.Code,
                ResultMessage = exc.Message
            };
        }
    }
}
