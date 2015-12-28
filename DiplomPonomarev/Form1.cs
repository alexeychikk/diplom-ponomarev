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
        public int minRecHeight = 20;
        public int maxRecHeight = 200;
        public int recsPerAction = 10;
        List<Rectangle> rectangles = new List<Rectangle>();
        Stopwatch stopWatch = new Stopwatch();

        public Form1()
        {
            InitializeComponent();
            canvas = this.graphicsComponent.canvasGraphics;

            for (int i = 0; i < 200; i++)
            {
                double height = rnd.Next(minRecHeight, maxRecHeight);
                AddRectangle(recWidth, height, i * (recWidth + 1) + 20, maxRecHeight - height + 20);
            }   
        }

        public void AddRectangles()
        {
            for (int i = 0; i < recsPerAction; i++)
            {
                Thread.Sleep(50);
                double height = rnd.Next(minRecHeight, maxRecHeight);
                graphicsComponent.Dispatcher.BeginInvoke(new Action(delegate()
                {
                    AddRectangle(recWidth, height, (rectangles.Count - 1) * (recWidth + 1) + 20, maxRecHeight - height + 20);
                }));
            }
        }

        public void RemoveRectangle()
        {
            for (int i = 0; i < recsPerAction; i++)
            {
                Thread.Sleep(50);
                graphicsComponent.Dispatcher.BeginInvoke(new Action(delegate()
                {
                    Rectangle r = rectangles.Last();
                    canvas.Children.Remove(r);
                    rectangles.Remove(r);
                }));
            }
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
            Task.Run((Action)AddRectangles);
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            Task.Run((Action)RemoveRectangle);
        }
    }
}
