using MySql.Data.MySqlClient;
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
        MySQLData mySQL = new MySQLData();

        public void create(IntelReports intelReport)
        {           
            try
            {
                int reportId = intelReport.reporterId;
                int targetId = intelReport.targetId;
                string intelText = intelReport.intelText;
                DateTime timeStemp = intelReport.timeStemp;
                string query = $"INSERT INTO intel_reports ( report_id, target_id, intel_text, time_stemp)" +
                    $" VALUES ('{reportId}','{targetId}','{intelText}','{timeStemp}')";
                mySQL.GetConnection();
                MySqlCommand cmd = new MySqlCommand(query);
                cmd.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"Query error: {ex.Message}");
            }
            finally
            {
                mySQL.CloseConnection();
            }

        }
    }
}
