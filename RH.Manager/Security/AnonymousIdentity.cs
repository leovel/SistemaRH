using RH.DataModel;
namespace RH.Manager.Security
{
    public class AnonymousIdentity : CustomIdentity
    {
        public AnonymousIdentity()
            : base(0, string.Empty, NivelDeCredencial.ZERO, new string[] { })
        { }
    }
}
