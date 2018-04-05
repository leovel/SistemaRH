using RH.DataModel;
using RH.Manager.Security;
using System;
using System.Threading;
using System.Windows.Controls;
using System.Windows.Input;
using Telerik.Windows.Controls;

namespace RH.Manager.ViewModel
{
    public sealed class LoginViewModel : RHBindableBase
    {
        #region SINGLETON

        private static readonly Lazy<LoginViewModel> lazy = new Lazy<LoginViewModel>(() => new LoginViewModel(new AuthenticationService()));

        public static LoginViewModel Instance
        {
            get
            {
                return lazy.Value;
            }
        }

        private readonly IAuthenticationService authenticationService;
        private LoginViewModel(IAuthenticationService authenticationService)
            : base()
        {
            this.authenticationService = authenticationService;
            Header = "LOGIN";
        }
        #endregion SINGLETON        

        #region Properties

        private string username;
        public string Username
        {
            get { return username; }
            set
            {
                if (username != value)
                {
                    username = value;
                    RaisePropertyChanged();
                }
            }
        }

        private string status;
        public string Status
        {
            get { return status; }
            set
            {
                if (status != value)
                {
                    status = value;
                    RaisePropertyChanged();
                    RaisePropertyChanged(nameof(StatusHasValue));
                }
            }
        }

        public bool StatusHasValue
        {
            get { return !string.IsNullOrWhiteSpace(Status); }
        }


        #endregion // Properties

        #region Commands

        #region Login

        private ICommand loginCommand;
        public ICommand LoginCommand
        {
            get
            {
                if (loginCommand == null)
                {
                    loginCommand = new DelegateCommand(Login, param => CanLogin);
                }

                return loginCommand;
            }
        }
        public bool CanLogin
        {
            get { return !IsAuthenticated; }
        }
        private void Login(object parameter)
        {
            RadPasswordBox passwordBox = parameter as RadPasswordBox;
            string clearTextPassword = passwordBox.Password;

            try
            {
                //Validate credentials through the authentication service
                //var credencial = authenticationService.AuthenticateUser(Username, clearTextPassword);

                //Get the current principal object
                CustomPrincipal customPrincipal = Thread.CurrentPrincipal as CustomPrincipal;
                if (customPrincipal == null)
                    throw new ArgumentException("The application's default thread principal must be set to a CustomPrincipal object on startup.");

                //byte[] foto = credencial.RHMEC == "2016492984" ? ClientTools.LoadResourceAsByteArray("Resources/Images/Profile/leovelmini.png") : ClientTools.LoadResourceAsByteArray("Resources/Images/Profile/male.png");

                //Authenticate the user
                //customPrincipal.Identity = new CustomIdentity(credencial.RHMEC, credencial.NomeCompleto, credencial.NivelDeAcceso, credencial.Roles, foto);

                Credencial tempCredencial = new Credencial { NivelDeAcesso = NivelDeCredencial.DEVELOPER };
                customPrincipal.Identity = new CustomIdentity(1, "Francisco Lopes", tempCredencial.NivelDeAcesso, tempCredencial.Roles, @"K:\ZZImages\People\Male\83.jpg");
                //customPrincipal.Identity = new CustomIdentity(1, "Francisco Lopes", tempCredencial.NivelDeAcesso, tempCredencial.Roles, @"D:\My Projects\ZZImages\People\Male\83.jpg");

                //Update UI
                RaisePropertyChanged(nameof(IsAuthenticated));
                Username = string.Empty; //reset
                passwordBox.Password = string.Empty; //reset
                Status = string.Empty;

                Parent.Content = OpenSessionViewModel.Instance;
            }
            catch (UnauthorizedAccessException)
            {
                ThreadContext.InvokeOnUIThread(() =>
                {
                    Status = "Falha no Login:\nO Utilizador ou a palavra passe não é correta";
                });
            }
            catch (Exception ex)
            {
                HandledException(ex);
            }
        }
        #endregion

        #endregion
    }
}
