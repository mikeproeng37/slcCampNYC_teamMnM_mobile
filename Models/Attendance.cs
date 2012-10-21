using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloSLC.Models
{
    public class Attendance
    {
        public string id { get; set; }
        public DateTime date { get; set; }
        public string eventType { get; set; }
        public string reason { get; set; }
    }
}
