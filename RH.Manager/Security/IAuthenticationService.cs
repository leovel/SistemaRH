
using RH.DataModel;

namespace RH.Manager.Security
{
    public interface IAuthenticationService
    {
        Credencial AuthenticateUser(string username, string password);
    }
}