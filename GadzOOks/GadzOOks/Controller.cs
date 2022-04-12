using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GadzOOks;

namespace GadzOOks
{
    internal class Controller
    {
        public Controller()
        { 
        }

        static public string limitedUserInput(string[] options)
        {
            bool validInput = false;
            string userInput = "";

            while (!validInput)
            {
                userInput = Console.ReadLine();

                foreach (string option in options)
                    if ((userInput.ToLower()).Equals(option))
                    {
                        validInput = true;
                        userInput = option;
                        continue;
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
