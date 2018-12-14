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
        Bitmap tempCanvas;
        Point start, end;
        DrawingTool tool = DrawingTool.None;
        BindingList<Shape> shapes;
        Shape selectedShape;
        bool bDrawPolygon = false;
        bool bDrawEllipse = false;
        const int TEST_NUM = 1000;
        const int HALF_TEST = 500;

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
            tempCanvas = new Bitmap(drawPanel.Width, drawPanel.Height);
            drawPanel.Image = canvas;
            shapes = new BindingList<Shape>();
            listLayers.DataSource = shapes;
            algorithmList.DataSource = Enum.GetValues(typeof(Shape.FillMode)).Cast<Shape.FillMode>().ToList();
            algorithmList.SelectedItem = Shape.FillMode.ScanlineFill;
            fillColorButton.BackColor = Color.White;
            strokeColorButton.BackColor = Color.Black;
        }

        private void MeasuringProcess()
        {
            // 1000 random objects = 500 ellipse, 500 polygons
            // Each object = 1 bitmap 
            String msg = "";
            List<Shape> testLists = new List<Shape>(TEST_NUM);
            GenerateTestList(testLists);

            // Set different colors for each test
            SetTestListColor(testLists, Color.Aqua);

            // Scanline
            try
            {                
                var watch = System.Diagnostics.Stopwatch.StartNew();
                
                for (int i = 0; i < TEST_NUM; i++)
                    testLists[i].ScanlineFill(new Bitmap(drawPanel.Width, drawPanel.Height));
                    
                watch.Stop();
                var ellapsedMs = watch.ElapsedMilliseconds;
                msg += "Scanline : " + ellapsedMs.ToString() + "ms\n";
            }
            catch (Exception e)
            {
                MessageBox.Show("Some thing wrong \n" + e.Message);
            }
            
            SetTestListColor(testLists, Color.Azure);
            // Scanline
            try
            {
                var watch = System.Diagnostics.Stopwatch.StartNew();
                for (int i = 0; i < TEST_NUM; i++)
                    testLists[i].OptimizedBoundaryFill(new Bitmap(drawPanel.Width, drawPanel.Height));

                watch.Stop();
                var ellapsedMs = watch.ElapsedMilliseconds;
                msg += "Improved Boundary Fill : " + ellapsedMs.ToString() + "ms\n";
            }
            catch(Exception e)
            {
                MessageBox.Show("Some thing wrong \n" + e.Message);
            }

            MessageBox.Show(msg, "Result", MessageBoxButtons.OK);
        }

        private void SetTestListColor(List<Shape> testLists, Color color)
        {
            for (int i = 0; i < testLists.Count; i++)
                testLists[i].FillColor = color;
        }

        private void GenerateTestList(List<Shape> testLists)
        {
            Random r = new Random();
            for (int i = 0; i < HALF_TEST; i++)
            {
                int[] coord = new int[4];
                coord[0] = r.Next(5, drawPanel.Width - 5);
                coord[1] = r.Next(5, drawPanel.Height - 5);
                coord[2] = r.Next(5, drawPanel.Width - 5);
                coord[3] = r.Next(5, drawPanel.Height - 5);

                Ellipse e = new Ellipse(new Point(coord[0], coord[1]), new Point(coord[2], coord[3]));
                testLists.Add(e);
            }

            for (int i = 0; i < HALF_TEST; i++)
            {
                // Số cạnh
                int n = r.Next(3, 10);
                Polygon p = new Polygon();
                for (int j = 0; j < n; j++)
                {
                    Point v = new Point(r.Next(5, drawPanel.Width - 5), r.Next(5, drawPanel.Height - 5));
                    p.AddPointNoUpdate(v);
                }
                testLists.Add(p);
            }
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
            for (int i = shapes.Count - 1; i >= 0; i--)
                shapes[i].Fill(canvas);
            drawPanel.Image = canvas;
        }

        public void UpdateTempCanvas(Shape shape)
        {
            tempCanvas = new Bitmap(canvas);
            shape.Draw(Graphics.FromImage(tempCanvas));
            drawPanel.Image = tempCanvas;
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
                        shapes.Insert(0, polygon);
                    }
                    ((Polygon)shapes.First()).AddPoint(this, e.Location);
                    selectedShape = shapes.First();
                    listLayers.SelectedIndex = 0;
                    
                    break;
                case DrawingTool.Ellipse:
                    if (bDrawEllipse == false)
                    {
                        bDrawEllipse = true;
                        start = e.Location;
                    }
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

        private void drawPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (bDrawEllipse)
            {
                end = e.Location;
                Ellipse tempEllipse = new Ellipse(start, end);
                UpdateTempCanvas(tempEllipse);
            }
        }

        private void algorithmList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if((Shape.FillMode)algorithmList.SelectedItem == Shape.FillMode.BoundaryFill)
            {
                if (MessageBox.Show("Has chances to throw Stack overflow exception. Continue?", "Warning", MessageBoxButtons.YesNo) == DialogResult.No)
                    return;
                if(MessageBox.Show("Are you sure?", "Warning", MessageBoxButtons.YesNo) == DialogResult.No)
                    return;
            }
            Shape.Mode = (Shape.FillMode)algorithmList.SelectedItem;
            UpdateCanvas();
        }

        private void fillColorButton_Click(object sender, EventArgs e)
        {
            if (bDrawEllipse || bDrawPolygon)
                return;
            ColorDialog colorDialog = new ColorDialog();
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                selectedShape.FillColor = colorDialog.Color;
                fillColorButton.BackColor = colorDialog.Color;
                UpdateCanvas();
            }
        }

        private void strokeColorButton_Click(object sender, EventArgs e)
        {
            if (bDrawEllipse || bDrawPolygon)
                return;
            ColorDialog colorDialog = new ColorDialog();
            if(colorDialog.ShowDialog() == DialogResult.OK)
            {
                selectedShape.StrokeColor = colorDialog.Color;
                strokeColorButton.BackColor = colorDialog.Color;
                UpdateCanvas();
            }
        }

        private void listLayers_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedShape = shapes[listLayers.SelectedIndex];
            strokeColorButton.BackColor = selectedShape.StrokeColor;
            fillColorButton.BackColor = selectedShape.FillColor;
        }

        private void runTestButton_Click(object sender, EventArgs e)
        {
            Task task = new Task(MeasuringProcess);
            task.Start();
            MessageBox.Show("Please wait until result pop out!");
        }

        private void drawPanel_MouseUp(object sender, MouseEventArgs e)
        {
            if (bDrawEllipse)
            {
                bDrawEllipse = false;
                end = e.Location;
                Ellipse ellipse = new Ellipse(start, end);
                shapes.Insert(0, ellipse);
                UpdateCanvas();
                selectedShape = ellipse;
                listLayers.SelectedIndex = 0;
            }
        }
    }
}
