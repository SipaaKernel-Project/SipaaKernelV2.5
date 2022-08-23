using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cosmos.System.FileSystem;
using Cosmos.System.FileSystem.VFS;
using SipaaKernelV2.Core;

namespace SipaaKernelV2.Core.Commands
{
    public class DirectoryListCommand : Command
    {
        public DirectoryListCommand()
        {
            names = new string[] { "dir", "ls" };
            Description = "Show list of files and dirs in current dir";
            usages = new string[] { "disk" };
        }
        public override CommandResult Execute(List<string> args)
        {
            foreach (string dir in Directory.GetDirectories(Shell.CurrentDir))
            {
                FileInfo f = new FileInfo(dir);
                Console.WriteLine(f.Name + " (DIR)");
            }
            foreach (string file in Directory.GetFiles(Shell.CurrentDir))
            {
                FileInfo f = new FileInfo(file);
                Console.WriteLine(f.Name);
            }
            return CommandResult.Sucess;
        }
    }
}
