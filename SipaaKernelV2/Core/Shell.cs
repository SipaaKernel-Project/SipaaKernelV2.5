using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SipaaKernelV2.Core.Commands;

namespace SipaaKernelV2.Core
{
    public class Shell
    {
        public static List<Command> cmds = new List<Command>();
        public static string CurrentDir = @"0:\";
        public static bool LoadedCommands = false;

        internal static void LoadCommands()
        {
            LoadedCommands = true;
            Console.WriteLine("SipaaKernel V2");
            Console.WriteLine(Kernel.language.typeHelpToGetAllCmds);
            cmds.Add(new CrashCommand());
            cmds.Add(new SetResolutionCommand());
            cmds.Add(new GUICommand());
            cmds.Add(new HelpCommand());
            cmds.Add(new DiskCommand());
            cmds.Add(new DirectoryListCommand());
            cmds.Add(new ChangeOSLanguage());
            cmds.Add(new ChangeKeyboardLayoutCommand());
            cmds.Add(new CatCommand());
            cmds.Add(new ChangeDirCommand());
            cmds.Add(new SysThemeCommand());
        }

        internal static Command GetCommand(string command)
        {
            for (int i = 0; i < cmds.Count; i++)
            {
                for (int j = 0; j < cmds[i].names.Length; j++)
                {
                    if (command.ToLower() == cmds[i].names[j])
                    {
                        return cmds[i];
                    }
                }
            }
            return null;
        }

        internal static void GetInput()
        {
            Console.WriteLine();
            Console.Write("shell@" + CurrentDir + ":>");
            string input = Console.ReadLine();
            Console.WriteLine();
            string[] pos = input.Split(' ');
            bool exec = false;
            List<string> cmdArgs;

            // Add args into a list
            cmdArgs = new List<string>();
            foreach (string arg in pos)
            {
                cmdArgs.Add(arg);
            }
            // Remove the command name
            cmdArgs.Remove(cmdArgs[0]);

            // Find and execute the command
            for (int i = 0; i < cmds.Count; i++)
            {
                for (int j = 0; j < cmds[i].names.Length; j++)
                {
                    if (pos[0].ToLower() == cmds[i].names[j])
                    {
                        exec = true;
                        var result = cmds[i].Execute(cmdArgs);
                        if (result == CommandResult.Error)
                        {
                            Console.WriteLine(Kernel.language.errorDuringCmdExec);
                        }
                        else if (result == CommandResult.InvalidArgs)
                        {
                            Console.WriteLine(Kernel.language.invalidArgs);
                        }
                        else if (result == CommandResult.Fatal)
                        {
                            throw new Exception(Kernel.language.fatalErrorDuringCmdExec);
                        }
                        else if (result == CommandResult.ExitGetInput)
                        {
                            return;
                        }
                    }
                }
            }

            if (!exec) { Console.WriteLine("Invalid command!", ConsoleColor.Red); }

            GetInput();
        }
    }

    public enum CommandResult
    {
        Sucess,
        Error,
        InvalidArgs,
        Fatal,
        ExitGetInput
    }

    public abstract class Command
    {
        public string[] names;
        public string[] usages;
        public string Description;

        public abstract CommandResult Execute(List<string> args);
    }
}
