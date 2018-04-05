using System;
using System.Linq;
using System.Windows.Data;
using System.Windows.Markup;

namespace RH.Manager.Appearance
{
    public class CRMThemeResourceExtension : MarkupExtension
    {
        public CRMResources Resource { get; set; }

        public CRMThemeResourceExtension()
        {
            
        }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            if (serviceProvider == null)
            {
                throw new ArgumentNullException("serviceProvider");
            }

            if (this.Resource == null)
            {
                throw new ArgumentException("Resource cannot be null.");
            }

            string propertyPath;
            if (CRMThemePalette.TryGetResource(this.Resource, out propertyPath))
            {
                Binding binding = new Binding(propertyPath)
                {
                    Source = CRMThemePalette.Palette,
                    Converter = new ColorToSolidColorBrushConverter(),
                    Mode = BindingMode.OneWay
                };
                return binding.ProvideValue(serviceProvider);
            }

            return null;
        }
    }
}