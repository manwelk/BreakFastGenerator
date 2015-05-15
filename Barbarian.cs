using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterGenV0._1
{
    public class Barbarian : PlayerClass
    {
        public Barbarian() 
        {
            base.name = "Barbarian";
            base.hitDie = "d12";
            base.startHP = 12;
            createSkills();
            createClassTraits();
            createThrows();
            createProficiencies();

        }
        protected override void createSkills() 
        {
            base.skills = new string[6] { "Animal Handling", "Athletics", "Intimidation", "Nature", 
                "Perception", "Survival"};
        }
        protected override void createThrows() 
        {
            base.savingThrows = new string[2] {"Strength", "Constitution" };
        }
        protected override void createProficiencies() 
        {
            base.proficiencies = new string[5] { "Light armor", "Medium armor", "Shields", "Simple weapons", "Martial weapons"  };
        }
        protected override void createClassTraits() 
        {
            base.classTraits = new List<Trait>();
            base.classTraits.Add(new Trait("Rage", "In battle, you fight with primal ferocity. On your turn, you can enter a rage as a bonus action.", true));
            base.classTraits.Add(new Trait("Unarmored Defense", "While you are not wearing any armor, your Armor Class equals 10 + your Dexterity modifier + your Constitution modifier."));
        }
    }
}
