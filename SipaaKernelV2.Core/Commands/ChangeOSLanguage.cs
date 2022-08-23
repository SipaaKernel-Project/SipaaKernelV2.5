using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SipaaKernelV2.Core.FileSystem;
using SipaaKernelV2.Core.Translations;
namespace SipaaKernelV2.Core.Commands
{
    public class ChangeOSLanguage : Command
    {
        public ChangeOSLanguage()
        {
            this.names = new string[] { "changeoslang", "chosl" };
            this.Description = "Change the keyboard layout";
            this.usages = new string[] { "changekbl", "changekbl [keyboardlayout]", "chkbl", "chkbl [keyboardlayout]" };
        }
        public override CommandResult Execute(List<string> args)
        {
            if (args.Count == 0)
            {
                Console.WriteLine("All languages");
                Console.WriteLine("french : French language");
                Console.WriteLine("english : English (USA) language");
                Console.WriteLine("WARNING : If you find non-translated text in the OS,this is normal.");
                Console.WriteLine("Because i don't implemented language in all the OS.");
                return CommandResult.Sucess;
            }
            else if (args.Count == 1)
            {
                if (args[0] == "french")
                {
                    Kernel.language = new FrenchLang();
                    Console.WriteLine("La langue a ete change avec succes!");
                    SystemConfig.SaveConfig();
                    return CommandResult.Sucess;
                }
                else if (args[0] == "english")
                {
                    Kernel.language = new EnglishLang();
                    Console.WriteLine("The language has been changed with sucess!");
                    SystemConfig.SaveConfig();
                    return CommandResult.Sucess;
                }
                else
                {
                    return CommandResult.InvalidArgs;
                }
            }
            else
            {
                return CommandResult.InvalidArgs;
            }
        }
    }
}
