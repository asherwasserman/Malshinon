using Malshinon.models;
using Org.BouncyCastle.Asn1.X509.SigI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Malshinon.controler
{
    public class PeopleControler
    {
        private PeopleDal peopledal = new PeopleDal();
        
        public People CreateReporter(string secertCode)
        {
            string SecertCode = secertCode; 
            
            Console.WriteLine("please enter your first name: ");

            string FirstName  = Console.ReadLine()!;

            Console.WriteLine("please enter your last name: ");
            string LastName = Console.ReadLine()!;

            People person = new People()
            {
                firstName = FirstName,
                lastName = LastName,
                type = "reporter",
                numReports = 1
            };
            People newInsertPeople = new People();
            newInsertPeople =  peopledal.Create(person);

            return newInsertPeople;
        }

        public void UpdateType(People person)
        {
            if (person.type == "target")
            {
                person.type = "both";
            }
        }

        public void UpdateNumReport(People person)
        {
            person.numReports++;   
        }
    }
}
