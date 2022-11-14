using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeLab
{
    internal class PrimeLab
    {
        public static void Run()
        {

            Console.WriteLine("You are in Prime Lab, please Enter your choice: ");

            int temp = 0;
            while (temp > 4 || temp < 1)
            {
                temp = GetTheUserChoice(Console.ReadLine());
            }
            switch (temp)
            {
                case 1:
                    Console.WriteLine("you chose One");
                    break;
                case 2:
                    Console.WriteLine("you chose two");
                    break;
                case 3:
                    Console.WriteLine("you chose three");
                    break;
                case 4:
                    Menu.Run();
                    break;
            }


        }
        public static int GetTheUserChoice(string? input)
        {
            int temp;
            while (!int.TryParse(input, out temp) && input != null)
            {
                input = Console.ReadLine();
            }
            return temp;
        }
    }
}
