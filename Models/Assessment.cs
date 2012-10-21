using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloSLC.Models
{
    public class Assessment
    {
        public string id { get; set; }
        public string title { get; set; }
        public string subject { get; set; }
        public string category { get; set; }
        public string description { get; set; }
        public string score { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
        public string icon { get; set; }
    }
}
