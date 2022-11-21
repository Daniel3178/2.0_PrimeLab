using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;


namespace PrimeLab
{
    internal class PrimeDetector : IOptions
    {
        public static bool primeDetectorIsActive = false;
        public static bool primeDetectorOptionIsActive = false;
        private static string? timeInfo;
        private static bool theResult;

        public static void Run()
        {
            primeDetectorIsActive = true;
            while (primeDetectorIsActive)
            {
                Console.WriteLine("Please enter the number: ");
                ulong input = 0;
                while (input <= 0)
                {
                    input = GetTheUserInput(Console.ReadLine());
                }
                Initializer(input);
                OptionsManager(input);
            }
        }
        public static void Initializer(ulong input)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            theResult = isPrime(input);
            stopwatch.Stop();

            timeInfo = stopwatch.ElapsedMilliseconds.ToString() + "ms";

        }

        public static void OptionsManager(ulong input)
        {
            primeDetectorOptionIsActive = true;
            while (primeDetectorOptionIsActive)
            {

                Console.WriteLine("\t" + "[PRESS 1] Show the result");
                Console.WriteLine("\t" + "[PRESS 2] Save the result");
                Console.WriteLine("\t" + "[PRESS 3] Show the details");
                Console.WriteLine("\t" + "[PRESS 4] Detect a new prime number");
                Console.WriteLine("\t" + "[PRESS 5] Get back to PrimeLab");

                int temp = 0;
                while (temp > 5 || temp < 1)
                {
                    temp = Menu.GetTheUserChoice(Console.ReadLine());
                }
                switch (temp)
                {
                    case 1:
                        ViewTheResult(input);
                        break;
                    case 2:
                        SaveTheResult(input);
                        break;
                    case 3:
                        ViewTheDetails();
                        break;
                    case 4:
                        primeDetectorOptionIsActive = false;
                        break;
                    case 5:
                        primeDetectorOptionIsActive = false;
                        primeDetectorIsActive = false;
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
        public static void ViewTheResult(ulong input)
        {
            Console.WriteLine($"The result of prime detector for number is {input}  " + theResult.ToString());
            Console.WriteLine("\n\n");

        }
        public static void SaveTheResult(ulong input)
        {


            string tempS = $"The result of prime detector for number {input}" + theResult.ToString();

            File.WriteAllText(@"F:\Programering Archive\SideProjects\2.0_PrimeLab\PrimeLab\SavedPrimeNumbers\PrimeDetector", tempS);

        }
        public static void ViewTheDetails()
        {


            Console.WriteLine("The time taken for this task is: " + timeInfo);
            Console.WriteLine("[PRESS 1] to get back to options");

            int? temp = 0;
            while (temp != 1 || temp == null)
            {
                temp = Menu.GetTheUserChoice(Console.ReadLine());
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
