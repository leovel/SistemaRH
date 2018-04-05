using System;
using System.Linq;

namespace RH.Manager.Analytics
{
    public static class EqatecConstants
    {
        public const string EqatecProductKey = "eqatecProductKey";

        // crashes
        public const string ApplicationCrash = "Application.Crash";

        // features to get time
        public const string ApplicationStartupTime = "Application.StartUpTime"; // the time between the app launch and the home view loaded
        public const string ApplicationUptime = "Application.UpTime";

        // themes to track
        public const string Theme = "Theme";

        // views to track
        public const string ViewDashboardUpTime = "Views.DashboardUpTime";
        public const string ViewAreasUpTime = "Views.AreasUpTime";
        public const string ViewFuncionariosUpTime = "Views.FuncionariosUpTime";
        public const string ViewActividadesUpTime = "Views.ActividadesUpTime";
        public const string ViewAfectacoesUpTime = "Views.AfectacoesUpTime";
    }
}