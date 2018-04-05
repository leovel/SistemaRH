using RH.DataModel.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RH.DataModel
{
    public partial class Credencial
    {
        public string[] Roles
        {
            get
            {
                List<string> roles = new List<string>();
                foreach (Enum flag in EntityFameworkTools.GetEnumValues(typeof(NivelDeCredencial)))
                {
                    if (this.NivelDeAcesso.HasFlag(flag))
                        roles.Add(flag.ToString());
                }

                return roles.ToArray();
            }
        }
    }
}
