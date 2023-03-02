using System;

namespace Heist
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Plan Your Heist!");

            Console.WriteLine("What is in your team member's name?");
            string name = Console.ReadLine();

            Console.WriteLine($"What is {name}'s skill level? (1-10)");
            int skill = int.Parse(Console.ReadLine());

            Console.WriteLine($"How couragous is {name}? (0.0 - 2.0)");
            double courage = double.Parse(Console.ReadLine());

            Console.WriteLine(@$"
Name: {name},
Skill Level: {skill} 
Courage Factor: {courage}");
        }
    }
}
