using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FillAlgorithm
{
    abstract class Shape
    {
        public Color StrokeColor { get; set; }
        public Color FillColor { get; set; }

        public abstract void Draw(Graphics g);
        public abstract Point[] GetIntersections(int y);
        public abstract void Fill(Bitmap b);
        public abstract int GetMaxY();
        public abstract int GetMinY();
    }
}
