using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FillAlgorithm
{
    public partial class MainForm : Form, IFormCanUpdateCanvas
    {
        Color fill;
        Color stroke;
        Bitmap canvas;
        DrawingTool tool = DrawingTool.None;
        BindingList<Shape> shapes;
        bool bDrawPolygon = false;

        enum DrawingTool
        {
            None,
            Ellipse,
            Polygon
        }

        public MainForm()
        {
            InitializeComponent();
            fill = Color.White;
            stroke = Color.Black;
            canvas = new Bitmap(drawPanel.Width, drawPanel.Height);
            drawPanel.Image = canvas;
            shapes = new BindingList<Shape>();
            listLayers.DataSource = shapes;            
        }

        private void btn_ellipse_Click(object sender, EventArgs e)
        {
            tool = DrawingTool.Ellipse;
        }        

        private void btn_polygon_Click(object sender, EventArgs e)
        {
            tool = DrawingTool.Polygon;
        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            shapes.Clear();
            bDrawPolygon = false;
            canvas = new Bitmap(drawPanel.Width, drawPanel.Height);
            drawPanel.Image = canvas;
            tool = DrawingTool.None;
        }

        public void UpdateCanvas()
        {
            canvas = new Bitmap(drawPanel.Width, drawPanel.Height);
            for (int i = 0; i < shapes.Count; i++)
                shapes[i].Fill(canvas);
            drawPanel.Image = canvas;
        }

        private void drawPanel_MouseDown(object sender, MouseEventArgs e)
        {
            switch (tool)
            {
                case DrawingTool.Polygon:
                    if(bDrawPolygon == false)
                    {
                        KeyPreview = true;
                        bDrawPolygon = true;
                        Polygon polygon = new Polygon(stroke, fill);
                        shapes.Add(polygon);
                    }
                    ((Polygon)shapes.Last()).AddPoint(this, e.Location);
                    
                    break;
            }
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                KeyPreview = false;
                bDrawPolygon = false;
            }                
        }
    }
}
