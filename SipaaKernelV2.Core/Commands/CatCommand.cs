using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SipaaKernelV2.Core.Commands
{
    public class CatCommand : Command
    {
        public CatCommand()
        {
            this.names = new string[] { "cat" };
            this.Description = "View file contents";
            this.usages = new string[] { "cat [file]" };
        }
        public override CommandResult Execute(List<string> args)
        {
            if (args.Count == 0) { return CommandResult.InvalidArgs; }
            var file = args[0];
            if (!file.StartsWith(@"0:\")) { file = Shell.CurrentDir + file; }
            if (!File.Exists(file)) { Console.WriteLine("File don't exists : " + file); }
            Console.WriteLine(File.ReadAllLines(file));

            return CommandResult.Sucess;
        }
    }
}
