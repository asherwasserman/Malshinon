using MySqlX.XDevAPI.CRUD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Malshinon.models;
using MySql.Data.MySqlClient;
using System.Security.Cryptography.X509Certificates;

namespace Malshinon.dal
{
    public class peopleDal
    {
        private MySQLData mySqlData = new MySQLData();
        public void Create(People person)
        {
            string firstName = person.firstName;
            string lastName = person.lastName;
            string secertCode = person.secertCODE;
            string type = person.type;
            int numReports = person.numReports;
            int numMentions = person.numMentions;
            string query = $"INSERT INTO people(first_name, last_name, secert_code, type, num_reports, num_mentions) " +
               $"VALUES('{firstName}', '{lastName}',  '{secertCode}', '{type}', '{numReports}', '{numMentions}');";
            MySqlCommand cmd = new MySqlCommand(query);
            try
            {
                mySqlData.GetConnection();
                cmd.ExecuteNonQuery();
                mySqlData.CloseConnection();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"Query error: {ex.Message}");
            }
        }

        public People GetPerson(int secertCode)
        {
            string query = $"SELECT * FROM people WHERE secert_code = {secertCode};";
            MySqlCommand cmd = new MySqlCommand(query);
            try
            {
                mySqlData.GetConnection();
                var reader = cmd.ExecuteReader();
                People person = new People
                {
                    id = reader.GetInt32("id"),
                    firstName = reader.GetString("first_name"),
                    lastName = reader.GetString("last_name"),
                    secertCODE = reader.GetString("secert_code"),
                    type = reader.GetString("type"),
                    numReports = reader.GetInt32("num_reports"),
                    numMentions = reader.GetInt32("num_mentions")
                };
                mySqlData.CloseConnection();
                return person;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"query error: {ex.Message}");
                return null;
            }
        }
    }
}
