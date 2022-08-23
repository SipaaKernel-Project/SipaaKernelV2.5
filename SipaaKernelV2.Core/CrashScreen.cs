using System;

namespace SipaaKernelV2.Core
{
    public class CrashScreen
    {
        public static void DisplayAndReboot(string message)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("  :(");
            Console.WriteLine();
            Console.WriteLine("  " + Kernel.language.deviceRanIntoAProblem);
            Console.WriteLine();
            Console.WriteLine("  " + message);
            Console.WriteLine();
            Console.WriteLine("  " + Kernel.language.ifThisIsFirstTimeError);
            Console.WriteLine("  " + Kernel.language.ElseReportToSipaaKernelV2Github);
            Console.WriteLine("  " + Kernel.language.Repository);
            Console.WriteLine();
            Console.WriteLine("  " + Kernel.language.PressAnyKeyToReboot);
            Console.ReadKey();
            Cosmos.System.Power.Reboot();
        }
        public static void DisplayKernelErrorAndReboot(string message)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("  " + Kernel.language.kernelEncountredError);
            Console.WriteLine();
            Console.WriteLine("  " + message);
            Console.WriteLine();
            Console.WriteLine("  " + Kernel.language.ifThisIsFirstTimeError);
            Console.WriteLine("  " + Kernel.language.ElseReportToSipaaKernelV2Github);
            Console.WriteLine("  " + Kernel.language.Repository);
            Console.WriteLine();
            Console.WriteLine("  " + Kernel.language.PressAnyKeyToReboot);
            Console.ReadKey();
            Cosmos.System.Power.Reboot();
        }
    }
}