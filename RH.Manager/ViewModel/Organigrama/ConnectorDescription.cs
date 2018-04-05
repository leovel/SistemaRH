using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace RH.Manager.ViewModel
{
    public class ConnectorDescription
    {
        public ConnectorDescription(string name, Point offset, double canvasLeft, double canvasTop, Visibility visibility)
        {
            this.Name = name;
            this.Offset = offset;
            this.CanvasLeft = canvasLeft;
            this.CanvasTop = canvasTop;
            this.Visibility = visibility;
        }

        public string Name { get; set; }
        public Point Offset { get; set; }
        public double CanvasLeft { get; set; }
        public double CanvasTop { get; set; }
        public Visibility Visibility { get; set; }
    }
}
