using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RH.Manager.ViewModel
{
    public static class ThreadContext
    {
        public static void InvokeOnUIThread(Action action)
        {
            if (System.Windows.Application.Current.Dispatcher.CheckAccess())
            {
                action();
            }
            else
            {
                System.Windows.Application.Current.Dispatcher.Invoke(action);
            }
        }

        public static void BeginInvokeOnUIThread(Action action)
        {
            if (System.Windows.Application.Current.Dispatcher.CheckAccess())
            {
                action();
            }
            else
            {
                System.Windows.Application.Current.Dispatcher.BeginInvoke(action);
            }
        }
    }

    public delegate void BackgroundWorkerDoWork(object sender, DoWorkEventArgs e);

    public delegate void BackgroundWorkerRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e);
}
