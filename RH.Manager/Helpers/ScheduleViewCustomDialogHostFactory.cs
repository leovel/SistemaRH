using System.Windows;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.ScheduleView;

namespace RH.Manager
{
    public class ScheduleViewCustomDialogHostFactory : DependencyObject, IScheduleViewDialogHostFactory
    {
        public IScheduleViewDialogHost DialogHost
        {
            get
            {
                return (IScheduleViewDialogHost)GetValue(DialogHostProperty);
            }
            set
            {
                SetValue(DialogHostProperty, value);
            }
        }

        public static readonly DependencyProperty DialogHostProperty =
        DependencyProperty.Register("DialogHost", typeof(IScheduleViewDialogHost), typeof(ScheduleViewCustomDialogHostFactory), null);

        public IScheduleViewDialogHost CreateNew(ScheduleViewBase scheduleView, DialogType dialogType)
        {
            var dialogHost = this.DialogHost;
            dialogHost.Content = new SchedulerDialog();
            
            dialogHost.ScheduleView = scheduleView;

            return dialogHost;
        }
    }
}