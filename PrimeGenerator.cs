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
        Stopwatch stopwatch;
        public static ulong[]? GeneratedPrimeNumbers { get; set; }


        public PrimeGenerator(int numberOfPrimesToGenerate)
        {
            stopwatch = new Stopwatch();
            GeneratedPrimeNumbers = new ulong[numberOfPrimesToGenerate];
            foreach (int i in GeneratedPrimeNumbers)
            {
                GeneratedPrimeNumbers[i] = 0;
            }
            GeneratedPrimeNumbers[0] = 2;
        }


        public static void Run()
        {

            Console.WriteLine("How many prime numbers would you like to generate? ");
            int NumberOfPrimesToGenerate = -1;
            while (NumberOfPrimesToGenerate < 0)
            {
                NumberOfPrimesToGenerate = Menu.GetTheUserChoice(Console.ReadLine());
            }
            Initializer(NumberOfPrimesToGenerate);

            OptionsManager();


        }

        public static void OptionsManager()
        {
            Console.WriteLine("Choose what you want to do: ");
            int temp = 0;
            while (temp > 4 || temp < 1)
            {
                temp = Menu.GetTheUserChoice(Console.ReadLine());
            }
            switch (temp)
            {
                case 1:
                    PrimeLab.Run();
                    break;
                case 2:
                    Console.WriteLine("you chose two");
                    break;
                case 3:
                    Console.WriteLine("you chose three");
                    break;
                case 4:
                    Console.WriteLine("you chose four");
                    break;
            }
        }

        public static void Initializer(int input)
        {
            PrimeGenerator primeGenerator = new PrimeGenerator(input);
            GeneratePrimeNumbers(input);
            Console.WriteLine("The task has been successfuly done!!");
        }




        public static void ViewTheResult(IEnumerable<ulong> input)
        {
            foreach (ulong value in input)
            {
                Console.WriteLine(value + ", ");
            }
        }

        public static void SaveTheResult(IEnumerable<ulong> input)
        {
            string tempS = "";
            foreach (ulong value in input)
            {
                tempS += value.ToString() + ", ";
            }
            File.WriteAllText(@"F:\Programering Archive\SideProjects\2.0_PrimeLab\PrimeLab\SavedPrimeNumbers\PrimeNumbers", tempS);
        }

        #region:PrimeStuff

        public static void GeneratePrimeNumbers(int numberOfPrimesToGenerate)
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

        #endregion:PrimeStuff



    }
}
