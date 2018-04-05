using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using CRM.Modules.Repository.Services;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.ScheduleView;

namespace RH.Helpers
{
    public class ScheduleViewCustomDialogHost : ScheduleViewDialogBase, IScheduleViewDialogHost
    {
        public IEnumerable<Opportunity> AvailableOpportunities
        {
            get
            {
                return (IEnumerable<Opportunity>)GetValue(AvailableOpportunitiesProperty);
            }
            set
            {
                SetValue(AvailableOpportunitiesProperty, value);
            }
        }

        // Using a DependencyProperty as the backing store for AvailableOpportunities.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty AvailableOpportunitiesProperty =
        DependencyProperty.Register("AvailableOpportunities", typeof(IEnumerable<Opportunity>), typeof(ScheduleViewCustomDialogHost), new PropertyMetadata(null));

        public ScheduleViewCustomDialogHost()
        {
            this.SaveCommand = new DelegateCommand(this.OnSaveCommandExecuted);
            this.CancelCommand = new DelegateCommand(this.OnCancelCommandExecuted);
        }

        public ICommand SaveCommand { get; set; }
        public ICommand CancelCommand { get; set; }

        public void Close()
        {
            this.UnhookToViewModelPropertyChanged();

            this.Visibility = Visibility.Collapsed;
            
            if (this.Closed != null)
            {
                this.Closed(this, new WindowClosedEventArgs());
            }
        }

        private void OnSaveCommandExecuted(object parameter)
        {
            this.ScheduleView.Commit();
            
            this.Close();
        }

        private void OnCancelCommandExecuted(object parameter)
        {
            this.ScheduleView.Cancel();

            this.Close();
        }

        public event EventHandler<WindowClosedEventArgs> Closed;

        public ScheduleViewBase ScheduleView { get; set; }

        public void Show(bool isModal)
        {
            this.HookToViewModelPropertyChanged();
            
            this.Visibility = Visibility.Visible;
        }
  
        private void HookToViewModelPropertyChanged()
        {
            var viewModel = this.DataContext as AppointmentDialogViewModel;

            viewModel.PropertyChanged += OnViewModelPropertyChanged;
        }

        private void UnhookToViewModelPropertyChanged()
        {
            var viewModel = this.DataContext as AppointmentDialogViewModel;

            viewModel.PropertyChanged -= OnViewModelPropertyChanged;
        }

        void OnViewModelPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            var viewModel = sender as AppointmentDialogViewModel;
            
            if (viewModel.ActualStart > viewModel.ActualEnd)
            {
                viewModel.ActualEnd = viewModel.ActualStart.AddHours(1);
            }
        }
    }
}