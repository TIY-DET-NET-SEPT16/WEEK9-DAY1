using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQReview
{
    class Program
    {
        static void Main(string[] args)
        {
            using (NORTHWNDEntities db = new NORTHWNDEntities())
            {
                var empWTerr = from e in db.Employees
                               select e;

                foreach (var emp in empWTerr)
                {
                    Console.WriteLine(emp.FirstName + " " + emp.LastName);
                    foreach (var terr in emp.Territories)
                    {
                        Console.WriteLine("\t" + terr.TerritoryDescription);
                    }
                }
            }
        }
    }
}
