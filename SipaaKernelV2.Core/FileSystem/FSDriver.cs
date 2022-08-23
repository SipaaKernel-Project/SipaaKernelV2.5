using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cosmos.System.FileSystem;
using Cosmos.System.FileSystem.VFS;

namespace SipaaKernelV2.Core.FileSystem
{
    public class FSDriver
    {
        private static CosmosVFS fs;

        public static bool Initialize()
        {
            try
            {
                fs = new CosmosVFS();
                VFSManager.RegisterVFS(fs, false);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static CosmosVFS GetVFS()
        {
            return fs;
        }
    }
}
