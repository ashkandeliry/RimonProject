using System;
using System.Collections.Generic;
using System.Text;

namespace SharedMethodsLib.Results.GeneralTypes
{
    public class StringResult : MasterResult<string>
    {
        public static StringResult GetListSuccessfulResult(List<string> list, int totalCount)
        {
            return new StringResult()
            {
                ObjList = list,
                TotalCount = totalCount,
                ResultCode = GeneralResultCode.Results_Cls.ResultCode,
                ResultMessage = GeneralResultCode.Results_Cls.ResultMessage
            };
        }
        public static StringResult GetListSuccessfulResult(List<string> list, int totalCount, string ResultMessage)
        {
            return new StringResult()
            {
                ObjList = list,
                TotalCount = totalCount,
                ResultCode = GeneralResultCode.Results_Cls.ResultCode,
                ResultMessage = ResultMessage

            };
        }


        public static StringResult GetSingleSuccessfulResult(string obj, short? key, short? Status)
        {
            return new StringResult()
            {
                ObjList = new List<string>() { obj },
                TotalCount = GeneralResultCode.Results_Cls.SingleResultTotalCount,
                ResultCode = GeneralResultCode.Results_Cls.ResultCode,
                ResultMessage = GeneralResultCode.Results_Cls.ResultMessage,
                Key = key,
                Status = Status
            };
        }
        public static StringResult GetSingleSuccessfulResult(string obj)
        {
            return new StringResult()
            {
                ObjList = new List<string>() { obj },
                TotalCount = GeneralResultCode.Results_Cls.SingleResultTotalCount,
                ResultCode = GeneralResultCode.Results_Cls.ResultCode,
                ResultMessage = GeneralResultCode.Results_Cls.ResultMessage

            };
        }

        public static StringResult GetSingleSuccessfulResult(string obj, string ResultMessage)
        {
            return new StringResult()
            {
                ObjList = new List<string>() { obj },
                TotalCount = GeneralResultCode.Results_Cls.SingleResultTotalCount,
                ResultCode = GeneralResultCode.Results_Cls.ResultCode,
                ResultMessage = ResultMessage
            };
        }

        public static StringResult GetFailResult(Exception ex)
        {
            BusinessException exc = BusinessException.TryParseAndTranslate(ex);
            return new StringResult()
            {
                ObjList = null,
                TotalCount = GeneralResultCode.Results_Cls.FailResultTotalCount,
                ResultCode = exc.Code,
                ResultMessage = exc.Message
            };
        }
    }
}
