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

            Console.WriteLine("\t" + "[PRESS 1] Generate the first n prime numbers");
            Console.WriteLine("\t" + "[PRESS 2] Generate all the prime numbers in a specific range");
            Console.WriteLine("\t" + "[PRESS 3] Check if a number is prime");
            Console.WriteLine("\t" + "[PRESS 4] Prime factorizing a number");
            Console.WriteLine("\t" + "[PRESS 5] Get back to menu");


            int temp = 0;
            while (temp > 5 || temp < 1)
            {
                temp = Menu.GetTheUserChoice(Console.ReadLine());
            }
            switch (temp)
            {
                case 1:
                    PrimeGenerator.Run();
                    break;
                case 2:
                    Console.WriteLine("you chose two");
                    break;
                case 3:
                    Console.WriteLine("you chose three");
                    break;
                case 4:
                    Console.WriteLine("you chose four");
                    break;
                case 5:
                    Menu.Run();
                    break;

            }


        }

    }
}
