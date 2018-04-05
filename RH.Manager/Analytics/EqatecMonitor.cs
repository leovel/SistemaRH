using System;
using System.Configuration;
using System.Linq;
using EQATEC.Analytics.Monitor;

namespace RH.Manager.Analytics
{
    public class EqatecMonitor
    {
        private static readonly EqatecMonitor instance = new EqatecMonitor();
        
        private static IAnalyticsMonitor monitor;

        public static EqatecMonitor Instance
        {
            get
            {
                return instance;
            }
        }

        public void TrackFeature(string featureName)
        {
            if (monitor == null)
            {
                return;
            }

            monitor.TrackFeature(featureName);
        }

        public void TrackFeatureStart(string featureName)
        {
            if (monitor == null)
            {
                return;
            }

            monitor.TrackFeatureStart(featureName);
        }

        public void TrackFeatureStop(string featureName)
        {
            if (monitor == null)
            {
                return;
            }

            monitor.TrackFeatureStop(featureName);
        }

        public void TrackFeatureCancel(string featureName)
        {
            if (monitor == null)
            {
                return;
            }

            monitor.TrackFeatureCancel(featureName);
        }

        public void TrackException(Exception exception, string contextMessage = null)
        {
            if (monitor == null)
            {
                return;
            }

            if (string.IsNullOrEmpty(contextMessage))
            {
                monitor.TrackException(exception);
            }
            else
            {
                monitor.TrackException(exception, contextMessage);
            }
        }

        public static void Stop()
        {
            if (monitor != null)
            {
                monitor.Stop();
            }
        }

        public static void TryInitializeMonitor()
        {
            if (monitor != null || 
                AnalyticsConfiguration.IsAnalyticsDisabledInRegistry ||
                !ConfigurationManager.AppSettings.Keys.OfType<string>().Contains(EqatecConstants.EqatecProductKey))
            {
                return;
            }

            string productKey = ConfigurationManager.AppSettings[EqatecConstants.EqatecProductKey];
            if (!string.IsNullOrEmpty(productKey))
            {
                IAnalyticsMonitorSettings settings = AnalyticsMonitorFactory.CreateSettings(productKey);

                monitor = AnalyticsMonitorFactory.CreateMonitor(settings);
                monitor.Start();
            }
        }
    }
}