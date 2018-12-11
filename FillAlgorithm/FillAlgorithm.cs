using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FillAlgorithm
{
    static class FillAlgorithm
    {
        public static void ScanlineFill(Shape shape, Bitmap bitmap)
        {
            int ymin = shape.GetMinY(), ymax = shape.GetMaxY();
            for(int y = ymin; y <= ymax; y++)
            {
                Point[] points = shape.GetIntersections(y);
                for(int i = 0; i < points.Length - 1; i += 2)
                {
                    int x = points[i].X;
                    while (x < points[i + 1].X)
                        bitmap.SetPixel(x++, y, shape.FillColor);
                }
            }
        }

        // May cause stack-over-flow exception
        public static void BoundaryFill(Bitmap bitmap, int x, int y, Color color, Color boundColor)
        {
            if (x < 0 || x >= bitmap.Width || y < 0 || y >= bitmap.Height)
                return;
            Color current = bitmap.GetPixel(x, y);
            if(current.ToArgb() != boundColor.ToArgb() && current.ToArgb() != color.ToArgb())
            {
                bitmap.SetPixel(x, y, color);
                BoundaryFill(bitmap, x + 1, y, color, boundColor);
                BoundaryFill(bitmap, x - 1, y, color, boundColor);
                BoundaryFill(bitmap, x, y + 1, color, boundColor);
                BoundaryFill(bitmap, x, y - 1, color, boundColor);
            }
        }

        // No stack-overflow exception
        public static void OptimizeBoundaryFill(Bitmap bitmap, int x, int y, Color color, Color boundColor)
        {
            List<Point> Stack = new List<Point>();
            Stack.Add(new Point(x, y));
            while(Stack.Count > 0)
            {
                int xx = Stack[0].X, yy = Stack[0].Y;
                Stack.RemoveAt(0);
                if (xx < 0 || yy < 0 || xx >= bitmap.Width || yy >= bitmap.Height)
                    continue;
                Color current = bitmap.GetPixel(xx, yy);                
                if (current.ToArgb() != boundColor.ToArgb() && current.ToArgb() != color.ToArgb())
                {
                    bitmap.SetPixel(xx, yy, color);
                    Stack.Add(new Point(xx + 1, yy));
                    Stack.Add(new Point(xx - 1, yy));
                    Stack.Add(new Point(xx, yy + 1));
                    Stack.Add(new Point(xx, yy - 1));
                }
            }
        }
    }
}
