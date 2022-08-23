using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SipaaKernelV2.Core.Readers;
namespace SipaaKernelV2.Core.Commands
{
    public class RunCommand : Command
    {
        public RunCommand()
        {
            this.names = new string[] { "run" };
            this.Description = "Run .skexe file";
            this.usages = new string[] { "run 'filepath'" };
        }
        public override CommandResult Execute(List<string> args)
        {
            Console.Write("Do you want run this file? (y for yes) ");
            if (Console.ReadLine() == "y")
            {
                SKEXEReader r = new SKEXEReader();
                if (r.IsFileCanBeExecuted(args[0]) == SKEXEReaderState.FileCanBeExecuted) { r.ReadAndRunFile(args[0]); return CommandResult.Sucess; }
                else return CommandResult.Error;
            }
            return CommandResult.Sucess;
        }
    }
}
