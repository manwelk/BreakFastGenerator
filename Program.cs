using System;
using System.Linq;

namespace CharacterGenV0._1
{
    public class Program
    {
        //static string version = "v0.1";
        private static Character CHARACTER;
        private static int hor = 25, vert = 10; //vertical and horizontal spacing for the menus
        private static ConsoleColor back = ConsoleColor.Black, fore = ConsoleColor.White, //colors for the menus
            defaultBack = ConsoleColor.Black, defaultFore = ConsoleColor.White; //colors for the background and foreground(font)



        static void Main(string[] args)
        {
           
            splash();
            startMenu();
           
        }
        //debug stuff goes here
        private static void debug()
        {
            while (true)
            {
                splash();
                CHARACTER = new Character("test character");
                Race dwa = new Hill_Dwarf(); CHARACTER.setRace(dwa);
                //rollForStats();
                //inputStats();
                //chooseRace();
                splash();
                foreach (var stat in CHARACTER.getStats())
                {
                    Console.WriteLine(stat);
                }
                Console.WriteLine(CHARACTER.getRace().ToString());
                foreach (var mod in CHARACTER.getRace().getStatMod())
                {
                    Console.WriteLine(mod);
                }
                Console.WriteLine("Quit y/n?: ");
                if (Console.ReadLine().Equals("y") || Console.ReadLine().Equals("Y")) { break; }
            }
        }

        // clears screen and displays title
        static void splash() 
        {
            Console.BackgroundColor = defaultBack; Console.ForegroundColor = defaultFore;
            Console.Clear();
            Console.CursorVisible = false;
            Console.WriteLine(
@"  ___              _   ___        _      ___ _      _      ___       ___  
 | _ )_ _ ___ __ _| |_| __|_ _ __| |_   / __| |_  _| |__  |   \ _ _ |   \ 
 | _ \ '_/ -_) _` | / / _/ _` (_-<  _| | (__| | || | '_ \ | |) | ' \| |) |
 |___/_| \___\__,_|_\_\_|\__,_/__/\__|  \___|_|\_,_|_.__/ |___/|_||_|___/ 
                                                                          ");
            Console.WriteLine(@"  -----------------------------------------------------------------------
  Welcome to the unofficial offical breakfast DnD Character Generator v0.1
  ------------------------------------------------------------------------");
            Console.WriteLine("");
        }

        static void startMenu()
        {
            Console.CursorVisible = false;
            string[] menuItems = { "New Character", "Load Character", "Quit" , "Debug" };
            int choice = ConsoleMenus.ChooseListBoxItem(menuItems, hor, vert, back, fore);
            if(choice == 1)
            {
                
                splash();
                createNewCharacter();
                
            }
            else if (choice == 2)
            {
                splash();
                loadCharacter();
                
            }
            else if (choice == 3)
            {
                close();
            }
            else if (choice == 4)
            {
                debug();
            }

        }


        private static void close()
        {
            Console.BackgroundColor = defaultBack; Console.ForegroundColor = defaultFore;
            Console.Clear();
        }

        static void createNewCharacter() 
        {
            CHARACTER = new Character();
            Console.Write("Please input your characters name: ");
            Console.CursorVisible = true;
            CHARACTER.setName(Console.ReadLine());
            createStats();
            chooseRace();
        }

        private static void chooseRace()
        {
            splash();
            Console.WriteLine("Please choose your Characters Race: (Only Dwarf and Hill dwarf work, all other options will crash)");
            string[] menuItems = { "Dwarf", "Elf", "Halfling", "Human", "Dragonborn", "Gnome", "Half-Elf", "Half-Orc", "Tiefling"};
            int choice = ConsoleMenus.ChooseListBoxItem(menuItems, hor, vert, back, fore);
            CHARACTER.setRace(createRace(menuItems[choice - 1]));
            // if the chosen race has a subrace another menu will appear asking for another race choice
            if (CHARACTER.getRace().hasSubRace())
            {
                splash();
                Console.WriteLine("Please choose your subrace: ");
                string[] subRaces = CHARACTER.getRace().subRaces();
                int secondChoice = ConsoleMenus.ChooseListBoxItem(subRaces, hor, vert, back, fore);
                CHARACTER.setRace(CHARACTER.getRace().createSubRace(subRaces[secondChoice - 1]));
            }
        }

        // sets the characeters race to the inputed race
        private static Race createRace(string race)
        {
            Race chaRace = new Race();
            if (race.Equals("Dwarf")) 
            {
                chaRace = new Dwarf(); 
            }
            else if (race.Equals("Elf")) { throw new Exception("Not yet implemented"); }
            else if (race.Equals("Halfling")) { throw new Exception("Not yet implemented"); }
            else if (race.Equals("Human")) { throw new Exception("Not yet implemented"); }
            else if (race.Equals("Dragonborn")) { throw new Exception("Not yet implemented"); }
            else if (race.Equals("Gnome")) { throw new Exception("Not yet implemented"); }
            else if (race.Equals("Half-Elf")) { throw new Exception("Not yet implemented"); }
            else if (race.Equals("Half-Orc")) { throw new Exception("Not yet implemented"); }
            else if (race.Equals("Tiefling")) { throw new Exception("Not yet implemented"); }
            return chaRace;
        }


