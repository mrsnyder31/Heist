using System;
using System.Collections.Generic;

namespace Heist
{
    class Program
    {
        static void Main(string[] args)
        {

            List<Member> HeistCrew = new List<Member>();

            Console.WriteLine("Plan Your Heist!");
        start:
            Console.WriteLine("How tight is the security at the target bank?");
            Console.WriteLine(@"
1) None
2) Light
3) Heavy");
            int ExtraSecurity = int.Parse(Console.ReadLine());
            if (ExtraSecurity == 1 || ExtraSecurity == 2 || ExtraSecurity == 3)
            {
                goto another;
            }
            else
            {
                Console.WriteLine("Go back and scope out the security of the bank.");
                goto start;
            }

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
            Console.WriteLine("------------");
            Console.WriteLine("");

            Member member = new Member(name, skill, courage);
            HeistCrew.Add(member);

            Console.WriteLine("");
            Console.WriteLine("Do you need another member? (Yes/No)");
            string answer = Console.ReadLine().ToLower();
            if (answer == "yes")
            {
                goto another;
            }
            else
            {
                Console.WriteLine("");
                Console.WriteLine("------------");
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
            Console.WriteLine("");

            Console.WriteLine("It's time to prepare. How many trial runs would you like to do? (0-5)");
            int TrialRuns = int.Parse(Console.ReadLine());
            Console.WriteLine("");

            int Success = 0;
            int Failed = 0;

            while (TrialRuns > 0)
            {
                Random r = new Random();
                int Luck = r.Next(-10, 10);


                int BankSecurity = 100;
                BankSecurity += Luck;

                if (ExtraSecurity == 1)
                {
                    BankSecurity += 0;
                }
                else if (ExtraSecurity == 2)
                {
                    BankSecurity += 100;
                }
                else
                {
                    BankSecurity += 150;
                }


                int CrewSkill = 0;

                foreach (var crewMem in HeistCrew)
                {
                    CrewSkill += crewMem.SkillLevel;
                }

                Console.WriteLine($"The bank's security level is {BankSecurity}, and you crew has {CrewSkill} skill.");

                if (CrewSkill >= BankSecurity)
                {
                    Console.WriteLine("The heist was a success! You made a clean getaway.");
                    Console.WriteLine("");
                    TrialRuns--;
                    Success++;
                }
                else
                {
                    Console.WriteLine($"{HeistCrew[0].Name} tripped the alarm! You were all arrested.");
                    Console.WriteLine("");
                    TrialRuns--;
                    Failed++;
                }
            }

            Console.WriteLine("------------");
            Console.WriteLine("Would you still like to go through with the heist? (Yes/No)");
            string LetsGo = Console.ReadLine().ToLower();
            if (LetsGo == "yes")
            {
                Random r = new Random();
                int Luck = r.Next(-10, 10);

                int BankSecurity = 100;
                BankSecurity += Luck;

                if (ExtraSecurity == 1)
                {
                    BankSecurity += 0;
                }
                else if (ExtraSecurity == 2)
                {
                    BankSecurity += 100;
                }
                else
                {
                    BankSecurity += 150;
                }

                int CrewSkill = 0;

                foreach (var crewMem in HeistCrew)
                {
                    CrewSkill += crewMem.SkillLevel;
                }

                Console.WriteLine("");
                Console.WriteLine($"The bank's security level is {BankSecurity}, and you crew has {CrewSkill} skill.");

                if (CrewSkill >= BankSecurity)
                {
                    Console.WriteLine("The heist was a success! You made a clean getaway.");
                    Success++;
                }
                else
                {
                    Console.WriteLine($"{HeistCrew[0].Name} tripped the alarm! You were all arrested.");
                    Failed++;
                }

            }
            else
            {
                Console.WriteLine("------------");
                Console.WriteLine($"That's probably a good decision. Better luck planning next time.");
            }

            Console.WriteLine("");
            Console.WriteLine(@$"Heist Report:
Succesful Runs: {Success} 
Failed Runs: {Failed} ");

        }
    }
}
