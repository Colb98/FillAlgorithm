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
    }
}
