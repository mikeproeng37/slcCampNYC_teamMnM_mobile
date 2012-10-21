using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloSLC.Models
{
    public class Event
    {
        public static string FIELDTRIP = "FIELDTRIP";
        public static string SCHOOLPLAY = "SCHOOLPLAY";
        public static string SCHOOLCONFERENCE = "SCHOOLCONFERENCE";

        public string id { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public DateTime date { get; set; }
        public string type { get; set; }
        public string map { get; set; }
    }
}
