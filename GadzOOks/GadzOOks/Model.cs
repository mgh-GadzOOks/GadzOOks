using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GadzOOks
{

    /// <summary>
    /// Updates and generates game system states.
    /// </summary>
    class Model
    {
        public string _userName { get; set; }
        public short _textSpeed { get; set;}
        private List<string> _textLog = new List<string>();
        private string _previousState = "";

        /// <summary>
        /// Default constructor
        /// </summary>
        public Model()
        {
            _userName = "first time player";
            _textSpeed = 0;
        }

        /// <summary>
        /// Creates formatted menu to display what choices the user can type.
        /// 
        /// Works alongside <see cref="limitedUserInput(string[])"/>.
        /// </summary>
        /// <param name="options">Holds string options to be displayed to user as choices.</param>
        /// <returns>Formatted menu to be displayed.</returns>
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

        /// <summary>
        /// Creates seperator between menu or screen central info and line to enter input (with instructional prompt).
        /// 
        /// Helps to clearly show when user input is expected.
        /// </summary>
        /// <param name="basePrompt">Simple instructions on what is expected to be typed</param>
        /// <returns>Entire prompt to be displayed.</returns>
        public string promptUser(string basePrompt)
        {
            string prompt = "---------------------------------------------------\n";
            prompt += basePrompt + "\n> ";

            return prompt;
        }

        /// <summary>
        /// Creates seperator between menu or screen central info and line to enter input (without instructional prompt).
        /// </summary>
        /// <returns>Seperator line</returns>
        static public string promptUser() { return "---------------------------------------------------\n>"; }

        /// <summary>
        /// For displaying story or game related text at user preferred speed for easier reading.
        /// 
        /// Works alongside <see cref="LDT(string)"/> and <see cref="LDTwC(string)"/>.
        /// </summary>
        /// <param name="text">Text to be displayed.</param>
        /// <returns>Parameter text to be stored for later use.</returns>
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

        /// <summary>
        /// Dictates the amount of time in milliseconds that the system should pause between displaying text.
        /// 
        /// If _textspeed is set to 0, text has no pause.
        /// Works alongside <see cref="displayText(string)"/>
        /// </summary>
        /// <param name="fast">Slightly arbitrary speed of text if the user set their _textspeed to be 1.</param>
        /// <param name="normal">Slightly arbitrary speed of text if the user set their _textspeed to be 2.</param>
        /// <param name="slow">Slightly arbitrary speed of text if the user set their _textspeed to be 3.</param>
        /// <returns>Verification (true) that text has been paused.</returns>
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

        /// <summary>
        /// Stands for Log and Display Text.
        /// 
        /// Clears previously displayed game/story text.
        /// Correctly places cursor for where to display text.
        /// Logs the displayed text to be viewed later.
        /// Saves the fact that this is the current text displayed.
        /// Waits for user input to continue to next lines of text.
        /// <seealso cref="clearPreviousState()"/>
        /// <seealso cref="Log(string)"/>
        /// <seealso cref="addToPreviousState(string)"/>
        /// <seealso cref="RK()"/>
        /// </summary>
        /// <param name="text">Text to be displayed.</param>
        /// <returns>Text that was displayed.</returns>
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

        /// <summary>
        /// Stands for Log and Display Text with Clear.
        /// 
        /// Preforms same tasks as LDT but clears the screen first.
        /// <seealso cref="LDT(string)"/>
        /// </summary>
        /// <param name="text">Text to be displayed.</param>
        /// <returns>Text that was displayed.</returns>
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

        /// <summary>
        /// Stands for Read Key
        /// Pauses the screen until the user enters any key, then continues to next lines.
        /// If the user presses P: bring's up pause menu.
        /// If the user presses L: bring's up log of previously displayed text.
        /// Upon exiting either, returns the console screen to showing what
        /// was on screen before hitting P or L.
        /// </summary>
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

        /// <summary>
        /// Changes the console screen to display game menu.
        /// 
        /// Main menu displayed when the game starts.
        /// Pause menu displayed when game state interrupted for game menu.
        /// </summary>
        /// <param name="menuName">For swapping what ascii art menu name displays (Start or Continue).</param>
        /// <param name="displaySorC">For swapping what options appear to choose from in the menu.</param>
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

        /// <summary>
        /// For storing previously displayed game text for later viewing
        /// </summary>
        /// <param name="text">Text to be logged.</param>
        /// <returns>Text is returned to be displayed after being logged.</returns>
        public string Log(string text) { this._textLog.Insert(0, text); return text; }
        public List<string> getTextLog() { return _textLog; }

        /// <summary>
        /// Displays each group of previously displayed text in reverse order.
        /// </summary>
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
