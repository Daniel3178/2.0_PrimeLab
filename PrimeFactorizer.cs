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
        static List<ulong> primeFactors = new List<ulong>();
        private static string? timeInfo;
        public static bool primeFactorizerOptionIsActive = false;
        public static bool primeFactorizerIsActive = false;

        public PrimeFactorizer()
        {

        }

        public static void Run()
        {
            primeFactorizerIsActive = true;
            while (primeFactorizerIsActive)
            {
                Console.WriteLine("Please enter the number: ");
                ulong numberToPrimeFactorize = 0;
                while (numberToPrimeFactorize <= 1)
                {
                    numberToPrimeFactorize = GetTheUserInput(Console.ReadLine());
                }
                Initializer(numberToPrimeFactorize);
                OptionsManager();
            }

        }

        private static void Initializer(ulong numberToFactorize)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            PrimeFactorize(numberToFactorize);
            stopwatch.Stop();
            timeInfo = stopwatch.ElapsedMilliseconds.ToString() + "ms";

        }

        public static void OptionsManager()
        {
            primeFactorizerOptionIsActive = true;
            while (primeFactorizerOptionIsActive)
            {

                Console.WriteLine("\t" + "[PRESS 1] Show the result");
                Console.WriteLine("\t" + "[PRESS 2] Save the result");
                Console.WriteLine("\t" + "[PRESS 3] Show the details");
                Console.WriteLine("\t" + "[PRESS 4] Generate new prime factors");
                Console.WriteLine("\t" + "[PRESS 5] Get back to PrimeLab");

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
                        ViewTheDetails();
                        break;
                    case 4:
                        primeFactorizerOptionIsActive = false;
                        primeFactors.Clear();
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

        public static void ViewTheDetails()
        {
            Console.WriteLine("The total number of generated prime factors is: " + primeFactors.Count);
            Console.WriteLine("The least prime factor is: " + primeFactors[0]);
            Console.WriteLine("The greatest prime factor is: " + primeFactors[primeFactors.Count - 1]);
            Console.WriteLine("The time taken for this task is: " + timeInfo);
            Console.WriteLine("[PRESS 1] to get back to options");

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

        static void PrimeFactorize(ulong num)
        {
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
