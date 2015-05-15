using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterGenV0._1
{
    public class PlayerClass
    {
        protected string name = "", hitDie;
        protected int startHP;
        protected string[] proficiencies;
        protected string[] skills;
        protected string[] savingThrows;
        protected List<Trait> classTraits;

        // Playerclasses must have methods to initialise class variables
        // Use the methods in the constructors of the child class
        protected virtual void createSkills(){}
        protected virtual void createThrows(){}
        protected virtual void createProficiencies(){}
        protected virtual void createClassTraits(){}

        
        public string getHitDie() { return hitDie; }
        public int getStartHp() { return startHP; }
        public string[] getProficiencies() { return proficiencies; }
        public string[] getSkills() { return skills; }
        public string[] getSavingThrows() { return savingThrows; }
        public List<Trait> getClassTraits() { return classTraits; }
        public override string ToString()
        {
            return name;
        }
    }
}
