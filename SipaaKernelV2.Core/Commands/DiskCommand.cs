using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cosmos.System.FileSystem;
using Cosmos.System.FileSystem.VFS;
using SipaaKernelV2.Core;

namespace SipaaKernelV2.Core.Commands
{
    public class DiskCommand : Command
    {
        public DiskCommand()
        {
            names = new string[] { "disk" };
            Description = "Display informations for all disks";
            usages = new string[] { "disk" };
        }
        public override CommandResult Execute(List<string> args)
        {
            List<Disk> disks = VFSManager.GetDisks();
            foreach (Disk disk in disks)
            {
                disk.DisplayInformation();
            }
            return CommandResult.Sucess;
        }
    }
}
