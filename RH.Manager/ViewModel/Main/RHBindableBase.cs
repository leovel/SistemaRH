using Prism.Regions;
using RH.Manager.Security;
using System;
using System.ComponentModel;
using System.ComponentModel.Composition;
using System.Threading;
using System.Windows;
using Telerik.Windows.Controls;

namespace RH.Manager.ViewModel
{
    public class RHBindableBase : ViewModelBase, IPartImportsSatisfiedNotification, INavigationAware
    {
        public RHBindableBase()
            : base()
        {
        }

        private string header;

        public string Header
        {
            get { return header; }
            set
            {
                if(header != value)
                {
                    header = value;
                    RaisePropertyChanged();
                }
            }
        }

        public RHBindableBase(RHBindableBase precedent) : this()
        {
            if (precedent != null)
            {
                Precedent = precedent;
                Parent = precedent.Parent;
            }
        }

        #region Principal
        public CustomPrincipal CurrentPrincipal
        {
            get
            {
                return Thread.CurrentPrincipal as CustomPrincipal;
            }
        }
        #endregion

        #region Usuario
        public CustomIdentity CurrentUser
        {
            get
            {
                return CurrentPrincipal?.Identity;
            }
        }
        #endregion

        #region Login Check
        public bool IsAuthenticated => CurrentUser != null && CurrentUser.IsAuthenticated;
        #endregion

        #region Navigation
        private RHBindableBase content;
        public RHBindableBase Content
        {
            get { return content; }
            set
            {
                if (content != value)
                {
                    content = value;
                    RaisePropertyChanged();
                }
            }
        }

        private RHBindableBase parent;
        public RHBindableBase Parent
        {
            get { return parent; }
            set
            {
                if (parent != value)
                {
                    parent = value;
                    RaisePropertyChanged();
                }
            }
        }

        private RHBindableBase precedent;
        public RHBindableBase Precedent
        {
            get { return precedent; }
            set
            {
                if (precedent != value)
                {
                    precedent = value;
                    RaisePropertyChanged();
                }
            }
        }

        protected bool CanGoBack
        {
            get { return Parent != null && Precedent != null; }
        }

        protected void GoBack()
        {
            if (CanGoBack)
            {
                Parent.Content = Precedent;
            }
            else
            {
                ThreadContext.InvokeOnUIThread(() =>
                {
                    //RadMessageBox.Show("Este visual não esta habilitado para voltar", "Imposível Voltar", MessageBoxButton.OK, MessageBoxImage.Error);
                    RadWindow.Alert(new DialogParameters { Header = "Imposível Voltar", Content = "Este visual não esta habilitado para voltar" });
                });
            }
        }

        public void Disconect()
        {
            Parent = null;
            Precedent = null;
            Content = null;
        }

        #endregion

        #region Exception
        public virtual void HandledException(Exception e)
        {
            string message = "Detalhes:\n\n";
            message += e.GetType().ToString() + " => " + e.Message;

            Exception inner = e.InnerException;
            while (inner != null)
            {
                message += "\n" + inner.GetType().ToString() + " => " + inner.Message;
                inner = inner.InnerException;
            }

            ThreadContext.InvokeOnUIThread(() =>
            {
                RadWindow.Alert(new DialogParameters { Header = "Erro", Content = message });
            });
        }
        #endregion

        #region Operation Wating

        private bool isBusy;
        public bool IsBusy
        {
            get { return isBusy; }
            set
            {
                if (isBusy != value)
                {
                    RaisePropertyChanged();
                    RaisePropertyChanged(nameof(CanLogoff));
                }
            }
        }

        private string busyContent;
        public string BusyContent
        {
            get { return busyContent; }
            set
            {
                if(busyContent != value)
                {
                    busyContent = value;
                    RaisePropertyChanged();
                }
            }
        }

        private double progressValue;
        public double ProgressValue
        {
            get { return progressValue; }
            set
            {
                if (progressValue != value)
                {
                    progressValue = value;
                    RaisePropertyChanged();
                }
            }
        }

