using Prism.Commands;
using RH.Manager.Appearance;
using RH.Manager.Security;
using System;
using System.Threading;
using System.Windows.Input;
using System.Windows.Threading;
using Telerik.Windows.Controls;

namespace RH.Manager.ViewModel
{
    public sealed class OpenSessionViewModel : RHBindableBase
    {
        #region SINGLETON

        private static readonly Lazy<OpenSessionViewModel> lazy = new Lazy<OpenSessionViewModel>(() => new OpenSessionViewModel(LoginViewModel.Instance));

        public static OpenSessionViewModel Instance
        {
            get
            {
                return lazy.Value;
            }
        }

        private OpenSessionViewModel(RHBindableBase precedent)
            : base(precedent)
        {
            Initialize();
        }

        private DispatcherTimer progressValueTimer = new DispatcherTimer { Interval = TimeSpan.FromMilliseconds(1000) };
        private void Initialize()
        {
            Content = OrganigramaVM;
            OrganigramaVM.Parent = this;

            progressValueTimer.Tick += OnProgressValueTimerTick;
            LogOffCommand = new Telerik.Windows.Controls.DelegateCommand(LogOffCommandExecuted, param => Content == null || Content.CanLogoff);
            SetContentCommand = new Telerik.Windows.Controls.DelegateCommand(param =>SetContentCommandExecuted(param));
            progressValueTimer.Start();

            this.ChangeAppearanceCommand = new DelegateCommand<AppearanceCommandParameter>(this.ChangeTheme);

            this.CurrentTheme = Themes.Office2013;
            this.ColorVariation = ColorVariations.Light;

            this.timer.Interval = TimeSpan.FromMilliseconds(580);
            this.timer.Tick += timer_Tick;
        }
        #endregion SINGLETON  

        private CustomIdentity CurrentIdentity
        {
            get { return Thread.CurrentPrincipal.Identity as CustomIdentity; }
        }



        public ICommand LogOffCommand { get; private set; }
        private void LogOffCommandExecuted(object param)
        {
            CustomPrincipal customPrincipal = Thread.CurrentPrincipal as CustomPrincipal;
            if (customPrincipal != null)
            {
                GoBack();
                Content.OnLogoff();
                Content = DashBoardViewModel.Instance;

                customPrincipal.Identity = new AnonymousIdentity();
                RaisePropertyChanged(nameof(IsAuthenticated));
            }
        }

        public string FotoURI
        {
            get
            {
                return CurrentIdentity.FotoURI;
            }
        }
        public string NombreCompleto
        {
            get
            {
                return CurrentIdentity.Name; 
            }
        }

        private void OnProgressValueTimerTick(object sender, EventArgs e)
        {
            ThreadContext.InvokeOnUIThread(() =>
            {
                RaisePropertyChanged(nameof(CurrentDateTime));
            });
        }

        public ICommand SetContentCommand { get; private set; }
        private void SetContentCommandExecuted(object param)
        {
            var newContent = param as RHBindableBase;
            if(newContent != null && Content != newContent)
            {
                Content = newContent;
                newContent.Parent = this;
            }
           
        }

        private bool isLoadingData;
        private bool isLoadingModule;
        private bool isSettingsPanelShown = false;
        private bool isInitialLoading = true;
        private bool canExecuteShowSettingsPanelCommand = true;
        private DispatcherTimer timer = new DispatcherTimer();
        void timer_Tick(object sender, EventArgs e)
        {
            this.canExecuteShowSettingsPanelCommand = true;
            (this.ShowSettingsPanelCommand as DelegateCommand<bool?>).RaiseCanExecuteChanged();
            this.timer.Stop();
        }

        public void ShowSettingsPanel(bool? parameter)
        {
            bool shouldShow = parameter ?? this.isSettingsPanelShown;
            if (shouldShow)
            {
                //this.RegionManager.RequestNavigate(RegionNames.SubHeader, "SettingsView");
            }
            else
            {
                //var region = this.RegionManager.Regions[RegionNames.SubHeader];
                //foreach (var view in region.ActiveViews)
                //{
                //    SettingsView settingsView = view as SettingsView;
                //    if (view != null)
                //    {
                //        settingsView.PlayUnloadAnimation(region);
                //    }
                //}
            }

            this.isSettingsPanelShown = !this.isSettingsPanelShown;

            if (!this.isInitialLoading)
            {
                this.canExecuteShowSettingsPanelCommand = false;
                (this.ShowSettingsPanelCommand as DelegateCommand<bool?>).RaiseCanExecuteChanged();
                this.timer.Start();
            }
            else
            {
                this.isInitialLoading = false;
            }
        }

        public ICommand ShowSettingsPanelCommand { get; private set; }

        private void ChangeTheme(AppearanceCommandParameter parameter)
        {
            if (this.CurrentTheme == parameter.Theme &&
                this.ColorVariation == parameter.ColorVariation)
            {
                return;
            }

            this.CurrentTheme = parameter.Theme;
            this.ColorVariation = parameter.ColorVariation;

            AppearanceManager.ChangeAppearance(this.CurrentTheme, this.ColorVariation);
        }

        public ICommand ChangeAppearanceCommand { get; private set; }

        public ColorVariations ColorVariation { get; private set; }

        public Themes CurrentTheme { get; private set; }

        #region Property
        public DateTime CurrentDateTime
        {
            get { return DateTime.Now; }
        }

        public ActividadesViewModel ActividadesVM => ActividadesViewModel.Instance;
        public FuncionariosViewModel FuncionariosVM => FuncionariosViewModel.Instance;
        public DashBoardViewModel DashboardVM => DashBoardViewModel.Instance;
        public OrgChartViewModel OrganigramaVM => OrgChartViewModel.Instance;
        public SalariosViewModel SalariosVM => SalariosViewModel.Instance;
        #endregion
    }
}
