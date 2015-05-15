using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterGenV0._1
{
    public class Hill_Dwarf : Dwarf
    {
        public Hill_Dwarf() 
        {
            base.name = "Hill Dwarf";
            updateMod();
            addSubTraits();
        }

        protected override void updateMod()
        {
            base.statMod["Constitution"] = 2;
            base.statMod["Wisdom"] = 1;
        }

        private void addSubTraits()
        {
            raceTraits.Add(new Trait("Dwarven Toughness", "Your hit point maximum increases by 1, and it increases by 1 every time you gain a level."));
        }
    }
}
