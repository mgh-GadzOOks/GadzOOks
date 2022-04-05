using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GadzOOks
{
    internal class Model
    {
        private String _userName;
        private int _textSpeed;
        private List<String> _textLog;

        public Model()
        {
            _userName = "First time player";
            _textSpeed = 1;
        }

        public Model(String userName, int textSpeed)
        {
            _userName = userName;
            _textSpeed = textSpeed;
        }

        public string generateLimitedMenu(String[] options)
        {
            String menu = "";

            if (options.Length > 0)
                for (int i = 0; i < options.Length; i++)
                {
                    menu += options[i] + "\n";
                }
            else
                Console.WriteLine("There are no options.");

            return menu;
        }

        public string promptUser(String basePrompt)
        {
            String prompt = "---------------------------------------------------\n";
            prompt += basePrompt + "\n> ";

            return prompt;
        }

        static public string promptUser() { return "---------------------------------------------------\n>"; }

        public static string displayText(String Text)
        {
            char curLetter;
            char nextLetter;
            int j = 0;
            Model model = new Model();

            using (StringWriter stringWriter = new StringWriter())
            {
                Console.SetOut(stringWriter);

                for (int i = 0; i < Text.Length; i++)
                {
                    curLetter = Text[i];

                    if (!(i >= Text.Length - 1))
                        nextLetter = Text[i + 1];
                    else
                        nextLetter = '\0';
                    j++;

                    Console.Write(curLetter);

                    if (nextLetter == ' ' && nextLetter != '\0')
                        if (!model.pause(20, 40, 60))
                            continue;

                    if ((curLetter == '!' || curLetter == '?' || curLetter == '.') &&
                        (nextLetter != '!' || nextLetter != '?' || nextLetter != '.'))
                        if (!model.pause(80, 100, 120))
                            continue;

                    if (!model.pause(40, 60, 80))
                        continue;

                    if (j >= 50 && (curLetter == '!' || curLetter == '?' || curLetter == '.')
                        && nextLetter == ' ' && nextLetter != '\0')
                    {
                        Console.WriteLine();
                        i++;
                        j = 0;
                    }
                }
                return stringWriter.ToString();
            }
        }

        public void clrScreen() { Console.Clear(); }

        public void checkLog()
        {
            clrScreen();
            Console.WriteLine("Press any key to continue or press ESC to return.");
            foreach (String previousLine in _textLog)
            {
                if (Console.ReadKey().Key == ConsoleKey.Escape)
                    break;
                Console.WriteLine(previousLine);
            }
            clrScreen();
        }

        public bool pause(int fast, int normal, int slow)
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

        //public void update

        public void updateBasedOnChoice(String choice, String[] options, Func<string>[] result)
        {
            for(int i = 0; i < options.Length; i++)
            {
                if (choice.Equals(options[i]))
                {
                    result[i]();
                }
            }
        }

        public void setUserName(String userName) { _userName = userName; }
        public String getUserName() { return _userName;}

        public void setTextSpeed(int textSpeed) { _textSpeed = textSpeed; }
        public int getTextSpeed() { return _textSpeed;}

        public void Log(string text) { _textLog.Add(text); }
        public List<String> getTextLog() { return _textLog; }
    }
}