        private bool busyIndicatorIsIndeterminate;
        public bool BusyIndicatorIsIndeterminate
        {
            get { return busyIndicatorIsIndeterminate; }
            set
            {
                if (busyIndicatorIsIndeterminate != value)
                {
                    busyIndicatorIsIndeterminate = value;
                    RaisePropertyChanged();
                }
            }
        }
        #endregion

        #region OnLogOff
        internal virtual void OnLogoff()
        {
            Clear();
        }

        internal virtual bool CanLogoff
        {
            get { return !IsBusy; }
        }
        #endregion

        #region Clear
        protected virtual void Clear()
        {

        }
        #endregion

        #region From CRM_WPF Project
        /// <summary>
        /// Triggers data update if a data update condition is satisfied.
        /// Subclasses can implement this to provide their own conditions and specific trigger actions.
        /// </summary>
        protected virtual void TriggerConditionalDataUpdate()
        {
            if (IsDataUpdateConditionSatisfied)
            {
                OnDataUpdateTriggered();
            }
        }

        /// <summary>
        /// Callback from TriggerConditionalDataUpdate when IsDataUpdateConditionSatisfied is true.
        /// Subclasses should implement this to provide their own actions.
        /// Default implementation is empty.
        /// </summary>
        protected virtual void OnDataUpdateTriggered()
        {

        }

        /// <summary>
        /// Callback when all MEF imports are satisfied.
        /// Subclasses implement this if they need to perform some actions after the viewmodel is completely loaded.
        /// Inherited from IPartImportsSatisfiedNotification.
        /// </summary>
        public virtual void OnImportsSatisfied()
        {

        }

        /// <summary>
        /// The condition that is checked when TriggerConditionalDataUpdate is called.
        /// Subclasses can implement this to provide their own conditions.
        /// </summary>
        protected virtual bool IsDataUpdateConditionSatisfied
        {
            get
            {
                return HasViewLoadedOnce && DataHasPendingUpdates;
            }
        }

        private bool hasViewLoadedOnce;
        /// <summary>
        /// Gets or sets whether the view belonging to this viewmodel has been navigated to at least once.
        /// Default implementation triggers conditional data update when setting true values.
        /// </summary>
        protected virtual bool HasViewLoadedOnce
        {
            get
            {
                return hasViewLoadedOnce;
            }

            set
            {
                hasViewLoadedOnce = value;
                if (value)
                {
                    TriggerConditionalDataUpdate();
                }
            }
        }

        private bool dataHasPendingUpdates;
        /// <summary>
        /// Gets or sets whether the data belonging to this viewmodel should be updated later in time.
        /// Default implementation triggers conditional data update when setting true values.
        /// </summary>
        protected virtual bool DataHasPendingUpdates
        {
            get
            {
                return dataHasPendingUpdates;
            }

            set
            {
                dataHasPendingUpdates = value;
                if (value)
                {
                    TriggerConditionalDataUpdate();
                }
            }
        }

        /// <summary>
        /// Inherited from INavigationAware.
        /// Default implementation sets HasViewLoadedOnce to true.
        /// Subclasses can override this to implement functionality when the viewmodel is navigated to.
        /// </summary>
        /// <param name="navigationContext">The navigation context.</param>
        public virtual void OnNavigatedTo(NavigationContext navigationContext)
        {
            HasViewLoadedOnce = true;
        }

        /// <summary>
        /// Inherited from INavigationAware.
        /// Shows whether this viewmodel is a navigation target.
        /// Subclasses can override this if they don't want to be navigated to.
        /// </summary>
        /// <param name="navigationContext">The navigation context.</param>
        /// <returns>Whether this viewmodel is a navigation target.</returns>
        public virtual bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        /// <summary>
        /// Inherited from INavigationAware.
        /// Default implementation is empty.
        /// Subclasses can override this to implement functionality when the viewmodel is navigated from.
        /// </summary>
        /// <param name="navigationContext">The navigation context.</param>
        public virtual void OnNavigatedFrom(NavigationContext navigationContext)
        {

        }
        #endregion
    }
}
