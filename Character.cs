using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterGenV0._1
{
    public class Character
    {
        private string name;
        private int level, exp, age, height, armorClass, speed;
        private Dictionary<string, int> charStats;
        private Race race;
        private PlayerClass playerClass;

        public Character() { this.name = ""; initStats(); }
        public Character(string characterName) { this.name = characterName; initStats(); }
        public Character(string characterName, Race race, PlayerClass playerClass)
        {
            this.name = characterName;
            this.race = race;
            this.playerClass = playerClass;
            initStats();

        }

        private void initStats() 
        {
            charStats = new Dictionary<string,int>();
            charStats.Add("Strength" , 0);
            charStats.Add("Dexterity" , 0);
            charStats.Add("Constitution" , 0);
            charStats.Add("Intelligence" , 0);
            charStats.Add("Wisdom" , 0);
            charStats.Add("Charisma" , 0);
        }

        public void setStat(string stat, int value) 
        {
            if (charStats.ContainsKey(stat))
            {
                charStats[stat] = value;
            }
            else { throw new Exception("Selected stat does not exist"); }
                
              
            
        }

        // simulates rolling 4 d6 dice and keeping the top 3 results for an assigned stat
        // returns an array with the desired stats
        public int[] rollForStats() 
        {
            int[] stats = new int[6];
            int[] rolls = new int [4];
            Random rand = new Random();
            for(int i = 0; i<6; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    rolls[j] = rand.Next(1,7);
                    //Console.Write(rolls[j] + " ");
                }
                Array.Sort(rolls); //sorts rolls from lowest to highest
                //Console.Write("Rolls: "); foreach (int num in rolls) { Console.Write(num + " "); } Console.WriteLine();
                stats[i] = rolls[1] + rolls[2] + rolls[3]; //adds highest 3 values from the 4 rolls
                

            }
            return stats;
        }
      

        public string getName() { return this.name; }
        public void setRace(Race race) { this.race = race; }
        public Race getRace() { return this.race; }
        public void setClass(PlayerClass playerClass) { this.playerClass = playerClass; }
        public PlayerClass getClass() { return this.playerClass; }
        public void setName(string characterName) { this.name = characterName; }
        public Dictionary<string, int> getStats() { return charStats; }

        public override string ToString()
        {
            return "Character name: " + name + "\nRace: " + race.ToString() + "\nClass: " + playerClass.ToString() + "\n"; ;
        }
 
    }
}
