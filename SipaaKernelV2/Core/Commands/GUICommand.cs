using SipaaKernelV2.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SipaaKernelV2.Core.Commands
{
    internal class GUICommand : Command
    {
        public GUICommand()
        {
            this.names = new string[] { "gui" };
            this.Description = "Go to GUI mode of SipaaKernel";
            this.usages = new string[] { "gui" };
        }
        public override CommandResult Execute(List<string> args)
        {
            Kernel.GoToGUIMode();
            return CommandResult.ExitGetInput;
        }
    }
}
