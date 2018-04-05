using RH.Manager.Localization;
using RH.Manager.Security;
using RH.Manager.ViewModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Windows;
using Telerik.Windows.Controls;

namespace RH.Manager
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
           this.InitializeComponent();
        }

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            //Create a custom principal with an anonymous identity at startup
            CustomPrincipal customPrincipal = new CustomPrincipal();
            AppDomain.CurrentDomain.SetThreadPrincipal(customPrincipal);

            Thread.CurrentThread.CurrentCulture = new CultureInfo("es");
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("es");

            LocalizationManager.Manager = new CustomLocalizationManager();
            LocalizationManager.DefaultCulture = (new CultureInfo("es"));

            //StyleManager.ApplicationTheme = new Windows8Theme();

        }

        private void Application_Exit(object sender, ExitEventArgs e)
        {
            //Repositorio.Instance.Dispose();
        }

        private void Application_DispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {

            if (e.Exception is System.Security.SecurityException || (e.Exception.InnerException != null && e.Exception.InnerException is System.Security.SecurityException))
            {
                ThreadContext.InvokeOnUIThread(() =>
                {
                    RadWindow.Alert(new DialogParameters() { Header = "Operação Não Autorizada", Content = "Não esta autorizado a fazer esta operação.\nRequere-se uma credencial de nivel superior." });
                    //RadMessageBox.Show("Não esta autorizado a fazer esta operação.\nRequere-se uma credencial de nivel superior.", "Operação Não Autorizada", MessageBoxButton.OK, MessageBoxImage.Stop);
                });

                e.Handled = true;
            }
            else
            {
                string message = "Detalhes:\n\n";
                message += e.Exception.GetType().ToString() + " => " + e.Exception.Message;

                Exception inner = e.Exception.InnerException;
                while (inner != null)
                {
                    message += ".\n" + inner.GetType().ToString() + " => " + inner.Message;
                    inner = inner.InnerException;
                }

                message += ".\n\nA Aplicação Será Fechada.";

                ThreadContext.InvokeOnUIThread(() =>
                {
                    RadWindow.Alert(new DialogParameters() { Header = "Erro Não Esperado", Content = message });
                    //RadMessageBox.Show(message, "Erro Não Esperado", MessageBoxButton.OK, MessageBoxImage.Error);
                });

                e.Handled = true;
                Shutdown();
            }
        }
    }
}
