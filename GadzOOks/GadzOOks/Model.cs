using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GadzOOks
{

    /// <summary>
    /// For the updating and generating of game system states.
    /// </summary>
    class Model
    {
        public string _userName { get; set; }
        public short _textSpeed { get; set;}
        private List<string> _textLog = new List<string>();
        private string _previousState = "";

        public Model()
        {
            _userName = "first time player";
            _textSpeed = 0;
        }

        public string generateLimitedMenu(string[] options)
        {
            string menu = "";

            if (options.Length > 0)
                for (short i = 0; i < options.Length; i++)
                {
                    menu += options[i] + "\n";
                }
            else
                Console.WriteLine("There are no options.");

            return menu;
        }

        public string promptUser(string basePrompt)
        {
            string prompt = "---------------------------------------------------\n";
            prompt += basePrompt + "\n> ";

            return prompt;
        }

        static public string promptUser() { return "---------------------------------------------------\n>"; }

        public string displayText(string text)
        {
            char curLetter;
            char nextLetter;
            short j = 0;
            bool nextLetterCapital = false;
            string displayedText;

            using (StringWriter sw = new StringWriter())
            {

                for (short i = 0; i < text.Length; i++)
                {
                    curLetter = text[i];

                    if (!(i >= text.Length - 1))
                        nextLetter = text[i + 1];
                    else
                        nextLetter = '\0';
                    j++;

                    if ((nextLetterCapital && curLetter != ' ' && curLetter != '\n' && curLetter != '\t') ||
                        (i == 0 && curLetter != ' ' && curLetter != '\n' && curLetter != '\t'))
                    {
                        Console.Write(curLetter.ToString().ToUpper());
                        sw.Write(curLetter.ToString().ToUpper());
                        nextLetterCapital = false;
                    }
                    else
                    {
                        Console.Write(curLetter);
                        sw.Write(curLetter);
                    }

                    if (nextLetter == ' ' && nextLetter != '\0')
                        if (!pause(10, 30, 50))
                            continue;

                    if ((curLetter == '!' || curLetter == '?' || curLetter == '.') &&
                        (nextLetter != '!' || nextLetter != '?' || nextLetter != '.'))
                    {
                        if (!pause(60, 80, 100))
                            continue;
                        else
                            nextLetterCapital = true;
                    }

                    if (!pause(20, 40, 60))
                        continue;

                    if (j >= 70 && nextLetter == ' ' && nextLetter != '\0')
                    {
                        Console.WriteLine();
                        sw.WriteLine();
                        i++;
                        j = 0;
                    }
                }
                displayedText = sw.ToString();
                sw.Close();
            }
            return displayedText;
        }

        public bool pause(short fast, short normal, short slow)
        {
            switch (_textSpeed)
            {
                case 0: break;
                case 1: Thread.Sleep(fast); break;
                case 2: Thread.Sleep(normal); break;
                case 3: Thread.Sleep(slow); break;
                default: Console.WriteLine("Error with text speed settings."); return false;
            }

            return true;
        }

        public string LDT(string text)
        {
            string s = new string(' ', 90);
            string displayedText = "";
            clearPreviousState();
            Console.SetCursorPosition(0, 25);
            for(int i = 0; i < 5; i++) { Console.Write(s); }
            Console.SetCursorPosition(0, 25);
            displayedText = this.Log(displayText(text));
            addToPreviousState(displayedText);
            RK();
            return displayedText;
        }

        public string LDTwC(string text)
        {
            clrScreen();
            clearPreviousState();
            string displayedText = "";
            Console.SetCursorPosition(0, 25);
            displayedText = this.Log(displayText(text));
            addToPreviousState(displayedText);
            RK();
            return displayedText;
        }

        public void RK()
        {
            while (Console.KeyAvailable)
                Console.ReadKey(false);
            Console.CursorVisible = false;
            ConsoleKeyInfo cki = Console.ReadKey();
            if (cki.Key == ConsoleKey.P)
            {
                pauseOrMainMenu("Pause Menu", "Continue");
                restorePreviousState();
                RK();
            }
            else if (cki.Key == ConsoleKey.L)
            {
                checkLog();
                restorePreviousState();
                RK();
            }

            Console.CursorVisible = true;
            
        }

        public void pauseOrMainMenu(string menuName, string displaySorC)
        {
            bool mainMenuOpen = true;
            bool goToOptionsMenu = false;
            string choice;

            while (mainMenuOpen)
            {
                clrScreen();
                Console.WriteLine(DR.menuHeaderText[menuName]);

                if (displaySorC.Equals("Start"))
                    Console.Write(generateLimitedMenu(DR.mainMenuOptions));
                else if (displaySorC.Equals("Continue"))
                    Console.Write(generateLimitedMenu(DR.pauseMenuOptions));
                Console.Write(promptUser(DR.menuInstructions));

                if (displaySorC.Equals("Start"))
                    choice = Controller.limitedUserInput(DR.mainMenuChoices);
                else if (displaySorC.Equals("Continue"))
                    choice = Controller.limitedUserInput(DR.pauseMenuChoices);
                else
                    choice = "";

                switch (choice)
                {
                    case "s" or "c":
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
                    clrScreen();
                    Console.WriteLine(DR.menuHeaderText["Options"]);

                    Console.Write(generateLimitedMenu(DR.optionsMenuOptions));
                    Console.Write(promptUser(DR.menuInstructions));

                    switch (Controller.limitedUserInput(DR.optionsMenuChoices))
                    {
                        case "t":
                            clrScreen();
                            Console.WriteLine(DR.menuHeaderText["Options"]);
                            Console.Write(generateLimitedMenu(DR.textSpeedMenuOptions));
                            Console.Write(promptUser(DR.menuInstructions));
                            _textSpeed = short.Parse(Controller.limitedUserInput(DR.textSpeedMenuChoices));
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
        }

        public void clrScreen() { Console.Clear(); }

        public string Log(string text) { this._textLog.Insert(0, text); return text; }
        public List<string> getTextLog() { return _textLog; }
        public void checkLog()
        {
            clrScreen();
            Console.WriteLine("Text Log: Press any key to continue or press ESC to return.");
            foreach (string previousLine in _textLog)
            {
                Console.WriteLine("---------------------------------------------------");
                Console.WriteLine(previousLine);
                if (Console.ReadKey().Key == ConsoleKey.Escape)
                    break;
            }
            clrScreen();
            restorePreviousState();
        }

        public string addToPreviousState(string previousState) { _previousState += previousState; return previousState; }
        public string getPreviousState() { return _previousState; }
        public void clearPreviousState() { _previousState = ""; }
        public void restorePreviousState() { clrScreen(); Console.SetCursorPosition(0, 25);  Console.Write(_previousState); }
    }
}
