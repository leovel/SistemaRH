using System;
using System.Linq;
using System.Windows;
using System.Windows.Media;
using Telerik.Windows.Controls;

namespace RH.Manager.Appearance
{
    public sealed class CRMThemePalette : Freezable
    {
        private struct PropertyNames
        {
            public const string AccentBrush = "AccentBrush";
            public const string Foreground = "Foreground";
            public const string FontFamily = "FontFamily";
            public const string Background = "Background";
            public const string AlternativeBackground = "AlternativeBackground";
        }

		private static readonly FontFamily defaultFontFamily = new FontFamily("Calibri");
        private static readonly Color defaultAccentBrushColor = Color.FromArgb(0xFF, 0x00, 0x7A, 0xCC);

        private static readonly Color defaultLightForegroundColor = Color.FromArgb(0xFF, 0x00, 0x00, 0x00);
        private static readonly Color defaultLightBackgroundColor = Color.FromArgb(0xFF, 0xFF, 0xFF, 0xFF);
        private static readonly Color defaultLightAlternativeBackgroundColor = Color.FromArgb(0x4C, 0xAB, 0xAB, 0xAB);

        private static readonly Color defaultDarkForegroundColor = Color.FromArgb(0xFF, 0xF1, 0xF1, 0xF1);
        private static readonly Color defaultDarkBackgroundColor = Color.FromArgb(0xFF, 0x2D, 0x2D, 0x30);
        private static readonly Color defaultDarkAlternativeBackgroundColor = Color.FromArgb(0x66, 0x00, 0x00, 0x00);

        private static readonly Color defaultExpressionDarkBackgroundColor = Color.FromArgb(0xFF, 0x33, 0x33, 0x33);

        private static readonly CRMThemePalette palette = new CRMThemePalette();

        static CRMThemePalette()
        {
            Initialize();
        }

        public static CRMThemePalette Palette
        {
            get
            {
                return CRMThemePalette.palette;
            }
        }

        internal static Color AccentBrushColor
        {
            get
            {
                return defaultAccentBrushColor;
            }
        }

        internal static Color LightForegroundColor
        {
            get
            {
                return defaultLightForegroundColor;
            }
        }

        internal static Color LightBackgroundColor
        {
            get
            {
                return defaultLightBackgroundColor;
            }
        }

		internal static Color LightAlternativeBackgroundColor
		{
			get
			{
				return defaultLightAlternativeBackgroundColor;
			}
		}

        internal static Color DarkForegroundColor
        {
            get
            {
                return defaultDarkForegroundColor;
            }
        }

        internal static Color DarkBackgroundColor
        {
            get
            {
                return defaultDarkBackgroundColor;
            }
        }

        internal static Color DarkAlternativeBackgroundColor
        {
            get
            {
                return defaultDarkAlternativeBackgroundColor;
            }
        }

        internal static Color ExpressionDarkBackgroundColor
        {
            get
            {
                return defaultExpressionDarkBackgroundColor;
            }
        }

        public static readonly DependencyProperty AccentBrushProperty =
         DependencyProperty.Register("AccentBrush", typeof(Color), typeof(CRMThemePalette), new PropertyMetadata());

        public static readonly DependencyProperty ForegroundProperty =
          DependencyProperty.Register("Foreground", typeof(Color), typeof(CRMThemePalette), new PropertyMetadata());

        public static readonly DependencyProperty FontFamilyProperty =
          DependencyProperty.Register("FontFamily", typeof(FontFamily), typeof(CRMThemePalette), new PropertyMetadata());

        public static readonly DependencyProperty BackgroundProperty =
            DependencyProperty.Register("Background", typeof(Color), typeof(CRMThemePalette), new PropertyMetadata());

        public static readonly DependencyProperty AlternativeBackgroundProperty =
            DependencyProperty.Register("AlternativeBackground", typeof(Color), typeof(CRMThemePalette), new PropertyMetadata());

        public Color AccentBrush
        {
            get { return (Color)GetValue(AccentBrushProperty); }
            set { SetValue(AccentBrushProperty, value); }
        }

        public Color Foreground
        {
            get { return (Color)GetValue(ForegroundProperty); }
            set { SetValue(ForegroundProperty, value); }
        }

        public FontFamily FontFamily
        {
            get { return (FontFamily)GetValue(FontFamilyProperty); }
            set { SetValue(FontFamilyProperty, value); }
        }

        public Color Background
        {
            get { return (Color)GetValue(BackgroundProperty); }
            set { SetValue(BackgroundProperty, value); }
        }

		public Color AlternativeBackground
		{
			get { return (Color)GetValue(AlternativeBackgroundProperty); }
			set { SetValue(AlternativeBackgroundProperty, value); }
		}

        private static void Initialize()
		{
            palette.AccentBrush = defaultAccentBrushColor;
			palette.Foreground = defaultLightForegroundColor;
			palette.FontFamily = defaultFontFamily; 
			palette.Background = defaultLightBackgroundColor;
			palette.AlternativeBackground = defaultLightAlternativeBackgroundColor;
        }

        internal static bool TryGetResource(CRMResources key, out string resource)
        {
            bool containsResource = false;
            switch (key)
            {
                case CRMResources.AccentBrush:
                    resource = PropertyNames.AccentBrush;
                    containsResource = true;
                    break;
                case CRMResources.Foreground:
                    resource = PropertyNames.Foreground;
                    containsResource = true;
                    break;
                case CRMResources.FontFamily:
                    resource = PropertyNames.FontFamily;
                    containsResource = true;
                    break;
                case CRMResources.Background:
                    resource = PropertyNames.Background;
                    containsResource = true;
					break;
				case CRMResources.AlternativeBackground:
					resource = PropertyNames.AlternativeBackground;
					containsResource = true;
					break;
                default:
                    resource = string.Empty;
                    break;
            }

            return containsResource;
        }

        protected override Freezable CreateInstanceCore()
        {
            throw new NotImplementedException();
        }
    }
}
