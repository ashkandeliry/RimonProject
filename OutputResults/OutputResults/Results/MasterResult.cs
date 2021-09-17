using System;
using System.Collections.Generic;
using System.Text;

namespace SharedMethodsLib.Results
{
    public class MasterResult<T>
    {
        public int ResultCode { get; set; }
        public string ResultMessage { get; set; }
        public int TotalCount { get; set; }
        public List<T> ObjList { get; set; }
        public T Obj { get; set; }
        public short? Key { get; set; }
        public short? Status { get; set; }
    }
}
