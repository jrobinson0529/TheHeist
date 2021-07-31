using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheHeist.TeamMembers;

namespace TheHeist.Banks
{
    class Bank
    {
        public string Name { get; set; } = "Bank";
        public int DifficultyLevel { get; set; } = 75;
        public Bank(int difficulty)
        {
            DifficultyLevel = difficulty;
            if (DifficultyLevel < 50) Name = "ezclap bank";
            if (DifficultyLevel < 100 && DifficultyLevel >= 50) Name = "Average Bank";
            if (DifficultyLevel >= 100) Name = "Tough Bank";
        }
        public void RobberyAttempt(List<TeamMember> team, int trialRuns)
        {
            var rnd = new Random();
            
            int teamSkillTotal = 0;
            foreach (var member in team)
            {
                teamSkillTotal += member.SkillLevel;
            }
           
            Console.WriteLine($"The team will run {trialRuns} runs");
            double successfulRuns = 0;
            double failedRuns = 0;
            for (var i = 0; i < trialRuns; i++)
            {
                var difficulty = DifficultyLevel;
                var luckValue = rnd.Next(-10, 10);
                difficulty += luckValue;
                Console.WriteLine($"The team has {teamSkillTotal} total skill versus {Name} with a difficulty of {difficulty}.");
                if (teamSkillTotal >= difficulty)
                {
                    Console.WriteLine($"The team succesfully stole money from the bank.");
                    successfulRuns++;
                    
                }
                else
                {
                    Console.WriteLine($"The team was caught and is now serving time.");
                    failedRuns++;
                }
                
            }
            double percentageNumber = (successfulRuns / trialRuns);
            var percentage = percentageNumber.ToString("P", CultureInfo.InvariantCulture);
            Console.WriteLine($"The heist had {successfulRuns} successful runs and {failedRuns} failed runs out of {trialRuns} runs");
            Console.WriteLine($"Your teams success rate was {percentage}!");
            Console.ReadKey();
        
        }
    } 
}
