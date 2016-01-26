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
using System.Windows.Media.Animation;
using System.Windows;
using System.Diagnostics;
using System.Threading;

namespace DiplomPonomarev
{
    public partial class Form1 : Form
    {
        Canvas canvas;
        Random rnd = new Random();
        public double recWidth = 20;
        public double minRecWidth = 2;
        public double maxRecWidth = 20;
        public double scaling = 0.2;
        public int minRecHeight = 20;
        public int maxRecHeight = 300;
        public double offsetTop = 20;
        public double offsetSides = 20;
        public double offsetBetween = 1;
        public double recRadius = 2;
        public double animSpeed = 1;
        public double animSpeedMin = 0.1;
        public double animSpeedMax = 10;
        public double animMSDefualt = 200;
        public double animMSSwap = 300;
        public int startRecsCount;
        public int recsPerAction;
        public int addRecsCount;
        public int removeRecsCount;
        public int recDelay = 1;
        public bool sorting = false;
        public int recsTransforming = 0;
        public int recsSwaping = 0;
        public bool transformingDown;
        public bool fullSwapEnd = true;
        public bool animateCircles = true, animateCirclesStart = false;
        public Rectangle reci, recj;
        public double reciHeight, reciTop, recjHeight, recjTop;
        List<Rectangle> recs = new List<Rectangle>();

        DoubleAnimation animAppearOpacity;
        ColorAnimation animRefreshColor;
        DoubleAnimation animTransformHeight;
        DoubleAnimation animTransformRadiusX;
        DoubleAnimation animTransformRadiusY;
        DoubleAnimation animTransformTop;
        DoubleAnimation animSwapLeft;

        public Form1()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            
            cmbStruct.SelectedIndex = 0;
            cmbSortType.SelectedIndex = 1;

            canvas = this.graphicsComponent.canvasGraphics;
            canvas.Focusable = true;
            canvas.MouseWheel += canvas_MouseWheel;
            canvas.MouseEnter += canvas_MouseEnter;

            graphicsComponent.storybAppear = new Storyboard();
            graphicsComponent.storybRefresh = new Storyboard();
            graphicsComponent.storybTransform = new Storyboard();
            graphicsComponent.storybSwap = new Storyboard();

            graphicsComponent.storybTransform.Completed += storybTransform_Completed;
            graphicsComponent.storybSwap.Completed += storybSwap_Completed;

            animAppearOpacity = new DoubleAnimation();
            animAppearOpacity.From = 0.0;
            animAppearOpacity.To = 1.0;
            animAppearOpacity.Duration = new Duration(TimeSpan.FromMilliseconds(800));
            Storyboard.SetTargetProperty(animAppearOpacity, new PropertyPath(Rectangle.OpacityProperty));

            animRefreshColor = new ColorAnimation();
            animRefreshColor.From = Colors.Yellow;
            animRefreshColor.To = Colors.Black;
            animRefreshColor.Duration = new Duration(TimeSpan.FromMilliseconds(100));
            Storyboard.SetTargetProperty(animRefreshColor, new PropertyPath("Fill.Color"));

            animTransformHeight = new DoubleAnimation();
            animTransformHeight.Duration = new Duration(TimeSpan.FromMilliseconds(animMSDefualt));
            Storyboard.SetTargetProperty(animTransformHeight, new PropertyPath(Rectangle.HeightProperty));

            animTransformRadiusX = new DoubleAnimation();
            animTransformRadiusX.Duration = new Duration(TimeSpan.FromMilliseconds(animMSDefualt));
            Storyboard.SetTargetProperty(animTransformRadiusX, new PropertyPath(Rectangle.RadiusXProperty));

            animTransformRadiusY = new DoubleAnimation();
            animTransformRadiusY.Duration = new Duration(TimeSpan.FromMilliseconds(animMSDefualt));
            Storyboard.SetTargetProperty(animTransformRadiusY, new PropertyPath(Rectangle.RadiusYProperty));

            animTransformTop = new DoubleAnimation();
            Storyboard.SetTargetProperty(animTransformTop, new PropertyPath(Canvas.TopProperty));
            animTransformTop.Duration = new Duration(TimeSpan.FromMilliseconds(animMSDefualt));

            animSwapLeft = new DoubleAnimation();
            Storyboard.SetTargetProperty(animSwapLeft, new PropertyPath(Canvas.LeftProperty));
            animSwapLeft.Duration = new Duration(TimeSpan.FromMilliseconds(animMSSwap));

