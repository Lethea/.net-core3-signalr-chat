using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalRTuts.Model
{
    public class User
    {
        public string Name { get; set; }
        public string Room { get; set; }

        public string ConnectionId { get; set; }
    }
}
