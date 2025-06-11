using Mysqlx.Crud;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Malshinon.models
{
    public class IntelReportDal
    {
        public void create(IntelReports intelReport)
        {
            int id = intelReport.id;
            int reportId = intelReport.reporterId;
            int targetId = intelReport.targetId;
            string intelText = intelReport.intelText;
            DateTime timeStemp = intelReport.timeStemp;

        }
    }
}
