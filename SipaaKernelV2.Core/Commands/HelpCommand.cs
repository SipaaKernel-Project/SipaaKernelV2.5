using SipaaKernelV2.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SipaaKernelV2.Core.Commands
{
    public class HelpCommand : Command
    {
        public HelpCommand()
        {
            this.names = new string[] { "help" };
            this.Description = "Show all commands / Show command infos";
            this.usages = new string[] { "help", "help [command]" };
        }

        public override CommandResult Execute(List<string> args)
        {
            if (args.Count == 0)
            {
                Console.WriteLine("All commands :");
                foreach(Command c in Shell.cmds)
                {
                    Console.WriteLine(c.names[0] + " : " + c.Description);
                }
                return CommandResult.Sucess;
            }
            else if (args.Count == 1)
            {
                Command cmd = new HelpCommand();
                if (cmd != null)
                {
                    string cmdnames = "";
                    foreach (string name in cmd.names)
                    {
                        cmdnames += name + " ";
                    }
                    Console.WriteLine("Name(s) : " + cmdnames);
                    Console.WriteLine("Description : " + cmd.Description);
                    Console.WriteLine("Usages :");
                    foreach (string usage in cmd.usages)
                    {
                        Console.WriteLine("  " + usage);
                    }
                    return CommandResult.Sucess;
                }
                else
                {
                    return CommandResult.Error;
                }
            }
            else
            {
                return CommandResult.InvalidArgs;
            }
        }
    }
}
