using System;
using GadzOOks;

namespace GadzOOks
{
    class View
    {
        static void Main()
        {
            Console.SetWindowSize(130, 30);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("THIS PROGRAM CURRENTLY ONLY WORKS FOR WINDOWS CONSOLE AND IS DESIGNED\n" +
                "WITH THE CURRENT CONSOLE WINDOW SIZE IN MIND!\nDO NOT RESIZE WINDOW FOR OPTIMAL USER EXPERIENCE.");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(@"      ___           ___          _____          ___           ___           ___           ___           ___              
     /  /\         /  /\        /  /::\        /  /\         /  /\         /  /\         /__/|         /  /\             
    /  /:/_       /  /::\      /  /:/\:\      /  /::|       /  /::\       /  /::\       |  |:|        /  /:/_            
   /  /:/ /\     /  /:/\:\    /  /:/  \:\    /  /:/:|      /  /:/\:\     /  /:/\:\      |  |:|       /  /:/ /\           
  /  /:/_/::\   /  /:/~/::\  /__/:/ \__\:|  /  /:/|:|__   /  /:/  \:\   /  /:/  \:\   __|  |:|      /  /:/ /::\          
 /__/:/__\/\:\ /__/:/ /:/\:\ \  \:\ /  /:/ /__/:/ |:| /\ /__/:/ \__\:\ /__/:/ \__\:\ /__/\_|:|____ /__/:/ /:/\:\         
 \  \:\ /~~/:/ \  \:\/:/__\/  \  \:\  /:/  \__\/  |:|/:/ \  \:\ /  /:/ \  \:\ /  /:/ \  \:\/:::::/ \  \:\/:/~/:/         
  \  \:\  /:/   \  \::/        \  \:\/:/       |  |:/:/   \  \:\  /:/   \  \:\  /:/   \  \::/~~~~   \  \::/ /:/          
   \  \:\/:/     \  \:\         \  \::/        |  |::/     \  \:\/:/     \  \:\/:/     \  \:\        \__\/ /:/           
    \  \::/       \  \:\         \__\/         |  |:/       \  \::/       \  \::/       \  \:\         /__/:/            
     \__\/         \__\/                       |__|/         \__\/         \__\/         \__\/         \__\/          ");

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Press any key to continue...");
            Console.ForegroundColor = ConsoleColor.White;
            Console.ReadKey();

            /*----------------------------------------MAIN MENU---------------------------------------*/

            Model game = new Model();
            bool mainMenuOpen = true;
            bool goToOptionsMenu = false;

            while (mainMenuOpen)
            {
                game.clrScreen();
                Console.WriteLine(@"  __  __       _         __  __                  
 |  \/  |     (_)       |  \/  |                 
 | \  / | __ _ _ _ __   | \  / | ___ _ __  _   _ 
 | |\/| |/ _` | | '_ \  | |\/| |/ _ \ '_ \| | | |
 | |  | | (_| | | | | | | |  | |  __/ | | | |_| |
 |_|  |_|\__,_|_|_| |_| |_|  |_|\___|_| |_|\__,_|
                                                 
                                                 
");

                Console.Write(game.generateLimitedMenu(DR.mainMenuOptions));
                Console.Write(game.promptUser(DR.menuInstructions));

                switch (Controller.limitedUserInput(DR.mainMenuChoices))
                {
                    case "s":
                        mainMenuOpen = false;
                        break;
                    case "o":
                        goToOptionsMenu = true;
                        break;
                    case "q":
                        return;
                    default:
                        Console.WriteLine("Error with menu.");
                        break;
                }

                while (goToOptionsMenu)
                {
                    game.clrScreen();
                    Console.WriteLine(@"   ____        _   _                 
  / __ \      | | (_)                
 | |  | |_ __ | |_ _  ___  _ __  ___ 
 | |  | | '_ \| __| |/ _ \| '_ \/ __|
 | |__| | |_) | |_| | (_) | | | \__ \
  \____/| .__/ \__|_|\___/|_| |_|___/
        | |                          
        |_|                          

");

                    Console.Write(game.generateLimitedMenu(DR.optionsMenuOptions));
                    Console.Write(game.promptUser(DR.menuInstructions));

                    switch (Controller.limitedUserInput(DR.optionsMenuChoices))
                    {
                        case "t":
                            game.clrScreen();
                            Console.WriteLine(@"   ____        _   _                 
  / __ \      | | (_)                
 | |  | |_ __ | |_ _  ___  _ __  ___ 
 | |  | | '_ \| __| |/ _ \| '_ \/ __|
 | |__| | |_) | |_| | (_) | | | \__ \
  \____/| .__/ \__|_|\___/|_| |_|___/
        | |                          
        |_|                          

");
                            Console.Write(game.generateLimitedMenu(DR.textSpeedMenuOptions));
                            Console.Write(game.promptUser(DR.menuInstructions));
                            game.setTextSpeed(Int32.Parse(Controller.limitedUserInput(DR.textSpeedMenuChoices)));
                            break;
                        case "b":
                            goToOptionsMenu = false;
                            break;
                        default:
                            Console.WriteLine("Error with menu.");
                            break;
                    }
                }
            }

            /*----------------------------------------GAME START---------------------------------------*/
            game.LDTwC(DR.TutorialWelcome);
            game.WL(DR.TutorialWelcomeExplanation);
        }
    }
}