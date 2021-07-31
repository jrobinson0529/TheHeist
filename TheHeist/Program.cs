using System;
using System.Collections.Generic;
using TheHeist.Banks;
using TheHeist.TeamMembers;

namespace TheHeist
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("--+=>Plan Your Heist<=+--");
            var bankDifficultyInput = true;
            int userInput = 0;
            while (bankDifficultyInput)
            {
                Console.WriteLine("Enter bank difficulty level 10-125");
                userInput = Convert.ToInt32(Console.ReadLine());
                if (userInput < 10 || userInput > 125)
                {
                    Console.WriteLine("Invalid input");

                }
                else
                {
                    Console.WriteLine($"You chose {userInput} difficulty bank");
                    bankDifficultyInput = false;
                }


            }
            List<TeamMember> teamMembers = new List<TeamMember>();
            string userInputName = "";
            int skillLevel = 0;
            decimal courageFactor = 0;
            var invalidInput = true;
            var invalidInputTwo = true;
            Console.WriteLine("Enter a name.");
            userInputName = Console.ReadLine();
            while (invalidInput)
            {
                Console.WriteLine("Enter a skill level. (1-25)");
                var userInputSkill = Console.ReadLine();
                skillLevel = Convert.ToInt32(userInputSkill);
                if (skillLevel < 1 || skillLevel > 25)
                {
                    Console.WriteLine("Invalid skill input please choose an integer between 1 and 25.");

                }
                else invalidInput = false;

            }
            while (invalidInputTwo)
            {
                Console.WriteLine("Enter a courage factor. (0.0-2.0)");
                var userInputCourage = Console.ReadLine();
                courageFactor = Convert.ToDecimal(userInputCourage);
                if (courageFactor < 0 || courageFactor > 2)
                {
                    Console.WriteLine("Invalid courage input please choose a decimal between 0 and 2.0");
                    invalidInputTwo = true;
                }
                else invalidInputTwo = false;
            }
            var teamMember = new TeamMember(userInputName, skillLevel, courageFactor);
            teamMembers.Add(teamMember);
            while (userInputName != "")
            {
                invalidInput = true;
                invalidInputTwo = true;
                Console.WriteLine("Enter another name.");
                userInputName = Console.ReadLine();
                if (userInputName != "")
                {
                    while (invalidInput)
                    {
                        Console.WriteLine("Enter a skill level. (1-25)");
                        var userInputSkill = Console.ReadLine();
                        skillLevel = Convert.ToInt32(userInputSkill);
                        if (skillLevel < 1 || skillLevel > 25)
                        {
                            Console.WriteLine("Invalid skill input please choose an integer between 1 and 25.");

                        }
                        else invalidInput = false;

                    }
                    while (invalidInputTwo)
                    {
                        Console.WriteLine("Enter a courage factor. (0.0-2.0)");
                        var userInputCourage = Console.ReadLine();
                        courageFactor = Convert.ToDecimal(userInputCourage);
                        if (courageFactor < 0 || courageFactor > 2)
                        {
                            Console.WriteLine("Invalid courage input please choose a decimal between 0 and 2.0");
                            invalidInputTwo = true;
                        }
                        else invalidInputTwo = false;
                    }
                    teamMember = new TeamMember(userInputName, skillLevel, courageFactor);
                    teamMembers.Add(teamMember);
                }
               
            }
            var teamSize = teamMembers.Count;
            var skillTotal = 0;
            foreach (TeamMember member in teamMembers)
            {
                skillTotal += member.SkillLevel;
            }
            Console.WriteLine($"You have assembled a team of {teamSize} people with a total skill level of {skillTotal}");
            Console.WriteLine("How many trial runs would you like to run?");
            var userInputTrialRuns = Console.ReadLine();
            int trialRuns = Convert.ToInt32(userInputTrialRuns);
            var bank = new Bank(userInput);
            bank.RobberyAttempt(teamMembers, trialRuns);
        }
    }
}
