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
                    Console.WriteLine("you chose two");
                    break;
                case 3:
                    Console.WriteLine("you chose three");
                    break;
            }
        }

        public static int GetTheUserChoice(string? input)
        {
            int temp;
            while (!int.TryParse(input, out temp) || input==null)
            {
                input = Console.ReadLine();
            }
            return temp;
        }
    }
}
