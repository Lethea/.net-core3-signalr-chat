using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalRTuts.Model
{
    public class ResponseMessage
    {
        public string Type { get; set; }
        public object Data { get; set; }
    }
}