using System;
using System.Collections.Generic;
using System.Text;

namespace SharedMethodsLib.Results.GeneralTypes
{
    public class DynamicResult<T>
    {
        public int Code { get; set; }
        public string Message { get; set; }
        public T ObjList { get; set; }
    }
}
