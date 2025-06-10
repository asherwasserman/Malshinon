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
                People person = new People();
                person{id = reader.GetInt32("id");
                
            }       
        }
    }
}
