using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Malshinon.models
{
    public class IntelReports
    {
        public int id { get; set; }
        public int reporterId { get; set; }
        public int targetId { get; set; }
        public string intelText { get; set; }
        public DateTime timeStemp {get; set; }
        
    }
}
