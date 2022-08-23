﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SipaaKernelV2.Core
{
    public class LanguageBase
    {
        #region Language info
        public string languageName;
        public double languageVersion;
        #endregion
        #region Startup
        public string InitFS,FSError, StartingSipaaKernel;
        #endregion
        #region Kernel
        public string
            deviceRanIntoAProblem,
            kernelEncountredError,
            ifThisIsFirstTimeError,
            ElseReportToSipaaKernelV2Github,
            Repository,
            PressAnyKeyToReboot;
        #endregion
        #region Shell
        public string typeHelpToGetAllCmds,
            errorDuringCmdExec,
            invalidArgs,
            fatalErrorDuringCmdExec,
            invalidCmd;
        #endregion
        #region GUI (SipaaDesktop)
        public string desktop;

        #endregion
        #region GUI (Crash Screen)
        public string guiDeviceRanIntoAProblem,
            guiSorryForException,
            guiReportToSipaaKernelDiscord;

        #endregion
    }
}
