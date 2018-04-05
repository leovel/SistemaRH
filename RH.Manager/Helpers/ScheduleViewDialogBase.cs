using System;
using System.Windows.Controls;

namespace RH.Manager
{
    /// <summary>
    /// A base class for RadScheduleView's dialog host that will be used in different modules. 
    /// Needed to be able to enable AncestorType Binding in styles without referring the dll owning the concrete implementation
    /// </summary>
    public class ScheduleViewDialogBase : ContentControl
    {

    }
}
