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
            //    secertCODE = "bzjhxv",
            //    type = "both",
            //    numReports = 5,
            //    numMentions = 6
            //};
            peopleDal people = new peopleDal();
            //people.Create(person);
            People person = new People();
            people.UpdateReportById(2, 2);
            Console.WriteLine(person.type);
        }
    }
}