            graphicsComponent.storybAppear.Children.Add(animAppearOpacity);
            graphicsComponent.storybRefresh.Children.Add(animRefreshColor);
            graphicsComponent.storybTransform.Children.Add(animTransformHeight);
            graphicsComponent.storybTransform.Children.Add(animTransformRadiusX);
            graphicsComponent.storybTransform.Children.Add(animTransformRadiusY);
            graphicsComponent.storybTransform.Children.Add(animTransformTop);
            graphicsComponent.storybSwap.Children.Add(animSwapLeft);

            CalculateRecsCount();
            addRecsCount = startRecsCount;
            AddRecsAsync().ContinueWith(task =>
            {
                addRecsCount = removeRecsCount = recsPerAction = recs.Count / 8;
            });
        }

        void canvas_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            canvas.Focus();
        }

        void canvas_MouseWheel(object sender, System.Windows.Input.MouseWheelEventArgs e)
        {
            if (sorting) return;
            double newWidth = 0;
            bool add = (recs.Count + 1) * (recWidth + offsetBetween) + offsetSides * 2 >= elementHost1.Width;

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
            if (startRecsCount < recs.Count)
            {
                removeRecsCount = recs.Count - startRecsCount;
                RemoveRecs();
            }
            else if (startRecsCount > recs.Count && add)
            {
                addRecsCount = startRecsCount - recs.Count;
                AddRecs();
            }
            for (int i = 0; i < recs.Count; i++)
            {
                Canvas.SetLeft(recs[i], i * (recWidth + offsetBetween) + offsetSides);
                recs[i].Width = recWidth;
            }
            recsPerAction = startRecsCount / 8;
        }

        public void CalculateRecsCount()
        {
            startRecsCount = (int)((this.elementHost1.Width - offsetSides * 2) / (recWidth + offsetBetween));
        }

        public void AddRec(double width, double height, double x, double y)
        {
            Rectangle r = new Rectangle();
            r.Width = width; r.Height = height; r.Fill = Brushes.Black;
            r.RadiusX = recRadius; r.RadiusY = recRadius; r.Opacity = 0.0;
            Canvas.SetLeft(r, x);
            Canvas.SetTop(r, y);
            canvas.Children.Add(r);
            recs.Add(r);
            Storyboard.SetTarget(animAppearOpacity, r);
            graphicsComponent.storybAppear.Begin(graphicsComponent);
        }

        public bool EnoughSpace()
        {
            return (recs.Count + 1) * (recWidth + offsetBetween) - offsetBetween + offsetSides * 2 <= elementHost1.Width;
        }

        public void AddRecs()
        {
            for (int i = 0; i < addRecsCount; i++)
            {
                if (!EnoughSpace()) return;
                double height = rnd.Next(minRecHeight, maxRecHeight);
                AddRec(recWidth, height, recs.Count * (recWidth + offsetBetween) + offsetSides, maxRecHeight - height + offsetTop);
            }
            addRecsCount = recsPerAction;
        }

        public Task AddRecsAsync()
        {
            int addedCount = 0;
            return Task.Run(() =>
            {
                Stopwatch sw = new Stopwatch();
                sw.Start();
                for (int i = 0; i < addRecsCount; i++)
                {
                    SafeInvoke(() =>
                    {
                        try
                        {
                            if (!EnoughSpace()) return;
                            double height = rnd.Next(minRecHeight, maxRecHeight);
                            AddRec(recWidth, height, recs.Count * (recWidth + offsetBetween) + offsetSides, maxRecHeight - height + offsetTop);
                            addedCount++;
                        }
                        catch (Exception e) { }
                    });
                    while (sw.ElapsedTicks < i * 1000000 / addRecsCount || addedCount <= i) { }
                }
                addRecsCount = recsPerAction;
                sw.Reset();
            });
        }

        public void RemoveRec()
        {
            if (recs.Count == 0) return;
            Rectangle r = recs.Last();
            canvas.Children.Remove(r);
            recs.Remove(r);
        }

        public void RemoveRecs()
        {
            for (int i = 0; i < removeRecsCount; i++)
            {
                RemoveRec();
            }
            removeRecsCount = recsPerAction;
        }

        public Task RemoveRecAsync()
        {
            int removedCount = 0;
            return Task.Run(() =>
            {
                Stopwatch sw = new Stopwatch();
                sw.Start();
                for (int i = 0; i < removeRecsCount; i++)
                {
                    SafeInvoke(() =>
                    {
                        try
                        {
                            RemoveRec();
                            removedCount++;
                        }
                        catch { }
                    });
                    while (sw.ElapsedTicks < i * 1000000 / removeRecsCount || removedCount <= i) { }
                }
                removeRecsCount = recsPerAction;
                sw.Reset();
            });
        }

        public void UnlockRecs()
        {
            for (int i = 0; i < recs.Count; i++)
            {
                double height = recs[i].Height, width = recs[i].Width, x = Canvas.GetLeft(recs[i]);

                Rectangle r = new Rectangle();
                r.Width = width; r.Height = height; r.Fill = Brushes.Black;
                r.RadiusX = recRadius; r.RadiusY = recRadius;
                Canvas.SetLeft(r, x);
                Canvas.SetTop(r, maxRecHeight - r.Height + offsetTop);
                canvas.Children.Remove(recs[i]);
                canvas.Children.Add(r);

                recs[i] = r;
            }
        }

        public Task RefreshRecsAsync()
        {
            int refreshedCount = 0;
            return Task.Run(() =>
            {
                if (recs.Count < 1) return;
                Stopwatch sw = new Stopwatch();
                sw.Start();
                for (int i = 0; i < recs.Count; i++)
                {
                    SafeInvoke(() =>
                    {
                        try
                        {
                            int height = rnd.Next(minRecHeight, maxRecHeight);
                            double width = recs[i].Width, x = Canvas.GetLeft(recs[i]);

                            Rectangle r = new Rectangle();
                            r.Width = width; r.Height = height; r.Fill = Brushes.Black;
                            r.RadiusX = recRadius; r.RadiusY = recRadius;
                            Canvas.SetLeft(r, x);
                            Canvas.SetTop(r, maxRecHeight - r.Height + offsetTop);
                            canvas.Children.Remove(recs[i]);
                            canvas.Children.Add(r);

                            recs[i] = r;
                            Storyboard.SetTarget(animRefreshColor, recs[i]);
                            graphicsComponent.storybRefresh.Begin(graphicsComponent);
                            refreshedCount++;
                        }
                        catch (Exception e) { }
                    });
                    while (sw.ElapsedTicks < i * 2000000 / recs.Count || refreshedCount <= i) { }
                }
                sw.Reset();
            });
        }

        public void SafeInvoke(Action a)
        {
            graphicsComponent.Dispatcher.Invoke(a, System.Windows.Threading.DispatcherPriority.Background);
        }

        public Task VisualSortBubble()
        {
            return Task.Run(() =>
            {
                if (recs.Count < 1) return;
                sorting = true;
                long delay = 300000000 / (recs.Count * (recs.Count - 1));
                Stopwatch sw = new Stopwatch();
                sw.Start();
                Rectangle recjPrev = null, reciPrev = null;
                for (int i = 0; i < recs.Count - 1; i++)
                {
                    for (int j = i + 1; j < recs.Count; j++)
                    {
                        SafeInvoke(() =>
                        {
                            try
                            {
                                if (reciPrev != null) reciPrev.Fill = Brushes.Black;
                                recs[i].Fill = Brushes.Blue;
                                if (recjPrev != null) recjPrev.Fill = Brushes.Black;
                                recs[j].Fill = Brushes.Red;
                                if (recs[j].Height < recs[i].Height)
                                {
                                    Rectangle r = recs[i];
                                    recs[i] = recs[j];
                                    recs[j] = r;
                                    reci = recs[i];
                                    recj = recs[j];
                                    reciHeight = reci.Height;
                                    reciTop = Canvas.GetTop(reci);
                                    recjHeight = recj.Height;
                                    recjTop = Canvas.GetTop(recj);

                                    Canvas.SetZIndex(recs[i], 9999);
                                    Canvas.SetZIndex(recs[j], 9998);
                                    if (!animateCircles)
                                    {
                                        animateCirclesStart = false;
                                        SwapRecs(recs[i], recs[j]);
                                    }
                                    else
                                    {
                                        animateCirclesStart = true;
                                        transformingDown = true;
                                        TransformRecDown(recs[i]);
                                        TransformRecDown(recs[j]);
                                    }
                                    fullSwapEnd = false;
                                }
                                reciPrev = recs[i];
                                recjPrev = recs[j];
                            }
                            catch { }
                        });
                        if (fullSwapEnd) sw.Restart();
                        while (sw.ElapsedTicks < delay * animSpeed || !fullSwapEnd) { }
                        SafeInvoke(() =>
                        {
                            Canvas.SetZIndex(recs[i], 0);
                            Canvas.SetZIndex(recs[j], 1);
                            sw.Restart();
                        });
                    }
                }
                sw.Reset();

                sw.Start();
                for (int i = 2; i > -1; i--)
                {
                    SafeInvoke(() =>
                    {
                        try
                        {
                            recs[recs.Count - i - 1].Fill = Brushes.Black;
                        }
                        catch { }
                    });
                    while (sw.ElapsedTicks < (2 - i) * 2000000 / recs.Count) { }
                }
                sw.Reset();
                SafeInvoke(() =>
                {
                    UnlockRecs();
                    sorting = false;
                });
            });
        }

        void storybSwap_Completed(object sender, EventArgs e)
        {
            recsSwaping--;
            if (recsSwaping == 0)
            {
                if (animateCircles || animateCirclesStart)
                {
                    transformingDown = false;
                    TransformRecUp(reci, reciHeight, reciTop);
                    TransformRecUp(recj, recjHeight, recjTop);
                }
                else fullSwapEnd = true;
            }
        }

        void storybTransform_Completed(object sender, EventArgs e)
        {
            recsTransforming--;
            if (recsTransforming == 0)
            {
                if (transformingDown) SwapRecs(reci, recj);
                else fullSwapEnd = true;
            }
        }

        public void SwapRecs(Rectangle r1, Rectangle r2)
        {
            recsSwaping += 2;
            double r1Left = Canvas.GetLeft(r1), r2Left = Canvas.GetLeft(r2);
            animSwapLeft.To = r2Left;
            Storyboard.SetTarget(animSwapLeft, r1);
            graphicsComponent.storybSwap.Begin(graphicsComponent);
            animSwapLeft.To = r1Left;
            Storyboard.SetTarget(animSwapLeft, r2);
            graphicsComponent.storybSwap.Begin(graphicsComponent);
        }

        public void TransformRecDown(Rectangle r)
        {
            recsTransforming++;
            animTransformHeight.To = r.Width;
            animTransformRadiusX.To = r.Width / 2;
            animTransformRadiusY.To = r.Width / 2;
            animTransformTop.To = Canvas.GetTop(r) + r.Height + 5;
            Storyboard.SetTarget(animTransformHeight, r);
            Storyboard.SetTarget(animTransformRadiusX, r);
            Storyboard.SetTarget(animTransformRadiusY, r);
            Storyboard.SetTarget(animTransformTop, r);
            graphicsComponent.storybTransform.Begin(graphicsComponent);
        }

        public void TransformRecUp(Rectangle r, double height, double top)
        {
            recsTransforming++;
            animTransformHeight.To = height;
            animTransformRadiusX.To = recRadius;
            animTransformRadiusY.To = recRadius;
            animTransformTop.To = top;
            Storyboard.SetTarget(animTransformHeight, r);
            Storyboard.SetTarget(animTransformRadiusX, r);
            Storyboard.SetTarget(animTransformRadiusY, r);
            Storyboard.SetTarget(animTransformTop, r);
            graphicsComponent.storybTransform.Begin(graphicsComponent);
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            AddRecsAsync();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            RemoveRecAsync();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            RefreshRecsAsync();
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            VisualSortBubble();
        }

        private void toolStripButton2_Click_1(object sender, EventArgs e)
        {
            if (1 / animSpeed == animSpeedMin) return;
            animSpeed += 0.1;
            if (1 / animSpeed < animSpeedMin) animSpeed = 1 / animSpeedMin;
            SetAnimSpeed();
        }

        private void toolStripButton3_Click_1(object sender, EventArgs e)
        {
            if (1 / animSpeed == animSpeedMax) return;
            animSpeed -= 0.1;
            if (1 / animSpeed > animSpeedMax) animSpeed = 1 / animSpeedMax;
            SetAnimSpeed();
        }

        public void SetAnimSpeed()
        {
            animTransformHeight.Duration = new Duration(TimeSpan.FromMilliseconds(animMSDefualt * animSpeed));
            animTransformRadiusX.Duration = new Duration(TimeSpan.FromMilliseconds(animMSDefualt * animSpeed));
            animTransformRadiusY.Duration = new Duration(TimeSpan.FromMilliseconds(animMSDefualt * animSpeed));
            animTransformTop.Duration = new Duration(TimeSpan.FromMilliseconds(animMSDefualt * animSpeed));
            animSwapLeft.Duration = new Duration(TimeSpan.FromMilliseconds(animMSSwap * animSpeed));
            double animSpeedInverse = Math.Round(1 / animSpeed, 2);
            lblSpeed.Text = animSpeedInverse + "x";
            animateCircles = !(animSpeedInverse > 2);
        }
    }
}
