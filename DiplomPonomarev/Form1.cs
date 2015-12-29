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
        public int maxRecHeight = 300;
        public double offsetTop = 20;
        public double offsetSides = 20;
        public double offsetBetween = 1;
        public int startRecsCount;
        public int recsPerAction;
        public int addRecsCount = 20;
        public int removeRecsCount = 20;
        public int recDelay = 1;
        public bool sorting = false;
        List<Rectangle> rectangles = new List<Rectangle>();

        Brush b1, b2, b3, b4;

        public Form1()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;

            canvas = this.graphicsComponent.canvasGraphics;
            canvas.Focusable = true;
            canvas.MouseWheel += canvas_MouseWheel;
            canvas.MouseEnter += canvas_MouseEnter;

            b1 = (SolidColorBrush)(new BrushConverter().ConvertFrom("#e9d700"));
            b2 = (SolidColorBrush)(new BrushConverter().ConvertFrom("#a39600"));
            b3 = (SolidColorBrush)(new BrushConverter().ConvertFrom("#5d5600"));
            b4 = (SolidColorBrush)(new BrushConverter().ConvertFrom("#171500"));


            CalculateRecsCount();
            for (int i = 0; i < startRecsCount; i++)
            {
                double height = rnd.Next(minRecHeight, maxRecHeight);
                AddRectangle(recWidth, height, i * (recWidth + offsetBetween) + offsetSides, maxRecHeight - height + offsetTop);
            }
            addRecsCount = removeRecsCount = recsPerAction = rectangles.Count / 8;
        }

        void canvas_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            canvas.Focus();
        }

        void canvas_MouseWheel(object sender, System.Windows.Input.MouseWheelEventArgs e)
        {
            if (sorting) return;
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
            recsPerAction = startRecsCount / 8;
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
            Stopwatch sw = new Stopwatch();
            sw.Start();
            for (int i = 0; i < addRecsCount; i++)
            {
                SafeInvoke(() => {
                    try
                    {
                        if (rectangles.Count * (recWidth + offsetBetween) + offsetSides * 2 >= elementHost1.Width) return;
                        double height = rnd.Next(minRecHeight, maxRecHeight);
                        AddRectangle(recWidth, height,
                            (Math.Abs(rectangles.Count - 1)) * (recWidth + offsetBetween) + offsetSides, maxRecHeight - height + offsetTop);
                    }
                    catch { }
                });
                while (sw.ElapsedTicks < i * 1000000 / recsPerAction) { }
            }
            addRecsCount = recsPerAction;
            sw.Reset();
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
            Stopwatch sw = new Stopwatch();
            sw.Start();
            for (int i = 0; i < removeRecsCount; i++)
            {
                if (rectangles.Count == 0) return;
                SafeInvoke(() => {
                    try
                    {
                        Rectangle r = rectangles.Last();
                        canvas.Children.Remove(r);
                        rectangles.Remove(r);
                    }
                    catch { }
                });
                while (sw.ElapsedTicks < i * 1000000 / recsPerAction) { }
            }
            removeRecsCount = recsPerAction;
            sw.Reset();
        }

        public void AddRectangle(double width, double height, double x, double y)
        {
            Rectangle r = new Rectangle();
            r.Width = width; r.Height = height; r.Fill = Brushes.Black;
            r.RadiusX = 2; r.RadiusY = 2;
            Canvas.SetLeft(r, x);
            Canvas.SetTop(r, y);
            canvas.Children.Add(r);
            rectangles.Add(r);
        }

        public void RefreshRectanglesAsync()
        {
            if (rectangles.Count < 1) return;
            Stopwatch sw = new Stopwatch();
            sw.Start();
            for (int i = 0; i < rectangles.Count; i++)
            {
                SafeInvoke(() => {
                    try
                    {
                        rectangles[i].Height = rnd.Next(minRecHeight, maxRecHeight);
                        Canvas.SetTop(rectangles[i], maxRecHeight - rectangles[i].Height + offsetTop);
                        if (i - 4 >= 0) rectangles[i - 4].Fill = Brushes.Black;
                        if (i - 3 >= 0) rectangles[i - 3].Fill = b4;
                        if (i - 2 >= 0) rectangles[i - 2].Fill = b3;
                        if (i - 1 >= 0) rectangles[i - 1].Fill = b2;
                        rectangles[i].Fill = b1;
                    }
                    catch { }
                });
                while (sw.ElapsedTicks < i * 2000000 / rectangles.Count) { }
            }
            sw.Reset();

            sw.Start();
            for (int i = 4; i > -1; i--)
            {
                SafeInvoke(() => {
                    try
                    {
                        rectangles[rectangles.Count - i - 1].Fill = Brushes.Black;
                    }
                    catch { }
                });
                while (sw.ElapsedTicks < (4 - i) * 2000000 / rectangles.Count) { }
            }
            sw.Reset();
        }

        public void SafeInvoke(Action a)
        {
            graphicsComponent.Dispatcher.Invoke(a, System.Windows.Threading.DispatcherPriority.Background);
        }

        public void VisualSortBubble()
        {
            if (rectangles.Count < 1) return;
            sorting = true;
            long delay = 30000000 / (rectangles.Count * (rectangles.Count - 1));
            Stopwatch sw = new Stopwatch();
            sw.Start();
            Rectangle prevRecj = null, prevReci = null;
            for (int i = 0; i < rectangles.Count - 1; i++)
            {
                SafeInvoke(() =>
                {
                    if (prevReci != null) prevReci.Fill = Brushes.Black;
                    rectangles[i].Fill = Brushes.Blue;
                });
                for (int j = i + 1; j < rectangles.Count; j++)
                {
                    SafeInvoke(() => {
                        try
                        {
                            if (prevRecj != null) prevRecj.Fill = Brushes.Black;
                            rectangles[j].Fill = Brushes.Red;
                            if (rectangles[j].Height < rectangles[i].Height)
                            {
                                double temp = Canvas.GetLeft(rectangles[i]);
                                Canvas.SetLeft(rectangles[i], Canvas.GetLeft(rectangles[j]));
                                Canvas.SetLeft(rectangles[j], temp);
                                Rectangle r = rectangles[i];
                                rectangles[i] = rectangles[j];
                                rectangles[j] = r;
                                rectangles[i].Fill = Brushes.Blue;
                            }
                            prevRecj = rectangles[j];
                        }
                        catch { }
                    });
                    while (sw.ElapsedTicks < delay) { }
                    sw.Restart();
                }
                prevReci = rectangles[i];
            }
            sw.Reset();

            sw.Start();
            for (int i = 2; i > -1; i--)
            {
                SafeInvoke(() => {
                    try
                    {
                        rectangles[rectangles.Count - i - 1].Fill = Brushes.Black;
                    }
                    catch { }
                });
                while (sw.ElapsedTicks < (2 - i) * 2000000 / rectangles.Count) { }
            }
            sw.Reset();
            sorting = false;
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Task.Run((Action)AddRectanglesAsync);
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            Task.Run((Action)RemoveRectanglesAsync);
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            Task.Run((Action)RefreshRectanglesAsync);
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            Task.Run((Action)VisualSortBubble);
        }
    }
}
