using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;


namespace PrimeLab
{
    internal class PrimeGenerator_Range : IOptions
    {
        private static List<ulong> generatedPrimeNumbersR = new List<ulong>();
        private static int startPoint;
        private static int endPoint;
        private static string? timeInfo;
        public static bool primeGenerator_RangIsActive = false;
        public static bool primeGeneratorOption_RangIsActive = false;

        public static void Run()
        {
            primeGenerator_RangIsActive = true;
            while (primeGenerator_RangIsActive)
            {
                Console.WriteLine("Please enter the number: ");
                ulong startOfTheRange = 0;
                ulong endOfTheRange = 0;
                while (startOfTheRange <= 1 || endOfTheRange <= startOfTheRange)
                {
                    startOfTheRange = GetTheUserInput(Console.ReadLine());
                    endOfTheRange = GetTheUserInput(Console.ReadLine());
                    //Console.WriteLine("Please enter the appropriate values");
                }

                Initializer(startOfTheRange, endOfTheRange);
                OptionsManager();
            }
        }
        private static void Initializer(ulong start, ulong end)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            GeneratePrimeNumbersInRange(start, end);
            stopwatch.Stop();
            timeInfo = stopwatch.ElapsedMilliseconds.ToString() + "ms";

            Console.WriteLine("The task has been successfuly done!!");
        }

        public static void OptionsManager()
        {
            primeGeneratorOption_RangIsActive = true;
            while (primeGeneratorOption_RangIsActive)
            {

                Console.WriteLine("\t" + "[PRESS 1] Show the result");
                Console.WriteLine("\t" + "[PRESS 2] Save the result");
                Console.WriteLine("\t" + "[PRESS 3] Show the details");
                Console.WriteLine("\t" + "[PRESS 4] Generate new prime numbers in a range");
                Console.WriteLine("\t" + "[PRESS 5] Get back to PrimeLab");
                int temp = 0;
                while (temp > 5 || temp < 1)
                {
                    temp = Menu.GetTheUserChoice(Console.ReadLine());
                }
                switch (temp)
                {
                    case 1:
                        ViewTheResult(generatedPrimeNumbersR);
                        break;
                    case 2:
                        SaveTheResult(generatedPrimeNumbersR);
                        break;
                    case 3:
                        ViewTheDetails();
                        break;
                    case 4:
                        primeGeneratorOption_RangIsActive = false;
                        break;
                    case 5:
                        primeGeneratorOption_RangIsActive = false;
                        primeGenerator_RangIsActive = false;
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
        private static void GeneratePrimeNumbersInRange(ulong start, ulong end)
        {
            GenerateTheBasePrime(start);
            if (start % 2 == 0)
            {

                for (ulong i = start + 1; i <= end; i += 2)
                {
                    if (IsPrime(i))
                    {
                        generatedPrimeNumbersR.Add(i);

                    }
                }
                CountTheLength(endPoint);
            }
            else if (start % 2 != 0)
            {
                for (ulong i = start; i <= end; i += 2)
                {
                    if (IsPrime(i))
                    {
                        generatedPrimeNumbersR.Add(i);

                    }
                }
                CountTheLength(endPoint);
            }


        }

        public static void ViewTheResult(IEnumerable<ulong> input)
        {
            System.Console.WriteLine("****************************************************************");
            if (input != null)
            {
                for (int i = startPoint; i < endPoint; i++)
                {
                    Console.Write(generatedPrimeNumbersR[i] + ", ");
                }
            }
            System.Console.WriteLine("\n****************************************************************");
            Console.WriteLine("\n");


        }
        public static void SaveTheResult(IEnumerable<ulong> input)
        {
            if (input != null)
            {
                string tempS = "";
                for (int i = startPoint; i < endPoint; i++)
                {
                    tempS += generatedPrimeNumbersR[i].ToString() + ", ";
                }
                File.WriteAllText(@"F:\Programering Archive\SideProjects\2.0_PrimeLab\PrimeLab\SavedPrimeNumbers\PrimeNumbersInARange", tempS);
            }

        }
        public static void ViewTheDetails()
        {
            Console.WriteLine("The total number of generated prime numbers in the given range is: " + (endPoint - startPoint));
            Console.WriteLine("The first generated prime number is: " + generatedPrimeNumbersR[startPoint]);
            Console.WriteLine("The last generated prime number is: " + generatedPrimeNumbersR[endPoint]);
            Console.WriteLine("The time taken for this task is: " + timeInfo);
            Console.WriteLine("[PRESS 1] to get back to options");

            int? temp = 0;
            while (temp != 1 || temp == null)
            {
                temp = Menu.GetTheUserChoice(Console.ReadLine());
            }

        }

        private static void GenerateTheBasePrime(ulong start)
        {
            generatedPrimeNumbersR.Add(2);

            for (ulong i = 3; i <= start; i += 2)
            {
                if (IsPrime(i))
                {
                    generatedPrimeNumbersR.Add(i);

                }

            }
            CountTheLength(startPoint);
        }

        private static void CountTheLength(int input)
        {
            input = generatedPrimeNumbersR.Count - 1;
        }
        private static bool IsPrime(ulong numToTest)
        {
            for (int i = 0; generatedPrimeNumbersR[i] * generatedPrimeNumbersR[i] <= numToTest; i++)
            {
                if (generatedPrimeNumbersR[i] > 0 && numToTest % generatedPrimeNumbersR[i] == 0)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
