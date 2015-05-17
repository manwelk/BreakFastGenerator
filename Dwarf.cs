using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterGenV0._1
{
    public class Dwarf : Race
    {
        public Dwarf() 
        {
            base.name = "Dwarf";
            base.subRace = true; base.speed = 30; base.numOfLang = 2; 
            base.raceTraits = new List<Trait>();
            addTraits();
        }
        private void addTraits()
        {
            raceTraits.Add(new Trait("Darkvision", "You can see in dim light within 60 feet of you as if it were bright light, and in darkness as if it were dim light."));
            raceTraits.Add(new Trait("Dwarven Resilience", "You have advantage on saving throws against poison, and you have resistance against poison damage"));
            raceTraits.Add(new Trait("Dwarven Combat Training", "You have proficiency with the battleaxe, handaxe, throwing hammer, and warhammer."));
            raceTraits.Add(new Trait("Tool Proficiency"));
            raceTraits.Add(new Trait("Stonecunning", "Whenever you make an History check related to the origin of stonework, you are considered proficient in the History skill and add double your proficiency bonus to the check."));
        }

        public override string[] subRaces() 
        {
            string[] races = { "Hill Dwarf" , "Mountain Dwarf" };
            return races; 
        }

        public override Race createSubRace(string race) 
        {
            Race sub = new Race();
            if (race.Equals("Hill Dwarf"))
            {
                sub = new Hill_Dwarf();
            }
            else if (race.Equals("Mountain Dwarf"))
            {
                throw new Exception("Not yet implemented");
            }
            return sub; 
        }

        public List<Trait> getTraits() { return raceTraits; }
    }
}
