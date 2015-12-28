using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Diagnostics;
using System.Threading;

namespace DiplomPonomarev
{
    public partial class Form1 : Form
    {
        Canvas canvas;
        Random rnd = new Random();
        public double recWidth = 2;
        public double minRecWidth = 2;
        public double maxRecWidth = 20;
        public double scaling = 0.2;
        public int minRecHeight = 20;
        public int maxRecHeight = 200;
        public double offsetTop = 20;
        public double offsetSides = 20;
        public double offsetBetween = 1;
        public int startRecsCount;
        public int recsPerAction = 20;
        public int addRecsCount = 20;
        public int removeRecsCount = 20;
        public int recDelay = 20;
        List<Rectangle> rectangles = new List<Rectangle>();
        Stopwatch stopWatch = new Stopwatch();

        public Form1()
        {
            InitializeComponent();
            canvas = this.graphicsComponent.canvasGraphics;
            canvas.MouseWheel += canvas_MouseWheel;

            CalculateRecsCount();
            for (int i = 0; i < startRecsCount; i++)
            {
                double height = rnd.Next(minRecHeight, maxRecHeight);
                AddRectangle(recWidth, height, i * (recWidth + offsetBetween) + offsetSides, maxRecHeight - height + offsetTop);
            }   
        }

        void canvas_MouseWheel(object sender, System.Windows.Input.MouseWheelEventArgs e)
        {
            double newWidth = 0;
            bool add = (rectangles.Count + 1) * (recWidth + offsetBetween) + offsetSides * 2 >= elementHost1.Width;

            if (e.Delta < 0) newWidth = recWidth - recWidth * scaling;
            else if (e.Delta > 0) newWidth = recWidth + recWidth * scaling;
            if (newWidth < minRecWidth)
            {
                if (recWidth > minRecWidth) recWidth = minRecWidth;
                else return;
            }
            else if (newWidth > maxRecWidth)
            {
                if (recWidth < maxRecWidth) recWidth = maxRecWidth;
                else return;
            }
            else recWidth = newWidth;

            CalculateRecsCount();
            if (startRecsCount < rectangles.Count)
            {
                removeRecsCount = rectangles.Count - startRecsCount;
                RemoveRectangles();
            }
            else if (startRecsCount > rectangles.Count && add)
            {
                addRecsCount = startRecsCount - rectangles.Count;
                AddRectangles();
            }
            for (int i = 0; i < rectangles.Count; i++)
            {
                Canvas.SetLeft(rectangles[i], i * (recWidth + offsetBetween) + offsetSides);
                rectangles[i].Width = recWidth;
            }
        }

        public void CalculateRecsCount()
        {
            startRecsCount = (int)((this.elementHost1.Width - offsetSides * 2) / (recWidth + offsetBetween));
        }

        public void AddRectangles()
        {
            for (int i = 0; i < addRecsCount; i++)
            {
                if (rectangles.Count * (recWidth + offsetBetween) + offsetSides * 2 >= elementHost1.Width) return;
                double height = rnd.Next(minRecHeight, maxRecHeight);
                AddRectangle(recWidth, height,
                    (Math.Abs(rectangles.Count - 1)) * (recWidth + offsetBetween) + offsetSides, maxRecHeight - height + offsetTop);
            }
            addRecsCount = recsPerAction;
        }

        public void AddRectanglesAsync()
        {
            for (int i = 0; i < addRecsCount; i++)
            {
                graphicsComponent.Dispatcher.BeginInvoke(new Action(delegate()
                {
                    if (rectangles.Count * (recWidth + offsetBetween) + offsetSides * 2 >= elementHost1.Width) return;
                    double height = rnd.Next(minRecHeight, maxRecHeight);
                    AddRectangle(recWidth, height,
                        (Math.Abs(rectangles.Count - 1)) * (recWidth + offsetBetween) + offsetSides, maxRecHeight - height + offsetTop);
                }));
                Thread.Sleep(recDelay);
            }
        }

        public void RemoveRectangles()
        {
            for (int i = 0; i < removeRecsCount; i++)
            {
                if (rectangles.Count == 0) return;
                Rectangle r = rectangles.Last();
                canvas.Children.Remove(r);
                rectangles.Remove(r);
            }
            removeRecsCount = recsPerAction;
        }

        public void RemoveRectanglesAsync()
        {
            for (int i = 0; i < removeRecsCount; i++)
            {
                if (rectangles.Count == 0) return;
                graphicsComponent.Dispatcher.BeginInvoke(new Action(delegate()
                {
                    Rectangle r = rectangles.Last();
                    canvas.Children.Remove(r);
                    rectangles.Remove(r);
                }));
                Thread.Sleep(recDelay);
            }
            removeRecsCount = recsPerAction;
        }

        public void AddRectangle(double width, double height, double x, double y)
        {
            Rectangle r = new Rectangle();
            r.Width = width; r.Height = height; r.Fill = Brushes.Black;
            Canvas.SetLeft(r, x);
            Canvas.SetTop(r, y);
            canvas.Children.Add(r);
            rectangles.Add(r);
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Task.Run((Action)AddRectanglesAsync);
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            Task.Run((Action)RemoveRectanglesAsync);
        }
    }
}
