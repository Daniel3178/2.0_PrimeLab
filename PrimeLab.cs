using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeLab
{
    internal class PrimeLab
    {
        #region:Fields
        private static bool primeLabIsActive = false;
        private enum Options { PrimeGenerator = 1, PrimeGeneratorInRange, PrimeDetector, PrimeFactorizer, Menu}
        #endregion
        public static void Run()
        {
            primeLabIsActive = true;
            while (primeLabIsActive)
            {
                Console.Clear();
                Menu.ShowTheSummary();
                Console.WriteLine("\t" + "[PRESS 1] Generate the first n prime numbers");
                Console.WriteLine("\t" + "[PRESS 2] Generate prime numbers in a specific range");
                Console.WriteLine("\t" + "[PRESS 3] Check if a number is prime");
                Console.WriteLine("\t" + "[PRESS 4] Prime factorizing a number");
                Console.WriteLine("\t" + "[PRESS 5] Get back to menu\n");
                Console.Write("\t" + "Your Choice : ");

                int temp = 0;
                while (temp > 5 || temp < 1)
                {
                    temp = Menu.GetTheUserChoice(Console.ReadLine());
                }
                switch (temp)
                {
                    case (int)Options.PrimeGenerator:
                        Console.Clear();
                        Menu.ShowTheSummary();
                        PrimeGenerator.Run();
                        break;

                    case (int)Options.PrimeGeneratorInRange:
                        Console.Clear();
                        Menu.ShowTheSummary();
                        PrimeGenerator_Range.Run();
                        break;

                    case (int)Options.PrimeDetector:
                        Console.Clear();
                        Menu.ShowTheSummary();
                        PrimeDetector.Run();
                        break;

                    case (int)Options.PrimeFactorizer:
                        Console.Clear();
                        Menu.ShowTheSummary();
                        PrimeFactorizer.Run();
                        break;

                    case (int)Options.Menu:
                        primeLabIsActive = false;
                        break;

                }
            }
        }

    }
}
