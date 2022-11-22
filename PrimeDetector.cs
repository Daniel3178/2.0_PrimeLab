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
        private enum Options { Show = 1, Save, Details, New, Back }
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

        #region:Initializer&OptionsManager
        public static void Initializer(ulong input)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            theResult = IsPrime(input);
            stopwatch.Stop();

            timeInfo = stopwatch.ElapsedMilliseconds.ToString() + "ms";
            Console.WriteLine();
            Console.WriteLine("\t" + "*** The task has been successfuly done!! ***\n");
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
                    case (int)Options.Show:
                        ViewTheResult(input);
                        break;

                    case (int)Options.Save:
                        SaveTheResult(input);
                        break;

                    case (int)Options.Details:
                        ViewTheDetails();
                        break;

                    case (int)Options.New:
                        primeDetectorOptionIsActive = false;
                        break;

                    case (int)Options.Back:
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
        #endregion

        #region:MehtodsForCase1->3
        public static void ViewTheResult(ulong input)
        {
            Console.Clear();
            Menu.ShowTheSummary();
            Console.WriteLine($"The result of prime detector for number is {input}  " + theResult.ToString());
            Console.WriteLine("\n\n");

        }
        public static void SaveTheResult(ulong input)
        {
            Console.Clear();
            Menu.ShowTheSummary();

            string tempS = $"The result of prime detector for number {input}" + theResult.ToString();

            File.WriteAllText(@"F:\Programering Archive\SideProjects\2.0_PrimeLab\PrimeLab\SavedPrimeNumbers\PrimeDetector", tempS);
            Console.WriteLine("\t" + "\t" + "Done!");

        }
        public static void ViewTheDetails()
        {

            Console.Clear();
            Menu.ShowTheSummary();
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
        static bool IsPrime(ulong num)
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
        #endregion
    }
}
