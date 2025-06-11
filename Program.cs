using Malshinon.models;
using System.Reflection.PortableExecutable;
namespace Malshinon
{
    class program
    {
        static void Main()
        {
            //People person = new People()
            //{
            //    firstName = "hVH",
            //    lastName = "jzbi",
            //    secertCODE = "bnjnk",
            //    type = "both",
            //    numReports = 5,
            //    numMentions = 6
            //};
            PeopleDal people = new PeopleDal();
            People newPerson = new People();
            //newPerson =  people.Create(person);
            //Console.WriteLine(newPerson.id);

            //people.UpdateReportById(2, 2);
            //Console.WriteLine(person.type);
            newPerson = people.GetPeopleById(5);
            Console.WriteLine(newPerson.firstName);
        }
    }
}
