using System;
using System.Collections.Generic;
using System.Text;

namespace SharedMethodsLib.Results.GeneralTypes
{
    public class FileResult : MasterResult<byte[]>
    {
        public static FileResult GetListSuccessfulResult(List<byte[]> list, int totalCount)
        {
            return new FileResult()
            {
                ObjList = list,
                TotalCount = totalCount,
                ResultCode = GeneralResultCode.Results_Cls.ResultCode,
                ResultMessage = GeneralResultCode.Results_Cls.ResultMessage
            };
        }
        public static FileResult GetListSuccessfulResult(List<byte[]> list, int totalCount, string successMessage)
        {
            return new FileResult()
            {
                ObjList = list,
                TotalCount = totalCount,
                ResultCode = GeneralResultCode.Results_Cls.ResultCode,
                ResultMessage = GeneralResultCode.Results_Cls.ResultMessage
            };
        }
        public static FileResult GetSingleSuccessfulResult(byte[] obj)
        {
            return new FileResult()
            {
                ObjList = new List<byte[]>() { obj },
                TotalCount = GeneralResultCode.Results_Cls.SingleResultTotalCount,
                ResultCode = GeneralResultCode.Results_Cls.ResultCode,
                ResultMessage = GeneralResultCode.Results_Cls.ResultMessage
            };
        }

        public static FileResult GetSingleSuccessfulResult(byte[] obj, string successMessage)
        {
            return new FileResult()
            {
                ObjList = new List<byte[]>() { obj },
                TotalCount = GeneralResultCode.Results_Cls.SingleResultTotalCount,
                ResultCode = GeneralResultCode.Results_Cls.ResultCode,
                ResultMessage = GeneralResultCode.Results_Cls.ResultMessage
            };
        }

        public static FileResult GetFailResult(Exception ex)
        {
            BusinessException exc = BusinessException.TryParseAndTranslate(ex);
            return new FileResult()
            {
                ObjList = null,
                // TotalCount = GeneralResultCode.Results_ClsFailResultTotalCount(),
                ResultCode = exc.Code,
                ResultMessage = exc.Message
            };
        }
    }
}
