using MySql.Data.MySqlClient;
using Org.BouncyCastle.Asn1.Mozilla;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Malshinon.models
{
    public class MySQLData
    {
        public static string connectionString = "Server=localhost;Database=malshinon;User=root;password='';Port=3306";
        public MySqlConnection conn;

        public Boolean TryConnection()
        {
            try
            {
                conn = new MySqlConnection(connectionString);
                conn.Open();
                
                return true;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"Error connecting to MySQL database: {ex}");
                return false;
            }
        }
        public void GetConnection()
        {
            try
            {
                conn = new MySqlConnection(connectionString);

                conn.Open();
                
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"Error connecting to MySQL database: {ex.Message}");
            }
            
        }
        public void CloseConnection()
        {
            conn.Close();
        }
    }
}
