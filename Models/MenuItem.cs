using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloSLC.Models
{
    /// <summary>
    /// Represents a clickable item on the left hand menu
    /// </summary>
    public class MenuItem
    {
        public string Title {get;set;}
        public string Icon { get; set; }
        public string Target { get; set; }

        // default constructor
        public MenuItem()
        {
        }
    }
}
