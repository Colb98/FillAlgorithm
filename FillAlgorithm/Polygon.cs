using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FillAlgorithm
{
    class Polygon : Shape
    {
        List<Point> Points;
        
        public Polygon(Color strokeColor, Color fillColor)
        {
            Points = new List<Point>();
            StrokeColor = strokeColor;
            FillColor = fillColor;
        }

        public override void Draw(Graphics g)
        {
            if (Points.Count < 3)
                return;
            Pen pen = new Pen(StrokeColor);
            g.DrawPolygon(pen, Points.ToArray());
        }

        public override void Fill(Bitmap b)
        {
            if (Points.Count < 3)
                return;
            FillAlgorithm.ScanlineFill(this, b);
            Draw(Graphics.FromImage(b));
        }

        public void AddPoint(IFormCanUpdateCanvas form, Point point)
        {
            Points.Add(point);
            form.UpdateCanvas();
        }

        public override Point[] GetIntersections(int y)
        {
            List<Point> intersections = new List<Point>();
            int minX = GetMinX();
            int maxX = GetMaxX();

            for(int i = 0; i < Points.Count; i++)
            {
                Point intersection = GetIntersection(y, Points[i], Points[(i+1)%Points.Count]);
                if (intersection.X != -1)
                    intersections.Add(intersection);
            }

            intersections = new List<Point>(intersections.Distinct());
            intersections = new List<Point>(intersections.OrderBy(p => p.X));
            return intersections.ToArray();
        }

        private Point GetIntersection(int y, Point a, Point b)
        {
            if ((a.Y - y) * (b.Y - y) > 0 || b.Y == a.Y)
                return new Point(-1, -1);

            Point ans = new Point((y - a.Y) * (b.X - a.X) / (b.Y - a.Y) + a.X, y);
            //if(ans != a && ans != b)
                return ans;

            return new Point(-1, -1);                
        }

        private int GetMinX()
        {
            if (Points.Count == 0)
                return 0;

            int min = Points[0].X;
            for(int i = 1; i < Points.Count; i++)
            {
                if (min >= Points[i].X)
                    min = Points[i].X;
            }
            return min;
        }

        private int GetMaxX()
        {
            if (Points.Count == 0)
                return 0;

            int max = Points[0].X;
            for (int i = 1; i < Points.Count; i++)
            {
                if (max <= Points[i].X)
                    max = Points[i].X;
            }
            return max;
        }

        public override int GetMinY()
        {
            if (Points.Count == 0)
                return 0;

            int min = Points[0].Y;
            for (int i = 1; i < Points.Count; i++)
            {
                if (min >= Points[i].Y)
                    min = Points[i].Y;
            }
            return min;
        }

        public override int GetMaxY()
        {
            if (Points.Count == 0)
                return 0;

            int max = Points[0].Y;
            for (int i = 1; i < Points.Count; i++)
            {
                if (max <= Points[i].Y)
                    max = Points[i].Y;
            }
            return max;
        }
    }
}
