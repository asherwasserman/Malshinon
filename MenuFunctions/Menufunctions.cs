using Malshinon.controler;
using Malshinon.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Malshinon.Models
{
    public static class MenuFunctions
    {
        private static PeopleControler pc = new PeopleControler();
        private static IntelReportsControler Irc = new IntelReportsControler();

        public static void showMenu()
        {
            Boolean run = true;
            while (run)
            {
                Console.WriteLine(
                    "Welcome to the Intelligence Reporting System!" +
                    " \nPlease select one of the following options: " +
                    "\n \n1.Report important information" +
                    " \n2.Logout");
                string choice = Console.ReadLine()!;
                switch (choice)
                {
                    case "1":
                        AddingIntelReportBySecertCode();
                        break;
                    case "2":
                        run = false;
                        break;
                }
            }
        }
        public static void AddingIntelReportBySecertCode()
        {
            string secertCode = logIn();

            People person = new People();
            person = pc.GetPeople(secertCode);
            if (person == null)
            {
                person = pc.CreateReporter(secertCode);
            }
            else
            {
                pc.UpdateNumReport(person);
                pc.UpdateTypeReporter(person);
            }

            string TargetSecretCode = EnterTarget();
            People target = new People();
            target = pc.GetPeople(TargetSecretCode);
            if (target == null)
            {
                target = pc.CreateTarget(TargetSecretCode);
            }
            else
            {
                pc.UpdateNumtarget(target);
                pc.UpdateTypetarget(target);
            }
            Irc.create(person.id, target.id);

        }

        public static string logIn()
        {
            Console.WriteLine("please enter your secret code: ");
            string secertCode = Console.ReadLine()!;
            return secertCode;
        }

        public static string EnterTarget()
        {
            Console.WriteLine("please enter the targets secret code: ");
            string secertCode = Console.ReadLine()!;
            return secertCode;
        }
    }
}
