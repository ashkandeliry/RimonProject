using System;
using System.Collections.Generic;

#nullable disable

namespace Rimon_Main.Model
{
    public partial class HandledErrorLog
    {
        public long Id { get; set; }
        public string ServiceName { get; set; }
        public string ServiceMethodName { get; set; }
        public string ServiceParameters { get; set; }
        public DateTime? CreateDateTime { get; set; }
        public string InnerMethodName { get; set; }
        public int? ErrorCode { get; set; }
        public string ErrorMessage { get; set; }
        public string InnerClassName { get; set; }
        public string InnerParameters { get; set; }
        public int? LogMethodId { get; set; }
    }
}
