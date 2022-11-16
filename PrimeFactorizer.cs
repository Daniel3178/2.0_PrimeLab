using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace PrimeLab
{
    internal class PrimeFactorizer
    {
        static List<ulong> primeNumbers = new List<ulong>();
        private static string? timeInfo;

        public PrimeFactorizer()
        {

        }

        public static void Run()
        {
            Console.WriteLine("Please enter the number: ");
            ulong numberToPrimeFactorize = 0;
            while (numberToPrimeFactorize <= 1)
            {
                numberToPrimeFactorize = GetTheUserInput(Console.ReadLine());
            }
            Initializer(numberToPrimeFactorize);

        }

        private static void Initializer(ulong numberToFactorize)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            PrimeFactorize(numberToFactorize);
            stopwatch.Stop();
            timeInfo = stopwatch.ElapsedMilliseconds.ToString();

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
                primeNumbers.Add(2);
                num = num / 2;
            }

            while (i * i <= maxFactor)
            {
                while (num % i == 0)
                {
                    primeNumbers.Add(i);
                    num = num / i;
                }
                i = i + 2;
            }
            if (num > 1)
            {
                primeNumbers.Add(num);
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
