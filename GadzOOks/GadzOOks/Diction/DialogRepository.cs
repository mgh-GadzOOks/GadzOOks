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
        static public String TutorialWelcome = "Welcome to GadzOOks! This is a fantasy text-based adventure from" +
                " a first-person perspective. Thank you for testing out my program.";
        static public String TutorialWelcomeExplanation = "Without further adieu lets start by creating the" +
                " character you will be using throughout this adventure.";
    }
}
