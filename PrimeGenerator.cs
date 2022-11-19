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
        public static ulong[] GeneratedPrimeNumbers { get; set; }
        private static string? timeInfo;
        public static bool primeGeneratorOptionIsActive = false;
        public static bool primeGeneratorIsActive = false;

        public PrimeGenerator(int numberOfPrimesToGenerate)
        {

            GeneratedPrimeNumbers = new ulong[numberOfPrimesToGenerate];
            foreach (int i in GeneratedPrimeNumbers)
            {
                GeneratedPrimeNumbers[i] = 0;
            }
            GeneratedPrimeNumbers[0] = 2;
        }


        public static void Run()
        {
            primeGeneratorIsActive = true;
            while (primeGeneratorIsActive)
            {

                Console.WriteLine("How many prime numbers would you like to generate? ");
                int NumberOfPrimesToGenerate = -1;
                while (NumberOfPrimesToGenerate <= 0)
                {
                    NumberOfPrimesToGenerate = Menu.GetTheUserChoice(Console.ReadLine());
                }
                Initializer(NumberOfPrimesToGenerate);

                OptionsManager();
            }


        }

        #region:Initializer&OptionsManager
        public static void Initializer(int input)
        {

            PrimeGenerator primeGenerator = new PrimeGenerator(input);
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            GeneratePrimeNumbers(input);
            stopwatch.Stop();
            timeInfo = stopwatch.ElapsedMilliseconds.ToString() + " ms";

            Console.WriteLine("The task has been successfuly done!!");
        }

        public static void OptionsManager()
        {
            primeGeneratorOptionIsActive = true;
            while (primeGeneratorOptionIsActive)
            {

                Console.WriteLine("\t" + "[PRESS 1] Show the result");
                Console.WriteLine("\t" + "[PRESS 2] Save the result");
                Console.WriteLine("\t" + "[PRESS 3] Show the details");
                Console.WriteLine("\t" + "[PRESS 4] Generate new prime numbers");
                Console.WriteLine("\t" + "[PRESS 5] Get back to PrimeLab");

                int temp = 0;
                while (temp > 5 || temp < 1)
                {
                    temp = Menu.GetTheUserChoice(Console.ReadLine());
                }
                switch (temp)
                {
                    case 1:
                        ViewTheResult(GeneratedPrimeNumbers);
                        break;
                    case 2:
                        SaveTheResult(GeneratedPrimeNumbers);
                        break;
                    case 3:
                        ViewTheDetails();
                        break;
                    case 4:
                        primeGeneratorOptionIsActive = false;
                        break;
                    case 5:
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

        public static void ViewTheDetails()
        {
            Console.WriteLine("The total number of generated prime numbers is: " + GeneratedPrimeNumbers.Length);
            Console.WriteLine("The first generated prime number is: " + GeneratedPrimeNumbers[0]);
            Console.WriteLine("The last generated prime number is: " + GeneratedPrimeNumbers[GeneratedPrimeNumbers.Length - 1]);
            Console.WriteLine("The time taken for this task is: " + timeInfo);
            Console.WriteLine("[PRESS 1] to get back to options");

            int? temp = 0;
            while (temp != 1 || temp == null)
            {
                temp = Menu.GetTheUserChoice(Console.ReadLine());
            }

        }
        #endregion

        #region:PrimeStuff

        private static void GeneratePrimeNumbers(int numberOfPrimesToGenerate)
        {
            int temp = 1;
            for (ulong i = 3; i < ulong.MaxValue; i += 2)
            {
                if (IsPrime(i) && temp < GeneratedPrimeNumbers.Length)
                {
                    GeneratedPrimeNumbers[temp] = i;
                    temp++;
                }
                else if (temp == numberOfPrimesToGenerate)
                {
                    break;
                }
            }
        }

        private static bool IsPrime(ulong numToTest)
        {
            for (ulong i = 0; GeneratedPrimeNumbers[i] * GeneratedPrimeNumbers[i] <= numToTest; i++)
            {
                if (GeneratedPrimeNumbers[i] > 0 && numToTest % GeneratedPrimeNumbers[i] == 0)
                {
                    return false;
                }
            }
            return true;
        }

        #endregion



    }
}
