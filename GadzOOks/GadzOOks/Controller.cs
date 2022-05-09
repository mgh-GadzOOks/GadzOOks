using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GadzOOks;

namespace GadzOOks
{

    /// <summary>
    /// Deals with any incoming user inertaction.
    /// 
    /// validates and parses user input.
    /// </summary>
    class Controller
    {
        public Controller()
        { 
        }
        /// <summary>
        /// Automates taking in user input from a limited list of options.
        /// 
        /// Makes sure that user can only type in options given in an array of strings.
        /// Repeats options and asks for re-entry if option typed is invalid.
        /// Works alongside <see cref="generateLimitedMenu(string[])"/>.
        /// </summary>
        /// <param name="options">Takes in options to limit what the user can choose from.</param>
        /// <returns>The user's input so that it can be processed by whoever called it.</returns>
        static public string limitedUserInput(string[] options)
        {
            bool validInput = false;
            string userInput = "";

            while (!validInput)
            {
                userInput = Console.ReadLine();

                if (userInput != null)
                {
                    foreach (string option in options)
                        if ((userInput.ToLower()).Equals(option))
                        {
                            validInput = true;
                            userInput = option;
                            continue;
                        }
                }

                if (!validInput)
                {
                    Console.Write("Please enter one of the valid options: ");
                    for (short i = 0; i < options.Length; i++)
                    {
                        if (i < options.Length - 1)
                            Console.Write(options[i] + ", ");
                        else
                        {
                            Console.Write("or ");
                            Console.WriteLine(options[i]);
                        }
                       
                    }
                    Console.Write(Model.promptUser());
                }
            }

            return userInput;

        }
    }
}
