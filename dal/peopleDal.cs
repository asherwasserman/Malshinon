using MySqlX.XDevAPI.CRUD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Malshinon.models;
using MySql.Data.MySqlClient;
using System.Security.Cryptography.X509Certificates;
using Mysqlx.Crud;

namespace Malshinon.models
{
    public class PeopleDal
    {
        private MySQLData mySqlData = new MySQLData();
        public People Create(People person)
        {
            string firstName = person.firstName;
            string lastName = person.lastName;
            string secertCode = person.secertCODE;
            string type = person.type;
            int numReports = person.numReports;
            int numMentions = person.numMentions;
            string query = $"INSERT INTO people(first_name, last_name, secert_code, type, num_reports, num_mentions) " +
               $"VALUES('{firstName}', '{lastName}',  '{secertCode}', '{type}', '{numReports}', '{numMentions}');" +
               $"  SELECT * FROM people WHERE people.id = LAST_INSERT_ID()";
            MySqlCommand cmd;
            try
            {   
                mySqlData.GetConnection();
                cmd = new MySqlCommand(query, mySqlData.conn);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    person = CreateFromReader(reader);
                    Console.WriteLine(person.id);
                    return person;
                }
                
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"Query error: {ex.Message}");
            }
            finally
            {
                mySqlData.CloseConnection();
            }
            return null;
        }

        private People GetPerson(string query)
        {
            try
            {
                mySqlData.GetConnection();
                MySqlCommand cmd = new MySqlCommand(query, mySqlData.conn);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    
                People person = CreateFromReader(reader);
                return person;
                }
                return null;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex);
                Console.WriteLine($"query error: {ex.Message}");
                return null;
            }
            finally
            {
                mySqlData.CloseConnection();
            }
           
        }

        private void update(string query)
        {
            try
            {
                mySqlData.GetConnection();
                MySqlCommand cmd = new MySqlCommand(query, mySqlData.conn);
                cmd.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"Query error: {ex.Message}");
            }
            finally
            {
                mySqlData.CloseConnection();
            }
        }
        
        public People GetPeopleBySecertCode(string secertCode)
        {
            string query = $"SELECT * FROM people WHERE people.secert_code = '{secertCode}';";
            People person;
            person = GetPerson(query);
            return person;
        }

        public People GetPeopleById(int id)
        {
            string query = $"SELECT * FROM people WHERE people.id = '{id}';";
            People person;
            person = GetPerson(query);
            return person;
        }

        public void UpdateReportById(People person , int num)
        {
            string query = $"UPDATE people SET people.num_reports = '{num}'" +
                $", people.num_mentioms = '{person.numMentions}'" +
                $",people.type = '{person.type} WHERE people.id = '{person.id}'";
            update(query);
        }

        public static People CreateFromReader (MySqlDataReader reader)
        {
            //reader.Read();
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

            return person;
        }

    }
}
