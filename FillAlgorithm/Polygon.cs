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

        public override void ScanlineFill(Bitmap b)
        {
            if (Points.Count < 3)
                return;
            FillAlgorithm.ScanlineFill(this, b);
            Draw(Graphics.FromImage(b));
        }

        public override void BoundaryFill(Bitmap b)
        {
            if (Points.Count < 3)
                return;
            Draw(Graphics.FromImage(b));

            int ax, ay;
            GetInsidePixel(out ax, out ay);

            FillAlgorithm.BoundaryFill(b, ax, ay, FillColor, StrokeColor);
        }

        public override void OptimizedBoundaryFill(Bitmap b)
        {
            if (Points.Count < 3)
                return;
            Draw(Graphics.FromImage(b));

            int ax, ay;
            GetInsidePixel(out ax, out ay);

            FillAlgorithm.OptimizeBoundaryFill(b, ax, ay, FillColor, StrokeColor);
        }

        private void GetInsidePixel(out int ax, out int ay)
        {
            // Find a random point "inside" the polygon (assume it only have one simple region)
            // Average X and average Y
            ax = ay = 0;
            for (int i = 0; i < Points.Count; i++)
            {
                ax += Points[i].X;
                ay += Points[i].Y;
            }
            ax /= Points.Count;
            ay /= Points.Count;
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
                Point cur = Points[i], next = Points[(i + 1) % Points.Count], nextnext = Points[(i + 2) % Points.Count];
                Point intersection = GetIntersection(y, cur, next);
                if (intersection == next)
                {
                    // Nếu là đỉnh hoặc thung lũng
                    if ((next.Y > cur.Y && next.Y > nextnext.Y) || (next.Y < cur.Y && next.Y < nextnext.Y))
                        //nothing vì tính là 2 điểm (để ko tô)
                        ;
                    // Ngược lại skip 1 điểm
                    // Trường hợp intersection là điểm đầu của đa giác: mảng sẽ chứa 1 intersection ở đầu và ở cuối
                    // skip bằng cách khác
                    else if (i != Points.Count - 1)
                        i++;
                    // Gán X = -1 để bỏ qua luôn
                    else
                        intersection.X = -1;
                }

                if (intersection.X != -1)
                    intersections.Add(intersection);
            }


            intersections = new List<Point>(intersections.OrderBy(p => p.X));
            return intersections.ToArray();
        }

        private Point GetIntersection(int y, Point a, Point b)
        {
            if ((a.Y - y) * (b.Y - y) > 0 || b.Y == a.Y)
                return new Point(-1, -1);

            Point ans = new Point((y - a.Y) * (b.X - a.X) / (b.Y - a.Y) + a.X, y);

            //Nếu nằm ngoài khoảng giữa 2 điểm thì ko cắt
            if(ans.X < a.X && ans.X < b.X)
                return new Point(-1, -1);
            if (ans.Y < a.Y && ans.Y < b.Y)
                return new Point(-1, -1);
            if (ans.X > a.X && ans.X > b.X)
                return new Point(-1, -1);
            if (ans.Y > a.Y && ans.Y > b.Y)
                return new Point(-1, -1);

            return ans;     
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
