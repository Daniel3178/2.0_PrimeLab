using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeLab
{
    internal class PrimeLab
    {
        public static bool primeLabIsActive = false;
        public static void Run()
        {
            primeLabIsActive = true;
            while (primeLabIsActive)
            {

                Console.WriteLine("\t" + "[PRESS 1] Generate the first n prime numbers");
                Console.WriteLine("\t" + "[PRESS 2] Generate prime numbers in a specific range");
                Console.WriteLine("\t" + "[PRESS 3] Check if a number is prime");
                Console.WriteLine("\t" + "[PRESS 4] Prime factorizing a number");
                Console.WriteLine("\t" + "[PRESS 5] Get back to menu\n");
                Console.Write("\t" +"Your Choice : ");

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
                        PrimeGenerator_Range.Run();

                        break;
                    case 3:
                        Console.WriteLine("you chose three");

                        break;
                    case 4:
                        PrimeFactorizer.Run();

                        break;

                    case 5:
                        primeLabIsActive = false;
                        break;

                }
            }



        }

    }
}
