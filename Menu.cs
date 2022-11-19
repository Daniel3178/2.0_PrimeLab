using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeLab
{
    internal class Menu
    {
        public static bool programIsActive = true;
        public static void Run()
        {
            ShowTheSummary();
            while (programIsActive)
            {
                ShowTheOptionsDialog();
                OptionsManager();
            }
            Console.WriteLine("GoodBye!");
        }

        public static void OptionsManager()
        {

            Console.WriteLine("Please Enter your choice: ");

            int temp = 0;
            while (temp > 3 || temp < 1)
            {
                temp = GetTheUserChoice(Console.ReadLine());
            }
            switch (temp)
            {
                case 1:
                    PrimeLab.Run();
                    programIsActive = true;
                    break;
                case 2:
                    ShowTheManual();
                    break;
                case 3:
                    Console.WriteLine("you chose to exit");
                    programIsActive = false;
                    break;
            }

        }
        public static int GetTheUserChoice(string? input)
        {
            int temp;
            while (!int.TryParse(input, out temp) || input == null)
            {
                input = Console.ReadLine();
            }
            return temp;
        }

        public static void ShowTheManual()
        {
            Console.WriteLine("This is the Manual");

            int temp = 0;
            while (temp > 2 || temp < 1)
            {
                temp = GetTheUserChoice(Console.ReadLine());
            }
            switch (temp)
            {
                case 1:
                    programIsActive = true;
                    break;
                case 2:
                    Console.WriteLine("you chose to exit");
                    programIsActive = false;
                    break;
            }
        }

        public static void ShowTheSummary()
        {
            System.Console.WriteLine("****************************************************************");
            System.Console.WriteLine("\t" + "\t" + "      This is the summary");
            System.Console.WriteLine("****************************************************************");
        }

        public static void ShowTheOptionsDialog()
        {
            Console.WriteLine("\t" + "[PRESS 1] PrimeLab");
            Console.WriteLine("\t" + "[PRESS 2] Manual");
            Console.WriteLine("\t" + "[PRESS 3] Exit");
        }

    }
}
