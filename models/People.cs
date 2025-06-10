using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Malshinon.models
{
    public class People
    {
        public int id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string secertCODE { get; set; }
        public string type { get; set; }
        public int numReports { get; set; }
        public int numMentions { get; set; }
    }
}
