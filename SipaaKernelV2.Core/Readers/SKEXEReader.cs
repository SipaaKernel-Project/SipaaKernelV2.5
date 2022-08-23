using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SipaaKernelV2.Core.Readers
{
    public enum SKEXEReaderState
    {
        ReaderNotInitialized,
        FileDontExists,
        FileCantBeExecuted,
        FileCanBeExecuted,
        Error,
        Sucess
    }

    public class SKEXEReader
    {
        private bool isInitialized;
        private List<Component> includedComponents;

        public SKEXEReader()
        {
            includedComponents = new List<Component>();
            isInitialized = true;
        }
        public SKEXEReaderState IsFileCanBeExecuted(string path)
        {
            if (!isInitialized) return SKEXEReaderState.ReaderNotInitialized;
            if (!File.Exists(path)) return SKEXEReaderState.FileDontExists;

            FileInfo f = new FileInfo(path);

            if (f.Extension != ".skexe") return SKEXEReaderState.FileCantBeExecuted;

            return SKEXEReaderState.FileCanBeExecuted;
        }

        public SKEXEReaderState ReadAndRunFile(string path)
        {
            if (!isInitialized) return SKEXEReaderState.ReaderNotInitialized;
            var value = IsFileCanBeExecuted(path);
            if (value != SKEXEReaderState.FileCanBeExecuted) return value;

            string[] lines = File.ReadAllLines(path);

            foreach (string line in lines)
            {
                if (line.StartsWith("//")) { break; }
                else if (line.StartsWith("#include"))
                {
                    includedComponents.Add(GetComponent(line.Split(' ')[1]));
                }
                else if (line.EndsWith("();"))
                {
                    RunMethod(line);
                }
            }

            return SKEXEReaderState.Sucess;
        }
        #region Reader fuctions
        void RunMethod(string line)
        {
            if (line.StartsWith("Power.Shutdown"))
            {
                if (ComponentIncluded(Component.SipaaKernelCorePower))
                {
                    Cosmos.System.Power.Shutdown();
                }
            }
            else if (line.StartsWith("Power.Reboot"))
            {
                if (ComponentIncluded(Component.SipaaKernelCorePower))
                {
                    Cosmos.System.Power.Reboot();
                }
            }
            else if (line.StartsWith("Power.QEMUShutdown"))
            {
                if (ComponentIncluded(Component.SipaaKernelCorePower))
                {
                    Cosmos.System.Power.QemuShutdown();
                }
            }
            else if (line.StartsWith("Power.QEMUReboot"))
            {
                if (ComponentIncluded(Component.SipaaKernelCorePower))
                {
                    Cosmos.System.Power.QemuReboot();
                }
            }
        }
        bool ComponentIncluded(Component c)
        {
            foreach (Component c2 in includedComponents)
            {
                if (c2 == c) return true;
            }
            return false;
        }
        Component GetComponent(string line)
        {
            switch (line)
            {
                case "SipaaKernel.Core.Power":
                    return Component.SipaaKernelCorePower;
                default:
                    return Component.Unknown;
            }
        }
        #endregion

        #region Reader enums
        private enum Component
        {
            SipaaKernelCorePower,
            Unknown
        }
        #endregion
    }
}
