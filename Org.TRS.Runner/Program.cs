using System;
using Org.TRS.Domains.Logic;
using Org.TRS.Domains.Model;
using Org.TRS.Domains.Utilities;

namespace Org.TRS.Runner
{
    class Program
    {
        static void Main(string[] args)
        {
            var state = new StateDefault(new Table());
            var robot = new Robot(state);
            var controller = new Controller(robot);

            Console.WriteLine("Any time type \"quit\" to exit.");
            Console.WriteLine("Please input command:");
            string command;
            while (!(command = Console.ReadLine()).AllEqual("quit"))
            {
                try
                {
                    var result = controller.Accept(command);
                    if (!string.IsNullOrEmpty(result))
                        Console.WriteLine(result);
                }
                catch (Exception)
                {
                    Console.WriteLine("Invalid command.");
                }
                Console.WriteLine("Please input command:");
            }
        }
    }
}
