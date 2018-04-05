using System;
using System.Linq;

namespace RH.Manager.Appearance
{
    public class AppearanceChangedEventArgs : EventArgs
    {
        public Themes Theme { get; private set; }
        public ColorVariations  ColorVariation { get; private set; }

        public AppearanceChangedEventArgs(Themes theme, ColorVariations colorVariation)
        {
            this.Theme = theme;
            this.ColorVariation = colorVariation;
        }
    }
}