using SipaaKernelV2.Core.Translations;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SipaaKernelV2.Core.FileSystem
{
    public class SystemConfig
    {
        static string file = @"0:\SipaaKernel\config.skcfg";
        static string[] DefaultConfig = new string[] {
        "language=english" /**+ "\n" **/};
        public static void LoadConfig()
        {
            if (!File.Exists(file))
            {
                if (!Directory.Exists(@"0:\SipaaKernel")) { Directory.CreateDirectory(@"0:\SipaaKernel"); }File.Create(file);  SaveDefaultConfig(); LoadConfig(); 
            }
            else
            {

                try
                {
                    string[] lines = File.ReadAllLines(file);

                    foreach (string line in lines)
                    {
                        string[] args = line.Split('=');

                        // load config attributes
                        if (args[0] == "language") { switch (args[1]) { case "english": Kernel.language = new EnglishLang(); break; case "french": Kernel.language = new FrenchLang(); break; default: Console.WriteLine("Unknown language : " + args[1]); Kernel.language = new EnglishLang(); break; } }
                    }
                }
                // unexpected error!
                catch (Exception ex)
                {
                    Console.WriteLine("Error loading system configuration file!", ConsoleColor.Red);
                }
            }
        }
        public static void SaveDefaultConfig()
        {
            if (!Directory.Exists(@"0:\SipaaKernel")) { Directory.CreateDirectory(@"0:\SipaaKernel"); }
            // attempt save
            try { File.WriteAllLines(file, DefaultConfig); }
            // unexpected error
            catch (Exception ex)
            {
                Console.WriteLine("Error occured while trying to save system configuration!", ConsoleColor.Red);
            }
        }
        public static void SaveConfig()
        {
            if (!Directory.Exists(@"0:\SipaaKernel")) { Directory.CreateDirectory(@"0:\SipaaKernel"); }
            string[] lines = new string[] {};

            // write attributes
            lines[0] = "language=" + Kernel.language.languageName;

            // attempt save
            try { File.WriteAllLines(file, lines); }
            // unexpected error
            catch (Exception ex)
            {
                Console.WriteLine("Error occured while trying to save system configuration!", ConsoleColor.Red);
            }
        }
    }
}
