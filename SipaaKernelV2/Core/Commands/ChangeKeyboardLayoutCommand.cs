using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sys = Cosmos.System;
using Cosmos.System.ScanMaps;
using SipaaKernelV2.Core;

namespace SipaaKernelV2.Core.Commands
{
    internal class ChangeKeyboardLayoutCommand : Command
    {
        public ChangeKeyboardLayoutCommand()
        {
            this.names = new string[] { "changekbl", "chkbl" };
            this.Description = "Change the keyboard layout";
            this.usages = new string[] { "changekbl", "changekbl [keyboardlayout]", "chkbl", "chkbl [keyboardlayout]" };
        }
        public override CommandResult Execute(List<string> args)
        {
            if (args.Count == 0)
            {
                Console.WriteLine("All keyboard languages");
                Console.WriteLine("french : French keyboard");
                Console.WriteLine("english : English (USA) keyboard");
                return CommandResult.Sucess;
            }else if (args.Count == 1)
            {
                if (args[0] == "french")
                {
                    Sys.KeyboardManager.SetKeyLayout(new FR_Standard());
                    return CommandResult.Sucess;
                }
                else if (args[0] == "english")
                {
                    Sys.KeyboardManager.SetKeyLayout(new US_Standard());
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
