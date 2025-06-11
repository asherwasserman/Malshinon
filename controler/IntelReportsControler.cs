using Malshinon.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Malshinon.controler
{
    public class IntelReportsControler
    {
        private IntelReportDal inteldal = new IntelReportDal();
        public void create(int ReporterId, int TargetId)
        {
            Console.WriteLine("Please enter text: ");
            string text = Console.ReadLine()!;

            IntelReports intelReport = new IntelReports()
            {
                reporterId = ReporterId,
                targetId = TargetId,
                intelText = text
            };
            inteldal.create(intelReport);

        }
    }
}
