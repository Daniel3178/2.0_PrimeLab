﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;


namespace PrimeLab
{
    internal class PrimeGenerator_Range : IOptions
    {
        private static int startPoint;
        private static int endPoint;
        private static string? timeInfo;
        public static bool primeGenerator_RangIsActive = false;
        public static bool primeGeneratorOption_RangIsActive = false;

        public static void Run()
        {
            List<ulong> primeList;
            primeGenerator_RangIsActive = true;
            while (primeGenerator_RangIsActive)
            {
                ulong startOfTheRange = 0;
                ulong endOfTheRange = 0;
                while (startOfTheRange <= 1 || endOfTheRange <= startOfTheRange)
                {
                    Console.Write("\t" + "Enter the beginning number of the interval : ");
                    startOfTheRange = GetTheUserInput(Console.ReadLine());
                    Console.Write("\t" + "Enter the end number of the interval : ");
                    endOfTheRange = GetTheUserInput(Console.ReadLine());

                }

                primeList = Initializer(startOfTheRange, endOfTheRange);
                OptionsManager(primeList);
            }
        }
        private static List<ulong> Initializer(ulong start, ulong end)
        {
            List<ulong> tempPrimeListInRange;
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            tempPrimeListInRange = GeneratePrimeNumbersInRange(start, end);
            stopwatch.Stop();
            timeInfo = stopwatch.ElapsedMilliseconds.ToString() + "ms";

            Console.WriteLine("\t" + "The task has been successfuly done!!");
            return tempPrimeListInRange;
        }

        public static void OptionsManager(List<ulong> primeList)
        {
            primeGeneratorOption_RangIsActive = true;
            while (primeGeneratorOption_RangIsActive)
            {

                Console.WriteLine("\t" + "[PRESS 1] Show the result");
                Console.WriteLine("\t" + "[PRESS 2] Save the result");
                Console.WriteLine("\t" + "[PRESS 3] Show the details");
                Console.WriteLine("\t" + "[PRESS 4] Generate new prime numbers in a range");
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
                        ViewTheResult(primeList);
                        break;
                    case 2:
                        SaveTheResult(primeList);
                        break;
                    case 3:
                        ViewTheDetails(primeList);
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
        private static List<ulong> GeneratePrimeNumbersInRange(ulong start, ulong end)
        {
            List<ulong> theBasePrimeList = GenerateTheBasePrime(start);
            if (start % 2 == 0)
            {

                for (ulong i = start + 1; i <= end; i += 2)
                {
                    if (IsPrime(i, theBasePrimeList))
                    {
                        theBasePrimeList.Add(i);

                    }
                }

                endPoint = theBasePrimeList.Count - 1;
            }
            else if (start % 2 != 0)
            {
                for (ulong i = start; i <= end; i += 2)
                {
                    if (IsPrime(i, theBasePrimeList))
                    {
                        theBasePrimeList.Add(i);

                    }
                }

                endPoint = theBasePrimeList.Count - 1;
            }
            return theBasePrimeList;

        }

        public static void ViewTheResult(List<ulong> input)
        {
            Console.WriteLine("****************************************************************");
            if (input != null)
            {
                for (int i = startPoint; i < endPoint; i++)
                {
                    Console.Write(input[i] + ", ");
                }
            }
            Console.WriteLine("\n****************************************************************");
            Console.WriteLine("\n");


        }
        public static void SaveTheResult(List<ulong> input)
        {
            if (input != null)
            {
                string tempS = "";
                for (int i = startPoint; i < endPoint; i++)
                {
                    tempS += input[i].ToString() + ", ";
                }
                File.WriteAllText(@"F:\Programering Archive\SideProjects\2.0_PrimeLab\PrimeLab\SavedPrimeNumbers\PrimeNumbersInARange", tempS);
            }

        }
        public static void ViewTheDetails(List<ulong> input)
        {
            Console.WriteLine("\t" + "The total number of generated prime numbers in the given range is: " + (endPoint - startPoint));
            Console.WriteLine("\t" + "The first generated prime number is: " + input[startPoint]);
            Console.WriteLine("\t" + "The last generated prime number is: " + input[endPoint]);
            Console.WriteLine("\t" + "The time taken for this task is: " + timeInfo);
            Console.WriteLine("\t" + "[PRESS 1] to get back to options\n ");
            Console.Write("\t" + "Your Choice : ");

            int? temp = 0;
            while (temp != 1 || temp == null)
            {
                temp = Menu.GetTheUserChoice(Console.ReadLine());
            }

        }

        private static List<ulong> GenerateTheBasePrime(ulong start)
        {
            List<ulong> theBasePrimeList = new List<ulong>();
            theBasePrimeList.Add(2);

            for (ulong i = 3; i <= start; i += 2)
            {
                if (IsPrime(i, theBasePrimeList))
                {
                    theBasePrimeList.Add(i);

                }

            }
            startPoint = theBasePrimeList.Count;
            return theBasePrimeList;
        }


        private static bool IsPrime(ulong numToTest, List<ulong> inputList)
        {
            for (int i = 0; inputList[i] * inputList[i] <= numToTest; i++)
            {
                if (inputList[i] > 0 && numToTest % inputList[i] == 0)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
