﻿using System;
using System.Collections.Generic;

namespace Heist
{
    class Program
    {
        static void Main(string[] args)
        {

            List<Member> HeistCrew = new List<Member>();

            Console.WriteLine("Plan Your Heist!");

        another:
            Console.WriteLine("");
            Console.WriteLine("What is your team member's name?");
            string name = Console.ReadLine();

            Console.WriteLine($"What is {name}'s skill level? (1-100)");
            int skill = int.Parse(Console.ReadLine());

            Console.WriteLine($"How couragous is {name}? (0.0 - 2.0)");
            double courage = double.Parse(Console.ReadLine());

            Console.WriteLine(@$"
Name: {name},
Skill Level: {skill} 
Courage Factor: {courage}");

            Member member = new Member(name, skill, courage);
            HeistCrew.Add(member);

            Console.WriteLine("Do you need another member? (Yes/No)");
            string answer = Console.ReadLine().ToLower();
            if (answer == "yes")
            {
                goto another;
            }
            else
            {
                Console.WriteLine("------------");
                Console.Clear();
                Console.WriteLine($"You have {HeistCrew.Count} team member.");
            }

            //             foreach (var crewMem in HeistCrew)
            //             {
            //                 Console.WriteLine(@$"
            // Name: {crewMem.Name},
            // Skill Level: {crewMem.SkillLevel} 
            // Courage Factor: {crewMem.Courage}");
            //                 Console.WriteLine("-------------");
            //             }

            int BankSecurity = 100;

            int CrewSkill = 0;

            foreach (var crewMem in HeistCrew)
            {
                CrewSkill += crewMem.SkillLevel;
            }

            if (CrewSkill >= BankSecurity)
            {
                Console.WriteLine("The heist was a success! You made a clean getaway.");
            }
            else
            {
                Console.WriteLine($"{HeistCrew[0].Name} tripped the alarm! You were all arrested.");
            }

        }
    }
}
