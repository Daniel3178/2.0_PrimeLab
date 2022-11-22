using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace PrimeLab
{
    internal class PrimeFactorizer : IOptions
    {
        #region:Fields
        private static string? timeInfo;
        private static bool primeFactorizerOptionIsActive = false;
        private static bool primeFactorizerIsActive = false;
        private enum Options { Show = 1, Save, Details, New, Back }
        #endregion
        public static void Run()
        {
            primeFactorizerIsActive = true;
            List<ulong> primeFactors;
            while (primeFactorizerIsActive)
            {
                Console.Write("\t" + "Enter the number to factorize : ");
                ulong numberToPrimeFactorize = 0;
                while (numberToPrimeFactorize <= 1)
                {
                    numberToPrimeFactorize = GetTheUserInput(Console.ReadLine());
                }
                primeFactors = Initializer(numberToPrimeFactorize);
                OptionsManager(primeFactors);
            }

        }

        #region:Initializer&OptionsManager
        private static List<ulong> Initializer(ulong numberToFactorize)
        {
            List<ulong> tempPrimeFactos;
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            tempPrimeFactos = PrimeFactorize(numberToFactorize);
            stopwatch.Stop();
            timeInfo = stopwatch.ElapsedMilliseconds.ToString() + "ms";
            Console.WriteLine();
            Console.WriteLine("\t" + "*** The task has been successfuly done!! ***\n");
            return tempPrimeFactos;
        }
        public static void OptionsManager(List<ulong> primeFactors)
        {
            primeFactorizerOptionIsActive = true;
            while (primeFactorizerOptionIsActive)
            {
                Console.WriteLine("\t" + "[PRESS 1] Show the result");
                Console.WriteLine("\t" + "[PRESS 2] Save the result");
                Console.WriteLine("\t" + "[PRESS 3] Show the details");
                Console.WriteLine("\t" + "[PRESS 4] Generate new prime factors");
                Console.WriteLine("\t" + "[PRESS 5] Get back to PrimeLab\n");
                Console.Write("\t" + "Your Choice : ");

                int temp = 0;
                while (temp > 5 || temp < 1)
                {
                    temp = Menu.GetTheUserChoice(Console.ReadLine());
                }
                switch (temp)
                {
                    case (int)Options.Show:
                        ViewTheResult(primeFactors);
                        break;

                    case (int)Options.Save:
                        SaveTheResult(primeFactors);
                        break;

                    case (int)Options.Details:
                        ViewTheDetails(primeFactors);
                        break;

                    case (int)Options.New:
                        Console.Clear();
                        Menu.ShowTheSummary();
                        primeFactorizerOptionIsActive = false;
                        break;

                    case (int)Options.Back:
                        Console.Clear();
                        Menu.ShowTheSummary();
                        primeFactorizerOptionIsActive = false;
                        primeFactorizerIsActive = false;
                        break;
                }
            }
        }
        private static ulong GetTheUserInput(string? input)
        {
            ulong temp;
            while (!ulong.TryParse(input, out temp) || input == null)
            {
                input = Console.ReadLine();
            }
            return temp;
        }
        #endregion

        #region:MethodForCase1->3
        public static void ViewTheResult(IEnumerable<ulong> input)
        {
            Console.Clear();
            Menu.ShowTheSummary();

            if (input != null)
            {
                foreach (ulong value in input)
                {
                    Console.Write(value + ", ");
                }
            }
            Console.WriteLine("\n\n");

        }

        public static void SaveTheResult(IEnumerable<ulong> input)
        {
            Console.Clear();
            Menu.ShowTheSummary();

            if (input != null)
            {
                string tempS = "";
                foreach (ulong value in input)
                {
                    tempS += value.ToString() + ", ";
                }
                File.WriteAllText(@"F:\Programering Archive\SideProjects\2.0_PrimeLab\PrimeLab\SavedPrimeNumbers\PrimeFactors", tempS);
            }
            Console.WriteLine("\t" + "\t" + "Done!");

        }

        public static void ViewTheDetails(List<ulong> primeFactors)
        {
            Console.Clear();
            Menu.ShowTheSummary();

            Console.WriteLine("\t" + "The total number of generated prime factors is: " + primeFactors.Count);
            Console.WriteLine("\t" + "The least prime factor is: " + primeFactors[0]);
            Console.WriteLine("\t" + "The greatest prime factor is: " + primeFactors[primeFactors.Count - 1]);
            Console.WriteLine("\t" + "The time taken for this task is: " + timeInfo);
            Console.WriteLine("\t" + "[PRESS 1] to get back to options");
            Console.Write("\t" + "Your Choice : ");

            int? temp = 0;
            while (temp != 1 || temp == null)
            {
                temp = Menu.GetTheUserChoice(Console.ReadLine());
            }
            
        }
        #endregion

        #region:PrimeStuff
        static List<ulong> PrimeFactorize(ulong num)
        {
            List<ulong> primeFactors = new List<ulong>();
            ulong i = 3;
            ulong maxFactor = num;

            while (num % 2 == 0)
            {
                primeFactors.Add(2);
                num = num / 2;
            }

            while (i * i <= maxFactor)
            {
                while (num % i == 0)
                {
                    primeFactors.Add(i);
                    num = num / i;
                }
                i = i + 2;
            }
            if (num > 1)
            {
                primeFactors.Add(num);
            }
            return primeFactors;
        }
        #endregion
    }
}
