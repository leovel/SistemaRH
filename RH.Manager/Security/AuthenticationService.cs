using RH.DataModel;
using RH.DataModel.Repository;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace RH.Manager.Security
{
    public class AuthenticationService : IAuthenticationService
    {
        public Credencial AuthenticateUser(string username, string clearTextPassword)
        {
            var credencial =  MainRepository.Instance.LoadCredencial(username, MainRepository.Instance.CalculateHash(clearTextPassword));

            if (credencial == null)
                throw new UnauthorizedAccessException("A conta de utilizador ou senha está incorrecto.");

            return credencial;
        }
    }
}