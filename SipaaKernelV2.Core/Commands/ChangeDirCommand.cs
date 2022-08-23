using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SipaaKernelV2.Core.Commands
{
    public class ChangeDirCommand : Command
    {
        public ChangeDirCommand()
        {
            this.names = new string[] { "cd" };
            this.Description = "Change current directory";
        }
        public override CommandResult Execute(List<string> args)
        {
            var folder = args[0];

            if (args.Count == 0) { return CommandResult.InvalidArgs; }

            if (folder.StartsWith(@"0:\")) { Shell.CurrentDir = folder; }

            if (!Directory.Exists(folder)) { return CommandResult.InvalidArgs; }

            if (Shell.CurrentDir.EndsWith(@"\")) { Shell.CurrentDir += folder + @"\"; }
            else { Shell.CurrentDir += @"\" + folder + @"\"; }
            return CommandResult.Sucess;
        }
    }
}
