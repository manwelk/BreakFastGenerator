using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterGenV0._1
{
    public class Race
    {
        protected string name;
        protected int speed, numOfLang;
        protected Dictionary<string, int> statMod;
        protected Boolean subRace;
        protected List<Trait> raceTraits;

        public Race() 
        {
            initStatMod();
        }


        public int getSpeed() { return this.speed; }

        // fills statMod with modifiers of 0 to the related stat
        // stat name is the key and the value is the statmodifier
        protected virtual void initStatMod()
        {
            statMod = new Dictionary<string, int>();
            statMod.Add("Strength", 0);
            statMod.Add("Dexterity", 0);
            statMod.Add("Constitution", 0);
            statMod.Add("Intelligence", 0);
            statMod.Add("Wisdom", 0);
            statMod.Add("Charisma", 0);
        }

        // races need to update the modifer dictionary with their related stat modifiers
        // call this method in the constructor
        protected virtual void updateMod() { }

        public Dictionary<string, int> getStatMod() { return statMod; }

        public Boolean hasSubRace() { return this.subRace; }
        public virtual string[] subRaces() { return null; }
        public virtual Race createSubRace(string race) { return null; }
        public override string ToString()
        {
            //string info = "Stats Modifiers: ";
            //foreach (var mod in statMod) { info += " " + statMod; }
            //return info;
            return this.name;
        }
    }
}
