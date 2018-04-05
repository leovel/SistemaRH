using RH.DataModel;
using System.Security.Principal;

namespace RH.Manager.Security
{
    public class CustomIdentity : IIdentity
    {
        public CustomIdentity(int identificador, string name, NivelDeCredencial nivel, string[] roles, string fotoURI = null)
        {
            Identificador = identificador;
            Name = name;
            Nivel = nivel;
            Roles = roles;
            FotoURI = fotoURI;
        }

        public int Identificador { get; private set; }
        public string Name { get; private set; }
        public NivelDeCredencial Nivel { get; private set; }
        public string[] Roles { get; private set; }
        public string FotoURI { get; private set; }

        #region IIdentity Members
        public string AuthenticationType { get { return "Custom authentication"; } }

        public bool IsAuthenticated {
            get
            {
                return !string.IsNullOrWhiteSpace(Name) && Identificador != 0 && Nivel != NivelDeCredencial.ZERO;
            }
        }
        #endregion
    }
}