        static void createStats() 
        {
            splash();
            //Console.Write(new string(' ', 10));
            Console.WriteLine("Please choose your Stat Distribution: ");
            string[] menuItems = {"Standard Matrix (15, 14, 13, 12, 10, 8)", "Roll 4d6 and keep highest 3", "Input your own values"};
            int choice = ConsoleMenus.ChooseListBoxItem(menuItems, hor, vert, back, fore);
            if(choice == 1)
            { 
                standardMatrix(); 
            }
            else if (choice == 2) 
            { 
                rollForStats(); 
            }
            else if (choice == 3) 
            { 
                inputStats(); 
            }

        }

        
        static void standardMatrix()
        {
            splash();
            string[] menuItems = { "15", "14", "13", "12", "10", "8" };
            menuItems = statSelectMenu("Strength", menuItems);
            menuItems = statSelectMenu("Dexterity", menuItems);
            menuItems = statSelectMenu("Constitution", menuItems);
            menuItems = statSelectMenu("Intelligence", menuItems);
            menuItems = statSelectMenu("Wisdom", menuItems);
            menuItems = statSelectMenu("Charisma", menuItems);

         }

        //sets chosen value for stat from menu and then removes it from the menu for use with an array of strings
        static string[] statSelectMenu(string stat, string[] statValues)
        {
            Console.WriteLine(new string(' ', 20 - stat.Length) + "For {0}:", stat);
            int choice = ConsoleMenus.ChooseListBoxItem(statValues, hor, vert, back, fore);
            CHARACTER.setStat(stat, Int32.Parse(statValues[choice - 1]));
            splash();
            return statValues.Except(new string[] { statValues[choice - 1] }).ToArray();

        }
        //sets chosen value for stat from menu and then removes it from the menu, for use with an array of ints
        static int[] statSelectMenu(string stat, int[] statValues)
        {
            splash();
            Console.WriteLine(new string(' ', 20 - stat.Length) + "For {0}:", stat);
            string[] stringStatValues = new string[statValues.Length];
            for (int i = 0; i < statValues.Length; i++)
            {
                stringStatValues[i] = statValues[i].ToString();
            }
            int choice = ConsoleMenus.ChooseListBoxItem(stringStatValues, hor, vert, back, fore);
            CHARACTER.setStat(stat, statValues[choice - 1]);

            int[] newStatValues = new int[statValues.Length];
            for (int i = 0; i < newStatValues.Length; i++)  //finds selected value and replaces with -1
            {
                if (i != choice-1)
                {
                    newStatValues[i] = statValues[i];
                }
                else
                {
                    newStatValues[i] = -1;
                }
            }
            Array.Sort(newStatValues); //sorts array so -1 is at pos 0
            Array.Reverse(newStatValues); //reverses that order
            Array.Resize<int>(ref newStatValues, statValues.Length-1); // resizes array and loses last value which should be the selected one from earlier
            return newStatValues;

        }

        static void rollForStats() 
        {
            splash();
            int [] stats = CHARACTER.rollForStats();
            Console.WriteLine("Your rolled values are: {0}, {1}, {2}, {3}, {4}, {5}", stats[0], stats[1], stats[2], stats[3], stats[4], stats[5]);
            Console.CursorVisible = true;
            while(true)
            {
                Console.Write("\nReroll Y/N?: ");
                string input = Console.ReadLine();
                if (input.Equals("y")||input.Equals("Y"))
                {
                    rollForStats();
                    break;
                }
                else if (input.Equals("n") || input.Equals("N"))
                {
                    stats = statSelectMenu("Strength", stats);
                    stats = statSelectMenu("Dexterity", stats);
                    stats = statSelectMenu("Constitution", stats);
                    stats = statSelectMenu("Intelligence", stats);
                    stats = statSelectMenu("Wisdom", stats);
                    stats = statSelectMenu("Charisma", stats);
                    break;
                }
            }
            
        }
        static void inputStats() 
        {
            splash();
            addStat("Strength");
            addStat("Dexterity");
            addStat("Constitution");
            addStat("Intelligence");
            addStat("Wisdom");
            addStat("Charisma");

        }

        private static void addStat(string stat)
        {
            Console.CursorVisible = true;
            Console.Write("Please input the value for {0}: ", stat);
            try
            {
                CHARACTER.setStat(stat, Int32.Parse(Console.ReadLine()));
                splash();
            }
            catch (Exception e) 
            {
                addStat(stat);
            }
        }

        static void loadCharacter() 
        {
            Console.WriteLine("not implemented yet sorry");
        }





    }
}
