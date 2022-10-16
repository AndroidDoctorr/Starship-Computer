using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Computer
{
    public class SystemResponse
    {
        public int Code { get; set; }
        public string Message { get; set; }
        public string Source { get; set; }
        public Dictionary<string, object> Data { get; set; } = new Dictionary<string, object>();
    }
}
