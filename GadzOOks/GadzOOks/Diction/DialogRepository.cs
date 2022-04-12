using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GadzOOks
{
    internal class DR
    {
        static public string splashScreenText = @"      ___           ___          _____          ___           ___           ___           ___           ___              
     /  /\         /  /\        /  /::\        /  /\         /  /\         /  /\         /__/|         /  /\             
    /  /:/_       /  /::\      /  /:/\:\      /  /::|       /  /::\       /  /::\       |  |:|        /  /:/_            
   /  /:/ /\     /  /:/\:\    /  /:/  \:\    /  /:/:|      /  /:/\:\     /  /:/\:\      |  |:|       /  /:/ /\           
  /  /:/_/::\   /  /:/~/::\  /__/:/ \__\:|  /  /:/|:|__   /  /:/  \:\   /  /:/  \:\   __|  |:|      /  /:/ /::\          
 /__/:/__\/\:\ /__/:/ /:/\:\ \  \:\ /  /:/ /__/:/ |:| /\ /__/:/ \__\:\ /__/:/ \__\:\ /__/\_|:|____ /__/:/ /:/\:\         
 \  \:\ /~~/:/ \  \:\/:/__\/  \  \:\  /:/  \__\/  |:|/:/ \  \:\ /  /:/ \  \:\ /  /:/ \  \:\/:::::/ \  \:\/:/~/:/         
  \  \:\  /:/   \  \::/        \  \:\/:/       |  |:/:/   \  \:\  /:/   \  \:\  /:/   \  \::/~~~~   \  \::/ /:/          
   \  \:\/:/     \  \:\         \  \::/        |  |::/     \  \:\/:/     \  \:\/:/     \  \:\        \__\/ /:/           
    \  \::/       \  \:\         \__\/         |  |:/       \  \::/       \  \::/       \  \:\         /__/:/            
     \__\/         \__\/                       |__|/         \__\/         \__\/         \__\/         \__\/          ";

        static public Dictionary<string, string> menuHeaderText = new Dictionary<string, string>()
        {
            { "Main Menu", @"  __  __       _         __  __                  
 |  \/  |     (_)       |  \/  |                 
 | \  / | __ _ _ _ __   | \  / | ___ _ __  _   _ 
 | |\/| |/ _` | | '_ \  | |\/| |/ _ \ '_ \| | | |
 | |  | | (_| | | | | | | |  | |  __/ | | | |_| |
 |_|  |_|\__,_|_|_| |_| |_|  |_|\___|_| |_|\__,_|
                                                 
                                                 
" },

            { "Options", @"   ____        _   _                 
  / __ \      | | (_)                
 | |  | |_ __ | |_ _  ___  _ __  ___ 
 | |  | | '_ \| __| |/ _ \| '_ \/ __|
 | |__| | |_) | |_| | (_) | | | \__ \
  \____/| .__/ \__|_|\___/|_| |_|___/
        | |                          
        |_|                          

" },
            { "Pause Menu", @"   _____                       __  __                  
 |  __ \                     |  \/  |                 
 | |__) |_ _ _   _ ___  ___  | \  / | ___ _ __  _   _ 
 |  ___/ _` | | | / __|/ _ \ | |\/| |/ _ \ '_ \| | | |
 | |  | (_| | |_| \__ \  __/ | |  | |  __/ | | | |_| |
 |_|   \__,_|\__,_|___/\___| |_|  |_|\___|_| |_|\__,_|
                                                      
                                                      " }
        };
        static public string menuInstructions = "Type one of the following single character options\nand press enter to select a menu option:";
        static public string[] mainMenuOptions = { "(S)tart Game", "(O)ptions", "(Q)uit" };
        static public string[] mainMenuChoices = { "s", "o", "q" };
        static public string[] pauseMenuOptions = { "(C)ontinue Game", "(O)ptions", "(Q)uit" };
        static public string[] pauseMenuChoices = { "c", "o", "q" };
        static public string[] optionsMenuOptions = { "(T)ext speed change", "(B)ack to main menu" };
        static public string[] optionsMenuChoices = { "t", "b"};
        static public string[] textSpeedMenuOptions = { "(0) INSTANT", "(1) FAST", "(2) NORMAL", "(3) SLOW" };
        static public string[] textSpeedMenuChoices = { "0", "1", "2", "3" };
        static public string TutorialWelcome = "Welcome to GadzOOks! This is a fantasy text-based adventure from" +
                " a first-person perspective. Thank you for testing out my program.";
        static public string TutorialWelcomeExplanation = "Without further adieu lets start by creating the" +
                " character you will be using throughout this adventure.";
    }
}
