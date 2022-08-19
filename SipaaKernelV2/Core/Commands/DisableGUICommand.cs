using SipaaKernelV2.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SipaaKernelV2.Core.Commands
{
    internal class DisableGUICommand : Command
    {
        public DisableGUICommand()
        {
            this.names = new string[] { "disablegui" };
            this.Description = "Disable GUI mode";
            this.usages = new string[] { "disablegui" };
        }
        public override CommandResult Execute(List<string> args)
        {
            Console.WriteLine("After this operation, the GUI mode is GONE for this instance of SipaaKernel V2");
            Console.WriteLine("Are you sure you want do this? (y for yes, n for no");
            switch (Console.ReadLine())
            {
                case "y":
                    Kernel.DisableGUI = true;
                    break;
                case "n": break;
            }
            return CommandResult.Sucess;
        }
    }
}
