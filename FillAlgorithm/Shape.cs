using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FillAlgorithm
{
    public abstract class Shape
    {
        public Color StrokeColor { get; set; } = Color.Black;
        public Color FillColor { get; set; } = Color.White;
        public static FillMode Mode { get; set; } = FillMode.ScanlineFill;

        // Draw the outline
        public abstract void Draw(Graphics g);
        public abstract Point[] GetIntersections(int y);
        public abstract void ScanlineFill(Bitmap b);
        public abstract void BoundaryFill(Bitmap b);
        public abstract void OptimizedBoundaryFill(Bitmap b);
        public void Fill(Bitmap b)
        {
            switch (Mode) {
                case FillMode.ScanlineFill:
                    ScanlineFill(b);
                    break;
                case FillMode.BoundaryFill:
                    BoundaryFill(b);
                    break;
                case FillMode.OptimizedBoundaryFill:
                    OptimizedBoundaryFill(b);
                    break;
                default:
                    break;
            }
        }
        public abstract int GetMaxY();
        public abstract int GetMinY();

        public enum FillMode
        {
            ScanlineFill,
            BoundaryFill,
            OptimizedBoundaryFill
        }
    }
}
