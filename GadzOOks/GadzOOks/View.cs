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
            Console.WriteLine(DR.splashScreenText);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Press any key to continue...");
            Console.ForegroundColor = ConsoleColor.White;
            Console.ReadKey();

            /*----------------------------------------MAIN MENU---------------------------------------*/

            Model game = new Model();

            game.pauseOrMainMenu("Main Menu","Start");

            /*----------------------------------------GAME START---------------------------------------*/
            game.LDTwC(DR.TutorialWelcome);
            game.LDT(DR.TutorialWelcomeExplanation);
        }
    }
}