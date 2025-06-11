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
                secertCODE = secertCode,
                firstName = FirstName,
                lastName = LastName,
                type = "reporter",
                numReports = 1
            };
            People newInsertPeople = new People();
            newInsertPeople =  peopledal.Create(person);

            return newInsertPeople;
        }

        public void UpdateTypeReporter(People person)
        {
            if (person.type == "target")
            {
                person.type = "both";
            }
            peopledal.UpdateReportById(person);
        }

        public void UpdateNumReport(People person)
        {
            person.numReports++;
            peopledal.UpdateReportById(person);
        }

        public People CreateTarget(string SecertCode)
        {           
            Console.WriteLine("please enter the targets first name: ");
            string FirstName = Console.ReadLine()!;

            Console.WriteLine("please enter the targets last name: ");
            string LastName = Console.ReadLine()!;

            People person = new People()
            {
                secertCODE = SecertCode,
                firstName = FirstName,
                lastName = LastName,
                type = "target",
                numMentions = 1
            };
            People newInsertPeople = new People();
            newInsertPeople = peopledal.Create(person);

            return newInsertPeople;
        }

        public void UpdateTypetarget(People person)
        {
            if (person.type == "reporter" || person.type == "potential agent" )
            {
                person.type = "both";
            }
            peopledal.UpdateReportById(person);
        }

        public void UpdateNumtarget(People person)
        {
            person.numMentions++;
            peopledal.UpdateReportById(person);
        }

        public People GetPeople(string secertCode)
        {
            People person = new People();
            person = peopledal.GetPeopleBySecertCode(secertCode);
            return person;            
        }
    }
}
