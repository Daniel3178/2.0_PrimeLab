using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;


namespace PrimeLab
{
    internal class PrimeGenerator_Range
    {
        private static List<ulong> generatedPrimeNumbersR = new List<ulong>();
        private static int startPoint;
        private static int endPoint;
        private static string? timeInfo;

        public PrimeGenerator_Range()
        {

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
            Console.WriteLine("\t" + "[PRESS 1] Show the result");
            Console.WriteLine("\t" + "[PRESS 2] Save the result");
            Console.WriteLine("\t" + "[PRESS 3] Show the details");
            Console.WriteLine("\t" + "[PRESS 4] Get back to PrimeLab");
            int temp = 0;
            while (temp > 4 || temp < 1)
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
                    PrimeLab.Run();
                    break;
            }
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
            if (input != null)
            {
                for (int i = startPoint; i < endPoint; i++)
                {
                    Console.Write(generatedPrimeNumbersR[i] + ", ");
                }
            }
            OptionsManager();
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
            OptionsManager();
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
            OptionsManager();
        }

        private static void GenerateTheBasePrime(ulong start)
        {
            generatedPrimeNumbersR[0] = 2;

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
