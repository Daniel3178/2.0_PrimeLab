using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace PrimeLab
{
    internal class PrimeGenerator : IOptions
    {
        #region:Fields
        private static string? timeInfo;
        private static bool primeGeneratorOptionIsActive = false;
        private static bool primeGeneratorIsActive = false;
        private enum Options { Show = 1, Save, Details, New, Back }
        #endregion
        public static void Run()
        {
            ulong[] tempGeneratedPrimeNumbers;
            primeGeneratorIsActive = true;

            while (primeGeneratorIsActive)
            {
                Console.Write("\t" + "The number of primes to generate : ");
                int NumberOfPrimesToGenerate = -1;

                while (NumberOfPrimesToGenerate <= 0)
                {
                    NumberOfPrimesToGenerate = Menu.GetTheUserChoice(Console.ReadLine());
                }

                tempGeneratedPrimeNumbers = Initializer(NumberOfPrimesToGenerate);
                OptionsManager(tempGeneratedPrimeNumbers, tempGeneratedPrimeNumbers);
            }
        }

        #region:Initializer&OptionsManager
        public static ulong[] Initializer(int input)
        {
            ulong[] temp = new ulong[input];
            ulong[] modified;
            temp[0] = 2;

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            modified = GeneratePrimeNumbers(input, temp);
            stopwatch.Stop();
            timeInfo = stopwatch.ElapsedMilliseconds.ToString() + " ms";
            Console.WriteLine();
            Console.WriteLine("\t" + "*** The task has been successfuly done!! ***\n");
            return modified;
        }

        public static void OptionsManager(IEnumerable<ulong> input, ulong[] inputArray)
        {
            primeGeneratorOptionIsActive = true;
            while (primeGeneratorOptionIsActive)
            {
                Console.WriteLine("\t" + "[PRESS 1] Show the result");
                Console.WriteLine("\t" + "[PRESS 2] Save the result");
                Console.WriteLine("\t" + "[PRESS 3] Show the details");
                Console.WriteLine("\t" + "[PRESS 4] Generate new prime numbers");
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
                        Console.Clear();
                        Menu.ShowTheSummary();
                        ViewTheResult(input);
                        break;

                    case (int)Options.Save:
                        Console.Clear();
                        Menu.ShowTheSummary();
                        SaveTheResult(input);
                        break;

                    case (int)Options.Details:
                        Console.Clear();
                        Menu.ShowTheSummary();
                        ViewTheDetails(inputArray);
                        break;

                    case (int)Options.New:
                        Console.Clear();
                        Menu.ShowTheSummary();
                        primeGeneratorOptionIsActive = false;
                        GC.Collect();
                        break;

                    case (int)Options.Back:
                        Console.Clear();
                        Menu.ShowTheSummary();
                        primeGeneratorOptionIsActive = false;
                        primeGeneratorIsActive = false;
                        break;
                }
            }
        }

        #endregion

        #region:MethodsForCase1->3

        public static void ViewTheResult(IEnumerable<ulong> input)
        {
            Console.Clear();
            Menu.ShowTheSummary();
            System.Console.WriteLine("****************************************************************");
            if (input != null)
            {
                foreach (ulong value in input)
                {
                    Console.Write(value + ", ");
                }
            }
            System.Console.WriteLine("\n****************************************************************");
            Console.WriteLine("\n");

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
                File.WriteAllText(@"F:\Programering Archive\SideProjects\2.0_PrimeLab\PrimeLab\SavedPrimeNumbers\PrimeNumbers", tempS);
            }

        }

        public static void ViewTheDetails(ulong[] input)
        {

            Console.WriteLine("\t" + "The total number of generated prime numbers is: " + input.Length);
            Console.WriteLine("\t" + "The first generated prime number is: " + input[0]);
            Console.WriteLine("\t" + "The last generated prime number is: " + input[input.Length - 1]);
            Console.WriteLine("\t" + "The time taken for this task is: " + timeInfo);
            Console.WriteLine("\t" + "[PRESS 1] to get back to options\n");
            Console.Write("\t" + "Your Choice : ");

            int? temp = 0;
            while (temp != 1 || temp == null)
            {
                temp = Menu.GetTheUserChoice(Console.ReadLine());
            }
            Console.Clear();
            Menu.ShowTheSummary();

        }
        #endregion

        #region:PrimeStuff

        private static ulong[] GeneratePrimeNumbers(int numberOfPrimesToGenerate, ulong[] input)
        {
            int temp = 1;
            ulong[] tempArray = input;
            for (ulong i = 3; i < ulong.MaxValue; i += 2)
            {
                if (IsPrime(i, tempArray) && temp < tempArray.Length)
                {
                    tempArray[temp] = i;
                    temp++;
                }
                else if (temp == numberOfPrimesToGenerate)
                {
                    break;
                }
            }
            return tempArray;
        }

        private static bool IsPrime(ulong numToTest, ulong[] primes)
        {
            ulong[] temp = primes;
            for (ulong i = 0; temp[i] * temp[i] <= numToTest; i++)
            {
                if (temp[i] > 0 && numToTest % temp[i] == 0)
                {
                    return false;
                }
            }
            return true;
        }

        #endregion



    }
}
