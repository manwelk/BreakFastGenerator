using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterGenV0._1
{
    public class Trait
    {
        private string name, description; 
        private Boolean isSpell = false;

        public Trait(string name) { this.name = name; this.description = "No description given."; }
        public Trait(string name, string description) { this.name = name; this.description = description; }
        public Trait(string name, string description, Boolean isSpell) { this.name = name; this.description = description; this.isSpell = isSpell; }

        public void setDescription(string description) { this.description = description; }
        public string getDescription() { return this.description; }
        public string getName() { return this.name; }


        public override string ToString()
        {
            return name + " - " + description;
        }
    }

}
