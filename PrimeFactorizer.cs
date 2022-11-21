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
        private static string? timeInfo;
        public static bool primeFactorizerOptionIsActive = false;
        public static bool primeFactorizerIsActive = false;

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

        private static List<ulong> Initializer(ulong numberToFactorize)
        {
            List<ulong> tempPrimeFactos;
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            tempPrimeFactos = PrimeFactorize(numberToFactorize);
            stopwatch.Stop();
            timeInfo = stopwatch.ElapsedMilliseconds.ToString() + "ms";
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
                    case 1:
                        ViewTheResult(primeFactors);
                        break;
                    case 2:
                        SaveTheResult(primeFactors);
                        break;
                    case 3:
                        ViewTheDetails(primeFactors);
                        break;
                    case 4:
                        primeFactorizerOptionIsActive = false;
                        break;
                    case 5:
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

        public static void ViewTheResult(IEnumerable<ulong> input)
        {
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
            if (input != null)
            {
                string tempS = "";
                foreach (ulong value in input)
                {
                    tempS += value.ToString() + ", ";
                }
                File.WriteAllText(@"F:\Programering Archive\SideProjects\2.0_PrimeLab\PrimeLab\SavedPrimeNumbers\PrimeFactors", tempS);
            }

        }

        public static void ViewTheDetails(List<ulong> primeFactors)
        {
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



        //static int GCD(int num1, int num2)
        //{
        //    while (num2 != 0)
        //    {
        //        int remainder = num1 % num2;
        //        num1 = num2;
        //        num2 = remainder;
        //    }
        //    return num1;
        //}

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

        static bool isPrime(ulong num)
        {
            if (num % 2 == 0)
            {
                return false;
            }

            for (ulong i = 3; i * i <= num; i += 2)
            {
                if (num % i == 0)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
