using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Telerik.Windows.Controls;
using Telerik.Windows.Diagrams.Core;
using Telerik.Windows.DragDrop;

namespace RH.Manager.CustomControls
{
    public class OrgChartDiagram : RadDiagram, IScrollingServiceCore, IScrollingInfo
    {
        private Canvas itemsHost;
        private Point currentDragPosition;
        private readonly double autoScrollAreaPadding = 100;
        private readonly double autoScrollStep = 50;
        private readonly TimeSpan autoScrollTimerInterval = TimeSpan.FromSeconds(0.03);

        public OrgChartDiagram() : base()
        {
            DragDropManager.AddDragOverHandler(this, this.OnElementDragOver, true);
            this.InitializeAutoScrollBehavior();
        }

        private void InitializeAutoScrollBehavior()
        {
            ScrollingSettingsBehavior.SetIsEnabled(this, true);
            ScrollingSettingsBehavior.SetScrollAreaPadding(this, new Thickness(this.autoScrollAreaPadding));
            ScrollingSettingsBehavior.SetScrollStep(this, this.autoScrollStep);
            ScrollingSettingsBehavior.SetScrollStepTime(this, this.autoScrollTimerInterval);
        }

        public void UpdateViewportRespectingShape(Point oldShapePosition, Point newShapePosition)
        {
            double diagramXPos = this.Position.X;
            double diagramYPos = this.Position.Y;
            double zoomFactor = this.Zoom;
            double xDiff = oldShapePosition.X - newShapePosition.X;
            double yDiff = oldShapePosition.Y - newShapePosition.Y;

            this.Position = new Point(diagramXPos + (xDiff * zoomFactor), diagramYPos + (yDiff * zoomFactor));
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            this.itemsHost = this.GetTemplateChild("ItemsHost") as Canvas;
        }

        private void OnElementDragOver(object sender, Telerik.Windows.DragDrop.DragEventArgs e)
        {
            this.currentDragPosition = e.GetPosition(this.itemsHost);
        }

        public RadDiagramShape GetShapeUnderDragPosition()
        {
            return this.ServiceLocator.GetService<IHitTestService>().GetTopShapesUnderPoint(this.currentDragPosition).FirstOrDefault() as RadDiagramShape;
        }

        // AutoScroll Behavior.
        public void ScrollHorizontal(double offsetX)
        {
            if (offsetX == 0)
            {
                this.Scroll(autoScrollStep, 0);
            }
            else
            {
                this.Scroll(-autoScrollStep, 0);
            }
        }

        public void ScrollVertical(double offsetY)
        {
            if (offsetY == 0)
            {
                this.Scroll(0, autoScrollStep);
            }
            else
            {
                this.Scroll(0, -autoScrollStep);
            }

        }

        public double ExtentHeight
        {
            get { return this.ActualHeight; }
        }

        public double ExtentWidth
        {
            get { return this.ActualWidth; }
        }

        public double HorizontalOffset
        {
            get { return 0; }
        }

        public Point TransformFromDropTargetToViewPort(Point positionInDropTarget)
        {
            return positionInDropTarget;
        }

        public double VerticalOffset
        {
            get { return 0; }
        }

        public double ViewportHeight
        {
            get { return this.ActualHeight; }
        }

        public double ViewportWidth
        {
            get { return this.ActualWidth; }
        }
    }
}
