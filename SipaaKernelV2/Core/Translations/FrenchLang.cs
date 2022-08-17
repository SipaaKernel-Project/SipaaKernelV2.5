using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SipaaKernelV2.Core.Translations
{
    internal class FrenchLang : LanguageBase
    {
        public FrenchLang()
        {
            FSError = "ERREUR: Echec de l'initialisation du système de fichiers!";
            InitFS = "Initialisation du système de fichiers...";
            StartingSipaaKernel = "Démarrage de SipaaKernel V2...";
            deviceRanIntoAProblem = "Votre appareil a rencontré un problème et dois redémarrer.";
            kernelEncountredError = "Le noyau Sipaa a rencontré un problème.";
            ifThisIsFirstTimeError = "Si c'est la première fois que vous voyer cette erreur, redémarrer.";
            ElseReportToSipaaKernelV2Github = "Si non, reporter ce bug vers le dépot Github";
            Repository = "de SipaaKernelV2.";
            PressAnyKeyToReboot = "Presser n'importe quelle touche pour redémarrer...";
            typeHelpToGetAllCmds = "Taper help pour obtenir toutes les commandes.";
            invalidArgs = "Arguments invalides.";
            fatalErrorDuringCmdExec = "Erreur fatale durant l'exécution de la commande.";
            errorDuringCmdExec = "Erreur durant l'exécution de la commande.";
            invalidCmd = "Command invalide.";
        }
    }
}
