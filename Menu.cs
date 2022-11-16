using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeLab
{
    internal class Menu
    {
        public static void Run()
        {
            ShowTheSummary();
            ShowTheOptionsDialog();
            OptionsManager();

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
                    break;
                case 2:
                    ShowTheManual();
                    break;
                case 3:
                    Console.WriteLine("you chose to exit");
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
            System.Console.WriteLine("This is the Manual");

            int temp = 0;
            while (temp > 2 || temp < 1)
            {
                temp = GetTheUserChoice(Console.ReadLine());
            }
            switch (temp)
            {
                case 1:
                    Menu.Run();
                    break;
                case 2:
                    Console.WriteLine("you chose to exit");
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
