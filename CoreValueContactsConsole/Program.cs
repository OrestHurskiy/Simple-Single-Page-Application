using CoreValueContacts.Domain.Entities.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreValueContactsConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = new EntitiesContext();
            var test = context.Roles.ToList();
            var projects = context.Projects.ToList();
            Console.WriteLine("Done :");
        }
    }
}
