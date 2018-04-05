using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace RH.Manager.ViewModel
{
    public class ActionDelayer
    {
        private readonly DispatcherTimer delayTimer;
        private Action actionToExecute;

        public ActionDelayer()
        {
            delayTimer = new DispatcherTimer();
            delayTimer.Tick += this.ExecuteDelayedAction;
        }

        public void Execute(Action action, TimeSpan delay)
        {
            actionToExecute = action;
            delayTimer.Interval = delay;
            delayTimer.Start();
        }

        public void Cancel()
        {
            delayTimer.Stop();
        }

        private void ExecuteDelayedAction(object sender, EventArgs e)
        {
            delayTimer.Stop();
            if (actionToExecute != null)
            {
                actionToExecute();
            }
        }
    }
}
