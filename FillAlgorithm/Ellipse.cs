using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FillAlgorithm
{
    class Ellipse : Shape
    {
        Point TopLeft, BottomRight;

        public Ellipse(Point start, Point end)
        {
            int t, l, b, r;
            t = Math.Min(start.Y, end.Y);
            l = Math.Min(start.X, end.X);
            b = Math.Max(start.Y, end.Y);
            r = Math.Max(start.X, end.X);

            TopLeft = new Point(l, t);
            BottomRight = new Point(r, b);
        }

        public override void BoundaryFill(Bitmap b)
        {
            Draw(Graphics.FromImage(b));
            Point center = new Point((TopLeft.X + BottomRight.X) / 2, (TopLeft.Y + BottomRight.Y) / 2);
            FillAlgorithm.BoundaryFill(b, center.X, center.Y, FillColor, StrokeColor);
        }

        public override void Draw(Graphics g)
        {
            Pen pen = new Pen(StrokeColor);
            g.DrawEllipse(pen, TopLeft.X, TopLeft.Y, BottomRight.X - TopLeft.X, BottomRight.Y - TopLeft.Y);
        }

        public override Point[] GetIntersections(int y)
        {
            List<Point> intersections = new List<Point>();
            if (y == TopLeft.Y || y == BottomRight.Y)
            {
                intersections.Add(new Point((TopLeft.X + BottomRight.X) / 2, y));
                return intersections.ToArray();
            }
                
            int a = (int)((BottomRight.X - TopLeft.X) * 1.0 / 2 + 0.5);
            int b = (int)((BottomRight.Y - TopLeft.Y) * 1.0 / 2 + 0.5);

            Point center = new Point((int)((TopLeft.X + BottomRight.X) *1.0 / 2 + 0.5), (int)((TopLeft.Y + BottomRight.Y) * 1.0 / 2 + 0.5));
            int yy = y - center.Y; // Move the ellipse to the origin
            int xx = (int)(a * Math.Sqrt(1 - (yy * yy * 1.0 / (b * b))));

            // Move the ellipse back to its position
            intersections.Add(new Point(center.X - xx, y));
            intersections.Add(new Point(center.X + xx, y));
            return intersections.ToArray();
        }

        public override int GetMaxY()
        {
            return BottomRight.Y;
        }

        public override int GetMinY()
        {
            return TopLeft.Y;
        }

        public override void OptimizedBoundaryFill(Bitmap b)
        {
            Draw(Graphics.FromImage(b));
            Point center = new Point((TopLeft.X + BottomRight.X) / 2, (TopLeft.Y + BottomRight.Y) / 2);
            FillAlgorithm.OptimizeBoundaryFill(b, center.X, center.Y, FillColor, StrokeColor);
        }

        public override void ScanlineFill(Bitmap b)
        {
            FillAlgorithm.ScanlineFill(this, b);
            Draw(Graphics.FromImage(b));
        }
    }
}
