using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telerik.Windows.Controls;
using Telerik.Windows.Diagrams.Core;

namespace RH.Manager.ViewModel
{
    public class TreeLayoutViewModel : RHBindableBase
    {
        private TreeLayoutType currentTreeLayoutType = TreeLayoutType.TreeDown;
        private TreeLayoutSettings currentLayoutSetting;

        public TreeLayoutViewModel()
        {
            this.CurrentLayoutSettings = new TreeLayoutSettings()
            {
                HorizontalSeparation = 80d,
                VerticalSeparation = 100d,
                UnderneathVerticalTopOffset = 50d,
                UnderneathHorizontalOffset = 230d,
                UnderneathVerticalSeparation = 40d,
                VerticalDistance = 10d,
            };
        }

        public event EventHandler LayoutSettingsChanged;

        public TreeLayoutSettings CurrentLayoutSettings
        {
            get
            {
                return this.currentLayoutSetting;
            }
            set
            {
                if (this.currentLayoutSetting != value)
                {
                    this.currentLayoutSetting = value;
                    this.OnPropertyChanged(nameof(CurrentLayoutSettings));
                }
            }
        }

        public double UnderneathHorizontalOffset
        {
            get
            {
                return this.CurrentLayoutSettings.UnderneathHorizontalOffset;
            }
            set
            {
                if (this.CurrentLayoutSettings.UnderneathHorizontalOffset != value)
                {
                    this.CurrentLayoutSettings.UnderneathHorizontalOffset = value;
                    this.OnPropertyChanged(nameof(UnderneathHorizontalOffset));
                    this.OnLayoutSettingsChanged();
                }
            }
        }

        public double UnderneathVerticalTopOffset
        {
            get
            {
                return this.CurrentLayoutSettings.UnderneathVerticalTopOffset;
            }
            set
            {
                if (this.CurrentLayoutSettings.UnderneathVerticalTopOffset != value)
                {
                    this.CurrentLayoutSettings.UnderneathVerticalTopOffset = value;
                    this.OnPropertyChanged(nameof(UnderneathVerticalTopOffset));
                    this.OnLayoutSettingsChanged();
                }
            }
        }

        public double HorizontalSeparation
        {
            get
            {
                return this.CurrentLayoutSettings.HorizontalSeparation;
            }
            set
            {
                if (this.CurrentLayoutSettings.HorizontalSeparation != value)
                {
                    this.CurrentLayoutSettings.HorizontalSeparation = value;
                    this.OnPropertyChanged(nameof(HorizontalSeparation));
                    this.OnLayoutSettingsChanged();
                }
            }
        }

        public double VerticalSeparation
        {
            get
            {
                return this.CurrentLayoutSettings.VerticalSeparation;
            }
            set
            {
                if (this.CurrentLayoutSettings.VerticalSeparation != value)
                {
                    this.CurrentLayoutSettings.VerticalSeparation = value;
                    this.OnPropertyChanged(nameof(VerticalSeparation));
                    this.OnLayoutSettingsChanged();
                }
            }
        }

        public TreeLayoutType CurrentTreeLayoutType
        {
            get
            {
                return this.currentTreeLayoutType;
            }
            set
            {
                if (this.currentTreeLayoutType != value)
                {
                    this.currentTreeLayoutType = value;
                    this.CurrentLayoutSettings.TreeLayoutType = value;
                    this.OnPropertyChanged(nameof(CurrentTreeLayoutType));
                }
            }
        }

        private void OnLayoutSettingsChanged()
        {
            if (this.LayoutSettingsChanged != null)
            {
                this.LayoutSettingsChanged(this, EventArgs.Empty);
            }
        }
    }
}
