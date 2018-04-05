using System;

namespace RH.Manager.ViewModel
{
    public sealed class MainViewModel : RHBindableBase
    {
        #region SINGLETON

        private static readonly Lazy<MainViewModel> lazy = new Lazy<MainViewModel>(() => new MainViewModel());

        public static MainViewModel Instance
        {
            get
            {
                return lazy.Value;
            }
        }

        private MainViewModel()
            : base()
        {
            Content = LoginViewModel.Instance;
            LoginViewModel.Instance.Parent = this;
        }
        #endregion SINGLETON
    }
}
