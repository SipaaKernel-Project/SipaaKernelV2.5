﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SipaaKernelV2.Core.Translations
{
    public class EnglishLang : LanguageBase
    {
        public EnglishLang()
        {
            languageName = "english";
            languageVersion = 1.04;
            FSError = "ERROR: Cannot initialize file system! Continuing without file system!";
            InitFS = "Initializing file system...";
            StartingSipaaKernel = "Starting SipaaKernel V2.5...";
            deviceRanIntoAProblem = "Your device ran into a problem and needs to restart.";
            kernelEncountredError = "The Sipaa Kernel encountered an error.";
            ifThisIsFirstTimeError = "If this is the first time you see this error, reboot.";
            ElseReportToSipaaKernelV2Github = "Else, report this bug to the SipaaKernelV2 Github";
            Repository = "repository.";
            PressAnyKeyToReboot = "Press any key to reboot...";
            typeHelpToGetAllCmds = "Type help to get all commands.";
            invalidArgs = "Invalid arguments.";
            fatalErrorDuringCmdExec = "Fatal error occured during command execution.";
            errorDuringCmdExec = "Error occured during the command execution.";
            invalidCmd = "Invalid command!";
            desktop = "Desktop";
            guiDeviceRanIntoAProblem = "Your device ran into a problem...";
            guiReportToSipaaKernelDiscord = "report it to SipaaKernel Discord server.";
            guiSorryForException = "We are sorry for this exception, If this problem continue,";
        }
    }
}
