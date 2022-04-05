using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GadzOOks
{
    internal class DR
    {
        static public String menuInstructions = "Type one of the following single character options\nand press enter to select a menu option:";
        static public String[] mainMenuOptions = { "(S)tart Game", "(O)ptions", "(Q)uit" };
        static public String[] mainMenuChoices = { "s", "o", "q" };
        static public String[] optionsMenuOptions = { "(T)ext speed change", "(B)ack to main menu" };
        static public String[] optionsMenuChoices = { "t", "b"};
        static public String[] textSpeedMenuOptions = { "(0) INSTANT", "(1) FAST", "(2) NORMAL", "(3) SLOW" };
        static public String[] textSpeedMenuChoices = { "0", "1", "2", "3" };
    }
}
