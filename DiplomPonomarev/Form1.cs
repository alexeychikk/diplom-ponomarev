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
using System.Diagnostics;
using System.Threading;
using System.Windows.Documents;
using System.Windows;

namespace DiplomPonomarev
{
    public partial class Form1 : Form
    {
        Canvas canvas;
        Random rnd = new Random();
        public double recWidth = 40;
        public double minRecWidth = 20;
        public double maxRecWidth = 40;
        public double scaling = 0.2;
        public int minRecHeight = 7;
        public int maxRecHeight = 100;
        public double offsetTop = 50;
        public double offsetBottom = 60;
        public double offsetSides = 40;
        public double offsetBetween = 4;
        public double offsetNum = 4;
        public double offsetIndex = 2;
        public double offsetCircle = 15;
        public double offsetLabel = 4;
        public double recRadius = 2;
        public double animSpeed = 1;
        public double animSpeedMin = 0.3;
        public double animSpeedMax = 10;
        public double animMSDefualt = 200;
        public double animMSSwap = 500;
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
        public VisualRec reci, recj;
        public double reciHeight, reciTop, recjHeight, recjTop;
        List<VisualRec> recs = new List<VisualRec>();

        DoubleAnimation animAppearOpacity;
        DoubleAnimation animDisappearOpacity;
        ColorAnimation animRefreshColor;
        DoubleAnimation animRemoveOpacity;
        ColorAnimation animRemoveColor;
        DoubleAnimation animTransformHeight;
        DoubleAnimation animTransformRadiusX;
        DoubleAnimation animTransformRadiusY;
        DoubleAnimation animTransformTop;
        DoubleAnimation animSwapLeft;
        DoubleAnimation animMoveLeft;
        DoubleAnimation animMoveTop;

        public class VisualRec
        {
            public Rectangle rec;
            public TextBlock tbNum;
            public TextBlock tbIndex;
            public int num, index;

            public VisualRec(Rectangle rec, TextBlock tbNum, TextBlock tbIndex, int num, int index) 
            { 
                this.rec = rec;
                this.tbNum = tbNum;
                this.tbIndex = tbIndex;
                this.num = num;
                this.index = index;
            }
        }

        public enum StructType { Stack, Queue, List };
        public enum SortType { Bubble, Insertion, Quick };

        public StructType structType = StructType.Stack;
        public SortType sortType = SortType.Bubble;

        public bool pushTail = false;
        public bool popHead = true;

        public bool stopSort = false;

        public bool randomValue = true;
        public bool autoAmount = true;

        public Border borderHead;
        public Border borderTail;
        public TextBlock tbHead;
        public TextBlock tbTail;

        public bool showTail { get { return structType != StructType.Stack; } }

        public Form1()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;

            canvas = this.graphicsComponent.canvasGraphics;
            canvas.Focusable = true;
            canvas.MouseWheel += canvas_MouseWheel;
            canvas.MouseEnter += canvas_MouseEnter;

            cmbStructType.SelectedIndex = 0;
            cmbSortType.SelectedIndex = 0;
            cmbDestPush.SelectedIndex = 0;
            cmbDestPop.SelectedIndex = 0;

            tbAmount.LostFocus += tbAmount_LostFocus;
            tbValue.LostFocus += tbValue_LostFocus;

            InitAnimations();

            CalculateRecsCount();
            addRecsCount = startRecsCount;
            AddRecsAsync().ContinueWith(task =>
            {
                addRecsCount = removeRecsCount = recsPerAction = recs.Count / 8;
            }).ContinueWith(task =>
            {
                SafeInvoke(() =>
                {
                    CreateHeadTail();
                });
            }).ContinueWith(task =>
            {
                AlignHeadTail();
            });
        }

        void InitAnimations()
        {
            graphicsComponent.storybAppear = new Storyboard();
            graphicsComponent.storybDisappear = new Storyboard();
            graphicsComponent.storybRefresh = new Storyboard();
            graphicsComponent.storybTransform = new Storyboard();
            graphicsComponent.storybSwap = new Storyboard();
            graphicsComponent.storybRemove = new Storyboard();
            graphicsComponent.storybMoveLeft = new Storyboard();
            graphicsComponent.storybMoveTop = new Storyboard();

            graphicsComponent.storybTransform.Completed += storybTransform_Completed;
            graphicsComponent.storybSwap.Completed += storybSwap_Completed;
            graphicsComponent.storybRemove.Completed += storybRemove_Completed;
            graphicsComponent.storybMoveLeft.Completed += storybMoveLeft_Completed;

            animAppearOpacity = new DoubleAnimation();
            animAppearOpacity.From = 0.0;
            animAppearOpacity.To = 1.0;
            animAppearOpacity.Duration = TimeSpan.FromMilliseconds(600);
            Storyboard.SetTargetProperty(animAppearOpacity, new PropertyPath(Rectangle.OpacityProperty));

            animDisappearOpacity = new DoubleAnimation();
            animDisappearOpacity.From = 1.0;
            animDisappearOpacity.To = 0.0;
            animDisappearOpacity.Duration = TimeSpan.FromMilliseconds(600);
            Storyboard.SetTargetProperty(animDisappearOpacity, new PropertyPath(Rectangle.OpacityProperty));

            animRefreshColor = new ColorAnimation();
            animRefreshColor.From = Colors.Yellow;
            animRefreshColor.To = Colors.Black;
            animRefreshColor.Duration = TimeSpan.FromMilliseconds(350);
            Storyboard.SetTargetProperty(animRefreshColor, new PropertyPath("Fill.Color"));

            animRemoveOpacity = new DoubleAnimation();
            animRemoveOpacity.From = 1.0;
            animRemoveOpacity.To = 0.0;
            animRemoveOpacity.Duration = TimeSpan.FromMilliseconds(600);
            animRemoveOpacity.BeginTime = TimeSpan.FromMilliseconds(300);
            Storyboard.SetTargetProperty(animRemoveOpacity, new PropertyPath(Rectangle.OpacityProperty));

            animRemoveColor = new ColorAnimation();
            animRemoveColor.From = Colors.Black;
            animRemoveColor.To = Colors.Red;
            animRemoveColor.Duration = TimeSpan.FromMilliseconds(300);
            Storyboard.SetTargetProperty(animRemoveColor, new PropertyPath("Fill.Color"));

            animTransformHeight = new DoubleAnimation();
            animTransformHeight.Duration = TimeSpan.FromMilliseconds(animMSDefualt);
            Storyboard.SetTargetProperty(animTransformHeight, new PropertyPath(Rectangle.HeightProperty));

            animTransformRadiusX = new DoubleAnimation();
            animTransformRadiusX.Duration = TimeSpan.FromMilliseconds(animMSDefualt);
            Storyboard.SetTargetProperty(animTransformRadiusX, new PropertyPath(Rectangle.RadiusXProperty));

            animTransformRadiusY = new DoubleAnimation();
            animTransformRadiusY.Duration = TimeSpan.FromMilliseconds(animMSDefualt);
            Storyboard.SetTargetProperty(animTransformRadiusY, new PropertyPath(Rectangle.RadiusYProperty));

            animTransformTop = new DoubleAnimation();
            Storyboard.SetTargetProperty(animTransformTop, new PropertyPath(Canvas.TopProperty));
            animTransformTop.Duration = TimeSpan.FromMilliseconds(animMSDefualt);

            animSwapLeft = new DoubleAnimation();
            Storyboard.SetTargetProperty(animSwapLeft, new PropertyPath(Canvas.LeftProperty));
            animSwapLeft.Duration = TimeSpan.FromMilliseconds(animMSSwap);

            animMoveLeft = new DoubleAnimation();
            Storyboard.SetTargetProperty(animMoveLeft, new PropertyPath(Canvas.LeftProperty));
            animMoveLeft.Duration = TimeSpan.FromMilliseconds(400);

            animMoveTop = new DoubleAnimation();
            Storyboard.SetTargetProperty(animMoveTop, new PropertyPath(Canvas.TopProperty));
            animMoveTop.Duration = TimeSpan.FromMilliseconds(400);

            graphicsComponent.storybAppear.Children.Add(animAppearOpacity);
            graphicsComponent.storybDisappear.Children.Add(animDisappearOpacity);
            graphicsComponent.storybRefresh.Children.Add(animRefreshColor);
            graphicsComponent.storybTransform.Children.Add(animTransformHeight);
            graphicsComponent.storybTransform.Children.Add(animTransformRadiusX);
            graphicsComponent.storybTransform.Children.Add(animTransformRadiusY);
            graphicsComponent.storybTransform.Children.Add(animTransformTop);
            graphicsComponent.storybSwap.Children.Add(animSwapLeft);
            graphicsComponent.storybRemove.Children.Add(animRemoveColor);
            graphicsComponent.storybRemove.Children.Add(animRemoveOpacity);
            graphicsComponent.storybMoveLeft.Children.Add(animMoveLeft);
            graphicsComponent.storybMoveTop.Children.Add(animMoveTop);
        }

        void CreateHeadTail()
        {
            borderHead = new Border();
            borderHead.Padding = new Thickness(0, 2, 0, 2);
            borderHead.Background = Brushes.Green;
            borderHead.CornerRadius = new CornerRadius(2);
            borderHead.Opacity = 0;
            borderHead.Width = recWidth;

            tbHead = new TextBlock();
            tbHead.Text = "head";
            tbHead.Foreground = Brushes.White;
            tbHead.VerticalAlignment = System.Windows.VerticalAlignment.Center;
            tbHead.HorizontalAlignment = System.Windows.HorizontalAlignment.Center;

            borderHead.Child = tbHead;
            canvas.Children.Add(borderHead);
            borderHead.Measure(new Size());
            borderHead.Arrange(new Rect());
            Canvas.SetTop(borderHead, Canvas.GetTop(recs.First().rec) - borderHead.ActualHeight - tbHead.ActualHeight - offsetLabel);
            Canvas.SetLeft(borderHead, Canvas.GetLeft(recs.First().rec));
            Canvas.SetZIndex(borderHead, 10001);
            Storyboard.SetTarget(animAppearOpacity, borderHead);
            graphicsComponent.storybAppear.Begin(graphicsComponent);

            borderTail = new Border();
            borderTail.Padding = new Thickness(0, 2, 0, 2);
            borderTail.Background = Brushes.OrangeRed;
            borderTail.CornerRadius = new CornerRadius(2);
            borderTail.Opacity = 0;
            borderTail.Width = recWidth;

            tbTail = new TextBlock();
            tbTail.Text = "tail";
            tbTail.Foreground = Brushes.White;
            tbTail.VerticalAlignment = System.Windows.VerticalAlignment.Center;
            tbTail.HorizontalAlignment = System.Windows.HorizontalAlignment.Center;

            borderTail.Child = tbTail;
            canvas.Children.Add(borderTail);
            borderTail.Measure(new Size());
            borderTail.Arrange(new Rect());
            Canvas.SetTop(borderTail, Canvas.GetTop(recs.Last().rec) - borderTail.ActualHeight - tbTail.ActualHeight - offsetLabel);
            Canvas.SetLeft(borderTail, Canvas.GetLeft(recs.Last().rec));
            Canvas.SetZIndex(borderTail, 10000);
            if (showTail)
            {
                Storyboard.SetTarget(animAppearOpacity, borderTail);
                graphicsComponent.storybAppear.Begin(graphicsComponent);
            }
        }

        void ShowHead()
        {
            SafeInvoke(() =>
            {
                Storyboard.SetTarget(animAppearOpacity, borderHead);
                graphicsComponent.storybAppear.Begin(graphicsComponent);
            });
        }

        void HideHead()
        {
            SafeInvoke(() =>
            {
                Storyboard.SetTarget(animDisappearOpacity, borderHead);
                graphicsComponent.storybDisappear.Begin(graphicsComponent);
            });
        }

        void ShowTail()
        {
            SafeInvoke(() =>
            {
                Storyboard.SetTarget(animAppearOpacity, borderTail);
                graphicsComponent.storybAppear.Begin(graphicsComponent);
            });
        }

        void HideTail()
        {
            SafeInvoke(() =>
            {
                Storyboard.SetTarget(animDisappearOpacity, borderTail);
                graphicsComponent.storybDisappear.Begin(graphicsComponent);
            });
        }

        void AlignHeadTail()
        {
            Task.Run(() =>
            {
                int recsCountPrev = 0;
                double topHead = 0, topHeadPrev = 0, topTail = 0, topTailPrev = 0, recWidthPrev = 0;
                StructType structTypePrev = StructType.Stack;
                while (true)
                {
                    if (recs.Count > 0)
                    {
                        VisualRec r1 = recs.First();
                        VisualRec r2 = recs.Last();
                        SafeInvoke(() =>
                        {
                            if (r1 != null) topHead = Canvas.GetTop(r1.rec);
                            if (r2 != null) topTail = Canvas.GetTop(r2.rec);
                        });
                    }
                    if (recWidthPrev != recWidth)
                    {
                        SafeInvoke(() =>
                        {
                            borderHead.Width = borderTail.Width = recWidth;
                            animMoveLeft.Duration = TimeSpan.FromMilliseconds(100);
                            animMoveLeft.BeginTime = TimeSpan.FromMilliseconds(0);
                            animMoveLeft.To = (recs.Count - 1) * (recWidth + offsetBetween) + offsetSides;
                            Storyboard.SetTarget(animMoveLeft, borderTail);
                            graphicsComponent.storybMoveLeft.Begin(graphicsComponent);
                            animMoveLeft.Duration = TimeSpan.FromMilliseconds(400);
                            animMoveLeft.BeginTime = TimeSpan.FromMilliseconds(0);
                            recWidthPrev = recWidth;
                        });
                    }
                    if (structTypePrev != structType)
                    {
                        if (recs.Count == 1)
                        {
                            SafeInvoke(() =>
                            {
                                animMoveLeft.To = offsetSides;
                                Storyboard.SetTarget(animMoveLeft, borderHead);
                                graphicsComponent.storybMoveLeft.Begin(graphicsComponent);

                                double x = topHead - borderHead.ActualHeight - offsetLabel;
                                if (structType != StructType.Stack) x -= (borderTail.ActualHeight + offsetLabel);
                                animMoveTop.To = x;
                                Storyboard.SetTarget(animMoveTop, borderHead);
                                graphicsComponent.storybMoveTop.Begin(graphicsComponent);

                                animMoveLeft.To = offsetSides;
                                Storyboard.SetTarget(animMoveLeft, borderTail);
                                graphicsComponent.storybMoveLeft.Begin(graphicsComponent);

                                animMoveTop.To = topTail - borderTail.ActualHeight - offsetLabel;
                                Storyboard.SetTarget(animMoveTop, borderTail);
                                graphicsComponent.storybMoveTop.Begin(graphicsComponent);
                            });
                        }
                        if (recs.Count > 0)
                        {
                            if (structType == StructType.Stack) HideTail();
                            else if (structTypePrev == StructType.Stack) ShowTail();
                        }
                        structTypePrev = structType;
                    }
                    if (recsCountPrev != recs.Count)
                    {
                        if (recsCountPrev == 0)
                        {
                            ShowHead();
                            if (structType != StructType.Stack) ShowTail();
                        }
                        if (recs.Count == 0)
                        {
                            HideHead();
                            if (structType != StructType.Stack) HideTail();
                        }
                        if (recs.Count == 1)
                        {
                            SafeInvoke(() =>
                            {
                                animMoveLeft.To = offsetSides;
                                Storyboard.SetTarget(animMoveLeft, borderHead);
                                graphicsComponent.storybMoveLeft.Begin(graphicsComponent);

                                double x = topHead - borderHead.ActualHeight - offsetLabel;
                                if (structType != StructType.Stack) x -= (borderTail.ActualHeight + offsetLabel);
                                animMoveTop.To = x;
                                Storyboard.SetTarget(animMoveTop, borderHead);
                                graphicsComponent.storybMoveTop.Begin(graphicsComponent);

                                animMoveLeft.To = offsetSides;
                                Storyboard.SetTarget(animMoveLeft, borderTail);
                                graphicsComponent.storybMoveLeft.Begin(graphicsComponent);

                                animMoveTop.To = topTail - borderTail.ActualHeight - offsetLabel;
                                Storyboard.SetTarget(animMoveTop, borderTail);
                                graphicsComponent.storybMoveTop.Begin(graphicsComponent);
                            });
                        }
                        else
                        {
                            SafeInvoke(() =>
                            {
                                animMoveTop.To = topHead - borderHead.ActualHeight - offsetLabel;
                                Storyboard.SetTarget(animMoveTop, borderHead);
                                graphicsComponent.storybMoveTop.Begin(graphicsComponent);

                                if (recs.Count < recsCountPrev && CanPopHead())
                                {
                                    animMoveLeft.Duration = TimeSpan.FromMilliseconds(800);
                                    animMoveLeft.BeginTime = TimeSpan.FromMilliseconds(400);
                                    animMoveLeft.To = (recs.Count - 1) * (recWidth + offsetBetween) + offsetSides;
                                    Storyboard.SetTarget(animMoveLeft, borderTail);
                                    graphicsComponent.storybMoveLeft.Begin(graphicsComponent);
                                    animMoveLeft.Duration = TimeSpan.FromMilliseconds(400);
                                    animMoveLeft.BeginTime = TimeSpan.FromMilliseconds(0);
                                }
                                else
                                {
                                    animMoveLeft.To = (recs.Count - 1) * (recWidth + offsetBetween) + offsetSides;
                                    Storyboard.SetTarget(animMoveLeft, borderTail);
                                    graphicsComponent.storybMoveLeft.Begin(graphicsComponent);
                                }
                                animMoveTop.To = topTail - borderTail.ActualHeight - offsetLabel;
                                Storyboard.SetTarget(animMoveTop, borderTail);
                                graphicsComponent.storybMoveTop.Begin(graphicsComponent);
                            });
                        }
                        recsCountPrev = recs.Count;
                    }
                    else
                    {
                        if ((fullSwapEnd || !animateCircles) && topHead != topHeadPrev)
                        {
                            SafeInvoke(() =>
                            {
                                double x = topHead - borderHead.ActualHeight - offsetLabel;
                                if (recs.Count == 1 && structType != StructType.Stack) x -= (borderTail.ActualHeight + offsetLabel);
                                animMoveTop.To = x;
                                Storyboard.SetTarget(animMoveTop, borderHead);
                                graphicsComponent.storybMoveTop.Begin(graphicsComponent);
                            });
                        }
                        if ((fullSwapEnd || !animateCircles) && topTail != topTailPrev)
                        {
                            SafeInvoke(() =>
                            {
                                animMoveTop.To = topTail - borderTail.ActualHeight - offsetLabel;
                                Storyboard.SetTarget(animMoveTop, borderTail);
                                graphicsComponent.storybMoveTop.Begin(graphicsComponent);
                            });
                        }
                    }
                    topHeadPrev = topHead;
                    topTailPrev = topTail;
                    Thread.Sleep(10);
                }
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
                UnlockRec(recs[i]);
                double x = i * (recWidth + offsetBetween) + offsetSides;
                Canvas.SetLeft(recs[i].rec, x);
                Canvas.SetLeft(recs[i].tbNum, x + recWidth / 2 - recs[i].tbNum.ActualWidth / 2);
                Canvas.SetLeft(recs[i].tbIndex, x + recWidth / 2 - recs[i].tbIndex.ActualWidth / 2);
                recs[i].rec.Width = recWidth;
            }
            recsPerAction = startRecsCount / 8;
        }

        public void CalculateRecsCount()
        {
            startRecsCount = (int)((elementHost1.Width - offsetSides * 2) / (recWidth + offsetBetween));
        }

        public void AddRec(bool anim = true)
        {
            int num = 0;
            if (randomValue) num = rnd.Next(minRecHeight, maxRecHeight);
            else num = int.Parse(tbValue.Text);
            double height = num * (elementHost1.Height - (offsetBottom + offsetTop)) / 100.0;
            int index = 0; double x = offsetSides, y = elementHost1.Height - height - offsetBottom;
            if (CanPushTail())
            {
                index = recs.Count;
                x = recs.Count * (recWidth + offsetBetween) + offsetSides;
            }

            Rectangle r = new Rectangle();
            r.Width = recWidth; r.Height = height; r.Fill = Brushes.Black;
            r.RadiusX = recRadius; r.RadiusY = recRadius;

            TextBlock tbNum = new TextBlock();
            tbNum.Foreground = Brushes.White;
            tbNum.Width = Double.NaN;
            tbNum.Height = Double.NaN;
            tbNum.Text = num.ToString();

            TextBlock tbIndex = new TextBlock();
            tbIndex.Foreground = Brushes.Gray;
            tbIndex.Width = Double.NaN;
            tbIndex.Height = Double.NaN;
            tbIndex.Text = index.ToString();

            if (anim)
            {
                r.Opacity = 0.0;
                tbNum.Opacity = 0.0;
                tbIndex.Opacity = 0.0;
            }

            canvas.Children.Add(r);
            Canvas.SetLeft(r, x);
            Canvas.SetTop(r, y);

            canvas.Children.Add(tbNum);
            tbNum.Measure(new Size());
            tbNum.Arrange(new Rect());
            Canvas.SetLeft(tbNum, x + recWidth / 2 - tbNum.ActualWidth / 2);
            Canvas.SetTop(tbNum, y + height - tbNum.ActualHeight - offsetNum);

            canvas.Children.Add(tbIndex);
            tbIndex.Measure(new Size());
            tbIndex.Arrange(new Rect());
            Canvas.SetLeft(tbIndex, x + recWidth / 2 - tbIndex.ActualWidth / 2);
            Canvas.SetTop(tbIndex, y + height + offsetIndex);

            if (anim)
            {
                if (!CanPushTail())
                {
                    animAppearOpacity.Duration = TimeSpan.FromMilliseconds(1000);
                    animAppearOpacity.BeginTime = TimeSpan.FromMilliseconds(400);
                    for (int i = 0; i < recs.Count; i++)
                    {
                        recs[i].index = i + 1;
                        recs[i].tbIndex.Text = recs[i].index.ToString();
                        recs[i].tbIndex.Measure(new Size());
                        recs[i].tbIndex.Arrange(new Rect());
                        double xn = (i + 1.0) * (recWidth + offsetBetween) + offsetSides;
                        animMoveLeft.To = xn;
                        Storyboard.SetTarget(animMoveLeft, recs[i].rec);
                        graphicsComponent.storybMoveLeft.Begin(graphicsComponent);
                        animMoveLeft.To = xn + recWidth / 2.0 - recs[i].tbNum.ActualWidth / 2.0;
                        Storyboard.SetTarget(animMoveLeft, recs[i].tbNum);
                        graphicsComponent.storybMoveLeft.Begin(graphicsComponent);
                        animMoveLeft.To = xn + recWidth / 2.0 - recs[i].tbIndex.ActualWidth / 2.0;
                        Storyboard.SetTarget(animMoveLeft, recs[i].tbIndex);
                        graphicsComponent.storybMoveLeft.Begin(graphicsComponent);
                    }
                }
                else
                {
                    animAppearOpacity.Duration = TimeSpan.FromMilliseconds(600);
                    animAppearOpacity.BeginTime = TimeSpan.FromMilliseconds(0);
                }
                Storyboard.SetTarget(animAppearOpacity, r);
                graphicsComponent.storybAppear.Begin(graphicsComponent);
                Storyboard.SetTarget(animAppearOpacity, tbNum);
                graphicsComponent.storybAppear.Begin(graphicsComponent);
                Storyboard.SetTarget(animAppearOpacity, tbIndex);
                graphicsComponent.storybAppear.Begin(graphicsComponent);
            }
            else if (!CanPushTail())
            {
                for (int i = 0; i < recs.Count; i++)
                {
                    recs[i].index = i + 1;
                    recs[i].tbIndex.Text = recs[i].index.ToString();
                    recs[i].tbIndex.Measure(new Size());
                    recs[i].tbIndex.Arrange(new Rect());
                    double xn = (i + 1.0) * (recWidth + offsetBetween) + offsetSides;
                    Canvas.SetLeft(recs[i].rec, xn);
                    Canvas.SetLeft(recs[i].tbNum, xn + recWidth / 2 - recs[i].tbNum.ActualWidth / 2);
                    Canvas.SetLeft(recs[i].tbIndex, xn + recWidth / 2 - recs[i].tbIndex.ActualWidth / 2);
                }
            }
            if (CanPushTail())
                recs.Add(new VisualRec(r, tbNum, tbIndex, num, index));
            else recs.Insert(0, new VisualRec(r, tbNum, tbIndex, num, index));
        }

        public bool CanPushTail()
        {
            return structType == StructType.Queue || (structType == StructType.List && pushTail);
        }

        public bool CanPopHead()
        {
            return structType == StructType.Stack || structType == StructType.Queue || (structType == StructType.List && popHead);
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
                AddRec(false);
            }
            addRecsCount = recsPerAction;
        }

        public Task AddRecsAsync()
        {
            return Task.Run(() =>
            {
                if (!EnoughSpace()) return;
                bool enoughSpace = true;
                int addAmount = autoAmount ? addRecsCount : int.Parse(tbAmount.Text);
                Stopwatch sw = new Stopwatch();
                sw.Start();
                for (int i = 0; i < addAmount; i++)
                {
                    SafeInvoke(() =>
                    {
                        try
                        {
                            if (!EnoughSpace()) { enoughSpace = false; return; }
                            AddRec();
                        }
                        catch (Exception e) { }
                    });
                    Thread.Sleep(500 / addAmount);
                    if (!enoughSpace) break;
                }
                addRecsCount = recsPerAction;
                sw.Reset();
            });
        }

        int removeCounter = 0;
        void storybRemove_Completed(object sender, EventArgs e)
        {
            removeCounter++;
            if (removeCounter == 3)
            {
                if (CanPopHead())
                {
                    for (int i = 0; i < recs.Count; i++)
                    {
                        recs[i].index = i;
                        recs[i].tbIndex.Text = recs[i].index.ToString();
                        recs[i].tbIndex.Measure(new Size());
                        recs[i].tbIndex.Arrange(new Rect());
                        double xn = i * (recWidth + offsetBetween) + offsetSides;
                        animMoveLeft.To = xn;
                        Storyboard.SetTarget(animMoveLeft, recs[i].rec);
                        graphicsComponent.storybMoveLeft.Begin(graphicsComponent);
                        animMoveLeft.To = xn + recWidth / 2.0 - recs[i].tbNum.ActualWidth / 2.0;
                        Storyboard.SetTarget(animMoveLeft, recs[i].tbNum);
                        graphicsComponent.storybMoveLeft.Begin(graphicsComponent);
                        animMoveLeft.To = xn + recWidth / 2.0 - recs[i].tbIndex.ActualWidth / 2.0;
                        Storyboard.SetTarget(animMoveLeft, recs[i].tbIndex);
                        graphicsComponent.storybMoveLeft.Begin(graphicsComponent);
                    }
                }
                removeCounter = 0;
                VisualRec r = removeQueue.Dequeue();
                canvas.Children.Remove(r.rec);
                canvas.Children.Remove(r.tbNum);
                canvas.Children.Remove(r.tbIndex);
            }
        }
        Queue<VisualRec> removeQueue = new Queue<VisualRec>();
        public void RemoveRec(bool anim = true)
        {
            if (recs.Count == 0) return;
            VisualRec r = null;
            if (CanPopHead()) r = recs.First();
            else r = recs.Last();
            recs.Remove(r);
            if (anim)
            {
                removeQueue.Enqueue(r);
                animRemoveOpacity.Duration = TimeSpan.FromMilliseconds(600);
                animRemoveOpacity.BeginTime = TimeSpan.FromMilliseconds(300);
                animRemoveColor.Duration = TimeSpan.FromMilliseconds(300);
                Storyboard.SetTarget(animRemoveColor, r.rec);
                Storyboard.SetTarget(animRemoveOpacity, r.rec);
                graphicsComponent.storybRemove.Begin(graphicsComponent);
                Storyboard.SetTarget(animRemoveOpacity, r.tbIndex);
                graphicsComponent.storybRemove.Begin(graphicsComponent);
                Storyboard.SetTarget(animRemoveOpacity, r.tbNum);
                graphicsComponent.storybRemove.Begin(graphicsComponent);
            }
            else
            {
                animRemoveOpacity.Duration = TimeSpan.FromMilliseconds(0);
                animRemoveOpacity.BeginTime = TimeSpan.FromMilliseconds(0);
                animRemoveColor.Duration = TimeSpan.FromMilliseconds(0);
                if (CanPopHead())
                {
                    for (int i = 0; i < recs.Count; i++)
                    {
                        recs[i].index = i;
                        recs[i].tbIndex.Text = recs[i].index.ToString();
                        recs[i].tbIndex.Measure(new Size());
                        recs[i].tbIndex.Arrange(new Rect());
                        double xn = i * (recWidth + offsetBetween) + offsetSides;
                        Canvas.SetLeft(recs[i].rec, xn);
                        Canvas.SetLeft(recs[i].tbNum, xn + recWidth / 2 - recs[i].tbNum.ActualWidth / 2);
                        Canvas.SetLeft(recs[i].tbIndex, xn + recWidth / 2 - recs[i].tbIndex.ActualWidth / 2);
                    }
                }
                canvas.Children.Remove(r.rec);
                canvas.Children.Remove(r.tbNum);
                canvas.Children.Remove(r.tbIndex);
            }
        }

        public void RemoveRecs()
        {
            if (recs.Count == 0) return;
            for (int i = 0; i < removeRecsCount; i++)
            {
                RemoveRec(false);
                if (recs.Count == 0) return;
            }
            removeRecsCount = recsPerAction;
        }

        public Task RemoveRecsAsync()
        {
            return Task.Run(() =>
            {
                if (recs.Count == 0) return;
                int removeAmount = autoAmount ? removeRecsCount : int.Parse(tbAmount.Text);
                for (int i = 0; i < removeAmount; i++)
                {
                    SafeInvoke(() =>
                    {
                        try
                        {
                            RemoveRec();
                        }
                        catch { }
                    });
                    if (recs.Count == 0) return;
                    Thread.Sleep(500 / removeAmount);
                }
                removeRecsCount = recsPerAction;
            });
        }

        public void UnlockRec(VisualRec vr, int index = -1)
        {
            double height = vr.rec.Height, width = vr.rec.Width, x = Canvas.GetLeft(vr.rec), y = Canvas.GetTop(vr.rec);

            Rectangle r = new Rectangle();
            r.Width = width; r.Height = height; r.Fill = Brushes.Black;
            r.RadiusX = recRadius; r.RadiusY = recRadius;
            Canvas.SetLeft(r, x);
            Canvas.SetTop(r, y);
            canvas.Children.Remove(vr.rec);
            canvas.Children.Add(r);

            TextBlock tbNum = new TextBlock();
            tbNum.Foreground = Brushes.White;
            tbNum.Width = Double.NaN;
            tbNum.Height = Double.NaN;
            tbNum.Text = vr.tbNum.Text;

            TextBlock tbIndex = new TextBlock();
            tbIndex.Foreground = Brushes.Gray;
            tbIndex.Width = Double.NaN;
            tbIndex.Height = Double.NaN;
            tbIndex.Text = index == -1 ? vr.tbIndex.Text : index + "";

            canvas.Children.Remove(vr.tbNum);
            canvas.Children.Add(tbNum);
            tbNum.Measure(new Size());
            tbNum.Arrange(new Rect());
            Canvas.SetLeft(tbNum, x + width / 2 - tbNum.ActualWidth / 2);
            Canvas.SetTop(tbNum, y + height - tbNum.ActualHeight - offsetNum);

            if (index == -1) canvas.Children.Remove(vr.tbIndex);
            canvas.Children.Add(tbIndex);
            tbIndex.Measure(new Size());
            tbIndex.Arrange(new Rect());
            Canvas.SetLeft(tbIndex, x + width / 2 - tbIndex.ActualWidth / 2);
            Canvas.SetTop(tbIndex, y + height + offsetIndex);

            vr.rec = r;
            vr.tbNum = tbNum;
            vr.tbIndex = tbIndex;
            vr.index = index == -1 ? vr.index : index;
        }

        public void UnlockRecs(bool newIndexes = false)
        {
            if (newIndexes)
            {
                for (int i = 0; i < canvas.Children.Count; i++)
                {
                    var child = canvas.Children[i];
                    if (child is TextBlock && ((TextBlock)child).Foreground != Brushes.White)
                    {
                        canvas.Children.Remove(child);
                    }
                }
            }
            for (int i = 0; i < recs.Count; i++)
            {
                UnlockRec(recs[i], newIndexes ? i : -1);
            }
        }

        public Task RefreshRecsAsync() //bug with deleting detected
        {
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
                            int num = rnd.Next(minRecHeight, maxRecHeight);
                            double height = num * (elementHost1.Height - (offsetBottom + offsetTop)) / 100.0;
                            double width = recs[i].rec.Width, x = Canvas.GetLeft(recs[i].rec);

                            Rectangle r = new Rectangle();
                            r.Width = width; r.Height = height; r.Fill = Brushes.Black;
                            r.RadiusX = recRadius; r.RadiusY = recRadius;
                            Canvas.SetLeft(r, x);
                            double y = elementHost1.Height - height - offsetBottom;
                            Canvas.SetTop(r, y);
                            canvas.Children.Remove(recs[i].rec);
                            canvas.Children.Add(r);

                            TextBlock tbNum = new TextBlock();
                            tbNum.Foreground = Brushes.White;
                            tbNum.Width = Double.NaN;
                            tbNum.Height = Double.NaN;
                            tbNum.Text = num.ToString();
                            canvas.Children.Remove(recs[i].tbNum);
                            canvas.Children.Add(tbNum);
                            tbNum.Measure(new Size());
                            tbNum.Arrange(new Rect());
                            Canvas.SetLeft(tbNum, x + width / 2 - tbNum.ActualWidth / 2);
                            Canvas.SetTop(tbNum, y + height - tbNum.ActualHeight - offsetNum);

                            recs[i].rec = r;
                            recs[i].tbNum = tbNum;
                            recs[i].num = num;
                            Storyboard.SetTarget(animRefreshColor, recs[i].rec);
                            graphicsComponent.storybRefresh.Begin(graphicsComponent);
                        }
                        catch (Exception e) { }
                    });
                    Thread.Sleep(500 / recs.Count);
                }
                sw.Reset();
            });
        }

        public void SafeInvoke(Action a)
        {
            graphicsComponent.Dispatcher.Invoke(a, System.Windows.Threading.DispatcherPriority.Background);
        }

        public Task VisualSortBubble(bool asc = true)
        {
            return Task.Run(() =>
            {
                if (recs.Count < 2)
                {
                    SafeInvoke(() =>
                    {
                        SetEnabledSorting(true);
                    });
                    stopSort = sorting = false;
                };
                sorting = true;
                VisualRec recjPrev = null, reciPrev = null;
                for (int i = 0; i < recs.Count - 1; i++)
                {
                    for (int j = i + 1; j < recs.Count; j++)
                    {
                        SafeInvoke(() =>
                        {
                            if (reciPrev != null && reciPrev != recs[i])
                            {
                                reciPrev.rec.Fill = Brushes.Black;
                                reciPrev.tbIndex.Inlines.Clear();
                                reciPrev.tbIndex.Text = reciPrev.index.ToString();
                            }
                            recs[i].rec.Fill = Brushes.Blue;
                            Run runi = new Run(recs[i].tbIndex.Text);
                            runi.Foreground = Brushes.Blue;
                            recs[i].tbIndex.Text = "";
                            recs[i].tbIndex.Inlines.Add(new Bold(runi));

                            if (recjPrev != null)
                            {
                                recjPrev.rec.Fill = Brushes.Black;
                                recjPrev.tbIndex.Inlines.Clear();
                                recjPrev.tbIndex.Text = recjPrev.index.ToString();
                            }
                            recs[j].rec.Fill = Brushes.Red;
                            Run runj = new Run(recs[j].tbIndex.Text);
                            runj.Foreground = Brushes.Red;
                            recs[j].tbIndex.Text = "";
                            recs[j].tbIndex.Inlines.Add(new Bold(runj));
                        });
                        Thread.Sleep((int)(animMSDefualt * animSpeed));
                       
                        if (asc ? recs[j].num < recs[i].num : recs[j].num > recs[i].num)
                        {
                            fullSwapEnd = false;
                            SafeInvoke(() =>
                            {
                                VisualRec r = recs[i];
                                recs[i] = recs[j];
                                recs[j] = r;

                                TextBlock tb = recs[i].tbIndex;
                                recs[i].tbIndex = recs[j].tbIndex;
                                recs[j].tbIndex = tb;

                                int ind = recs[i].index;
                                recs[i].index = recs[j].index;
                                recs[j].index = ind;

                                reci = recs[i];
                                recj = recs[j];
                                reciHeight = reci.rec.Height;
                                reciTop = Canvas.GetTop(reci.rec);
                                recjHeight = recj.rec.Height;
                                recjTop = Canvas.GetTop(recj.rec);

                                Canvas.SetZIndex(recs[i].rec, 9996);
                                Canvas.SetZIndex(recs[j].rec, 9997);
                                Canvas.SetZIndex(recs[i].tbNum, 9998);
                                Canvas.SetZIndex(recs[j].tbNum, 9999);
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
                            });
                        }
                        reciPrev = recs[i];
                        recjPrev = recs[j];
                        
                        while (!fullSwapEnd) { }
                        if (stopSort)
                        {
                            SafeInvoke(() =>
                            {
                                UnlockRecs();
                                SetEnabledSorting(true);
                            });
                            stopSort = sorting = false;
                            return;
                        }
                        SafeInvoke(() =>
                        {
                            Canvas.SetZIndex(recs[i].rec, 0);
                            Canvas.SetZIndex(recs[j].rec, 1);
                            Canvas.SetZIndex(recs[i].tbNum, 2);
                            Canvas.SetZIndex(recs[j].tbNum, 3);
                        });
                    }
                }

                for (int i = 2; i > -1; i--)
                {
                    SafeInvoke(() =>
                    {
                        try
                        {
                            recs[recs.Count - i - 1].rec.Fill = Brushes.Black;
                        }
                        catch { }
                    });
                }
                SafeInvoke(() =>
                {
                    UnlockRecs();
                    SetEnabledSorting(true);
                });
                stopSort = sorting = false;
            });
        }

        public Task VisualSortInsertion(bool asc = true)
        {
            return Task.Run(() =>
            {
                if (recs.Count < 2)
                {
                    SafeInvoke(() =>
                    {
                        SetEnabledSorting(true);
                    });
                    stopSort = sorting = false;
                };
                sorting = true;
                VisualRec recjPrev = null, reciPrev = null;
                for (int i = 1; i < recs.Count; i++)
                {
                    VisualRec cur = recs[i];
                    int j = i;
                    bool needTransform = j > 0 && (asc ? cur.num < recs[j - 1].num : cur.num > recs[j - 1].num);
                    if (needTransform)
                    {
                        SafeInvoke(() =>
                        {
                            reciHeight = cur.rec.Height;
                            reciTop = Canvas.GetTop(cur.rec);
                            Canvas.SetZIndex(cur.rec, 9998);
                            Canvas.SetZIndex(cur.tbNum, 9999);

                            //if (reciPrev != null && reciPrev != recs[i])
                            //{
                            //    reciPrev.rec.Fill = Brushes.Black;
                            //    reciPrev.tbIndex.Inlines.Clear();
                            //    reciPrev.tbIndex.Text = reciPrev.index.ToString();
                            //}
                            cur.rec.Fill = Brushes.Blue;
                            Run runi = new Run(cur.tbIndex.Text);
                            runi.Foreground = Brushes.Blue;
                            cur.tbIndex.Text = "";
                            cur.tbIndex.Inlines.Add(new Bold(runi));

                            transformingDown = false;
                            fullSwapEnd = false;
                            TransformRecDown(cur);
                        });
                        while (!fullSwapEnd) { }
                    }
                    while (j > 0 && (asc ? cur.num < recs[j - 1].num : cur.num > recs[j - 1].num))
                    {
                        Thread.Sleep((int)(animMSDefualt * animSpeed));

                        fullSwapEnd = false;
                        SafeInvoke(() =>
                        {

                            Canvas.SetZIndex(recs[j - 1].rec, 9996);
                            Canvas.SetZIndex(recs[j - 1].tbNum, 9997);

                            ReplaceRec(j - 1, j);
                        });

                        while (!fullSwapEnd) { }
                        SafeInvoke(() =>
                        {
                            Canvas.SetZIndex(recs[i].rec, 0);
                            Canvas.SetZIndex(recs[j].rec, 1);
                            Canvas.SetZIndex(recs[i].tbNum, 2);
                            Canvas.SetZIndex(recs[j].tbNum, 3);
                        });
                        j--;
                        if (stopSort)
                        {
                            fullSwapEnd = false;
                            SafeInvoke(() =>
                            {
                                MoveTempCircle(cur, j);
                            });
                            while (!fullSwapEnd) { }
                            SafeInvoke(() =>
                            {
                                UnlockRecs();
                                SetEnabledSorting(true);
                            });
                            stopSort = sorting = false;
                            return;
                        }
                    }
                    Thread.Sleep((int)(animMSDefualt * animSpeed));
                    if (needTransform)
                    {
                        fullSwapEnd = false;
                        SafeInvoke(() =>
                        {
                            MoveTempCircle(cur, j);
                        });
                        while (!fullSwapEnd) { }
                    }
                }

                //for (int i = 2; i > -1; i--)
                //{
                //    SafeInvoke(() =>
                //    {
                //        try
                //        {
                //            recs[recs.Count - i - 1].rec.Fill = Brushes.Black;
                //        }
                //        catch { }
                //    });
                //}
                SafeInvoke(() =>
                {
                    UnlockRecs();
                    SetEnabledSorting(true);
                });
                stopSort = sorting = false;
            });
        }

        public Task VisualSortQuick(bool asc = true)
        {
            return Task.Run(() =>
            {
                if (recs.Count < 2)
                {
                    SafeInvoke(() =>
                    {
                        SetEnabledSorting(true);
                    });
                    stopSort = sorting = false;
                };
                sorting = true;
                VisualRec recjPrev = null, reciPrev = null;
                for (int i = 1; i < recs.Count; i++)
                {
                    for (int j = i + 1; j < recs.Count; j++)
                    {
                        SafeInvoke(() =>
                        {
                            if (reciPrev != null && reciPrev != recs[i])
                            {
                                reciPrev.rec.Fill = Brushes.Black;
                                reciPrev.tbIndex.Inlines.Clear();
                                reciPrev.tbIndex.Text = reciPrev.index.ToString();
                            }
                            recs[i].rec.Fill = Brushes.Blue;
                            Run runi = new Run(recs[i].tbIndex.Text);
                            runi.Foreground = Brushes.Blue;
                            recs[i].tbIndex.Text = "";
                            recs[i].tbIndex.Inlines.Add(new Bold(runi));

                            if (recjPrev != null)
                            {
                                recjPrev.rec.Fill = Brushes.Black;
                                recjPrev.tbIndex.Inlines.Clear();
                                recjPrev.tbIndex.Text = recjPrev.index.ToString();
                            }
                            recs[j].rec.Fill = Brushes.Red;
                            Run runj = new Run(recs[j].tbIndex.Text);
                            runj.Foreground = Brushes.Red;
                            recs[j].tbIndex.Text = "";
                            recs[j].tbIndex.Inlines.Add(new Bold(runj));
                        });
                        Thread.Sleep((int)(animMSDefualt * animSpeed));

                        if ((asc && recs[j].num < recs[i].num) || (!asc && recs[j].num > recs[i].num))
                        {
                            fullSwapEnd = false;
                            SafeInvoke(() =>
                            {
                                VisualRec r = recs[i];
                                recs[i] = recs[j];
                                recs[j] = r;

                                TextBlock tb = recs[i].tbIndex;
                                recs[i].tbIndex = recs[j].tbIndex;
                                recs[j].tbIndex = tb;

                                int ind = recs[i].index;
                                recs[i].index = recs[j].index;
                                recs[j].index = ind;

                                reci = recs[i];
                                recj = recs[j];
                                reciHeight = reci.rec.Height;
                                reciTop = Canvas.GetTop(reci.rec);
                                recjHeight = recj.rec.Height;
                                recjTop = Canvas.GetTop(recj.rec);

                                Canvas.SetZIndex(recs[i].rec, 9996);
                                Canvas.SetZIndex(recs[j].rec, 9997);
                                Canvas.SetZIndex(recs[i].tbNum, 9998);
                                Canvas.SetZIndex(recs[j].tbNum, 9999);
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
                            });
                        }
                        reciPrev = recs[i];
                        recjPrev = recs[j];

                        while (!fullSwapEnd) { }
                        if (stopSort)
                        {
                            SafeInvoke(() =>
                            {
                                UnlockRecs();
                                SetEnabledSorting(true);
                            });
                            stopSort = sorting = false;
                            return;
                        }
                        SafeInvoke(() =>
                        {
                            Canvas.SetZIndex(recs[i].rec, 0);
                            Canvas.SetZIndex(recs[j].rec, 1);
                            Canvas.SetZIndex(recs[i].tbNum, 2);
                            Canvas.SetZIndex(recs[j].tbNum, 3);
                        });
                    }
                }

                for (int i = 2; i > -1; i--)
                {
                    SafeInvoke(() =>
                    {
                        try
                        {
                            recs[recs.Count - i - 1].rec.Fill = Brushes.Black;
                        }
                        catch { }
                    });
                }
                SafeInvoke(() =>
                {
                    UnlockRecs();
                    SetEnabledSorting(true);
                });
                stopSort = sorting = false;
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

        public void SwapRecs(VisualRec r1, VisualRec r2)
        {
            recsSwaping += 4;
            double r1Left = Canvas.GetLeft(r1.rec), r2Left = Canvas.GetLeft(r2.rec),
                tb1Left = Canvas.GetLeft(r1.tbNum), tb2Left = Canvas.GetLeft(r2.tbNum);
            double distance = r2Left - r1Left;

            animSwapLeft.To = r2Left;
            Storyboard.SetTarget(animSwapLeft, r1.rec);
            graphicsComponent.storybSwap.Begin(graphicsComponent);

            animSwapLeft.To = r1Left;
            Storyboard.SetTarget(animSwapLeft, r2.rec);
            graphicsComponent.storybSwap.Begin(graphicsComponent);

            animSwapLeft.To = tb1Left + distance;
            Storyboard.SetTarget(animSwapLeft, r1.tbNum);
            graphicsComponent.storybSwap.Begin(graphicsComponent);

            animSwapLeft.To = tb2Left - distance;
            Storyboard.SetTarget(animSwapLeft, r2.tbNum);
            graphicsComponent.storybSwap.Begin(graphicsComponent);
        }

        bool movingTempCircle = false, replacingRec = false;
        void storybMoveLeft_Completed(object sender, EventArgs e)
        {
            replaceCounter--;
            if (replaceCounter == 0)
            {
                if (replacingRec)
                {
                    recs[indexToTemp] = recs[indexFromTemp];
                    recs[indexFromTemp] = new VisualRec(recReplaceFrom.rec, recReplaceFrom.tbNum, recReplaceFrom.tbIndex, recReplaceFrom.num, indexFromTemp);
                    recs[indexToTemp].index = recReplaceTo.index;
                    recs[indexToTemp].tbIndex = recReplaceTo.tbIndex;
                    replacingRec = false;
                    fullSwapEnd = true;
                }
                else if (movingTempCircle)
                {
                    recReplaceFrom.index = recs[indexToTemp].index;
                    recReplaceFrom.tbIndex = recs[indexToTemp].tbIndex;
                    recs[indexToTemp] = recReplaceFrom;
                    movingTempCircle = false;
                    TransformRecUp(recReplaceFrom, reciHeight, reciTop);
                }
            }
        }

        void MoveTempCircle(VisualRec cur, int indexTo)
        {
            movingTempCircle = true;
            indexToTemp = indexTo;
            replaceCounter = 2;
            recReplaceFrom = cur;

            double x = offsetSides + indexTo * (recWidth + offsetBetween);
            animMoveLeft.To = x;
            Storyboard.SetTarget(animMoveLeft, cur.rec);
            graphicsComponent.storybMoveLeft.Begin(graphicsComponent);

            animMoveLeft.To = x + recWidth / 2 - cur.tbNum.ActualWidth / 2;
            Storyboard.SetTarget(animMoveLeft, cur.tbNum);
            graphicsComponent.storybMoveLeft.Begin(graphicsComponent);
        }

        VisualRec recReplaceFrom, recReplaceTo;
        int indexFromTemp = 0, indexToTemp = 0, replaceCounter = 0; 
        public void ReplaceRec(int indexFrom, int indexTo)
        {
            indexFromTemp = indexFrom; indexToTemp = indexTo;
            recReplaceFrom = recs[indexFrom]; recReplaceTo = recs[indexTo]; 
            double recFromLeft = Canvas.GetLeft(recReplaceFrom.rec), recToLeft = indexTo * (offsetBetween + recWidth) + offsetSides;
            double tbFromLeft = Canvas.GetLeft(recReplaceFrom.tbNum), tbToLeft = recToLeft + recWidth / 2 - recReplaceFrom.tbNum.ActualWidth / 2;

            replaceCounter = 2;

            replacingRec = true;
            animMoveLeft.To = recToLeft;
            Storyboard.SetTarget(animMoveLeft, recReplaceFrom.rec);
            graphicsComponent.storybMoveLeft.Begin(graphicsComponent);

            animMoveLeft.To = tbToLeft;
            Storyboard.SetTarget(animMoveLeft, recReplaceFrom.tbNum);
            graphicsComponent.storybMoveLeft.Begin(graphicsComponent);
        }

        private VisualRec CloneRec(VisualRec recFrom)
        {
            double height = recFrom.rec.Height, width = recFrom.rec.Width, x = Canvas.GetLeft(recFrom.rec), y = Canvas.GetTop(recFrom.rec);

            Rectangle r = new Rectangle();
            r.Width = width; r.Height = height; r.Fill = Brushes.Black;
            r.RadiusX = recRadius; r.RadiusY = recRadius;
            Canvas.SetLeft(r, x);
            Canvas.SetTop(r, y);
            canvas.Children.Add(r);

            TextBlock tbNum = new TextBlock();
            tbNum.Foreground = Brushes.White;
            tbNum.Width = Double.NaN;
            tbNum.Height = Double.NaN;
            tbNum.Text = recFrom.tbNum.Text;

            canvas.Children.Add(tbNum);
            tbNum.Measure(new Size());
            tbNum.Arrange(new Rect());
            Canvas.SetLeft(tbNum, x + width / 2 - tbNum.ActualWidth / 2);
            Canvas.SetTop(tbNum, y + height - tbNum.ActualHeight - offsetNum);

            return new VisualRec(r, tbNum, recFrom.tbIndex, recFrom.num, recFrom.index);
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

        public void TransformRecDown(VisualRec r)
        {
            recsTransforming += 2;
            animTransformHeight.To = r.rec.Width;
            animTransformRadiusX.To = r.rec.Width / 2;
            animTransformRadiusY.To = r.rec.Width / 2;
            animTransformTop.To = Canvas.GetTop(r.rec) + r.rec.Height + offsetCircle;
            Storyboard.SetTarget(animTransformHeight, r.rec);
            Storyboard.SetTarget(animTransformRadiusX, r.rec);
            Storyboard.SetTarget(animTransformRadiusY, r.rec);
            Storyboard.SetTarget(animTransformTop, r.rec);
            graphicsComponent.storybTransform.Begin(graphicsComponent);

            animTransformTop.To = animTransformTop.To + r.rec.Width / 2 - r.tbNum.ActualHeight / 2;
            Storyboard.SetTarget(animTransformTop, r.tbNum);
            graphicsComponent.storybTransform.Begin(graphicsComponent);
        }

        public void TransformRecUp(VisualRec r, double height, double top)
        {
            recsTransforming += 2;
            animTransformHeight.To = height;
            animTransformRadiusX.To = recRadius;
            animTransformRadiusY.To = recRadius;
            animTransformTop.To = top;
            Storyboard.SetTarget(animTransformHeight, r.rec);
            Storyboard.SetTarget(animTransformRadiusX, r.rec);
            Storyboard.SetTarget(animTransformRadiusY, r.rec);
            Storyboard.SetTarget(animTransformTop, r.rec);
            graphicsComponent.storybTransform.Begin(graphicsComponent);

            animTransformTop.To = animTransformTop.To + height - r.tbNum.ActualHeight - offsetNum;
            Storyboard.SetTarget(animTransformTop, r.tbNum);
            graphicsComponent.storybTransform.Begin(graphicsComponent);
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            AddRecsAsync();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            RemoveRecsAsync();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            RefreshRecsAsync();
        }

        public void SetEnabledSorting(bool param)
        {
            btnPush.Enabled = btnPop.Enabled = btnRandomize.Enabled = param;
            cmbStructType.Enabled = cmbSortType.Enabled = param;
            btnSortAsc.Enabled = btnSortDesc.Enabled = param;
            btnStopSort.Enabled = !param;
            miPush.Enabled = miPop.Enabled = miRandomize.Enabled = param;
            miStructList.Enabled = miStructQueue.Enabled = miStructStack.Enabled = param;
            miSortBubble.Enabled = miSortInsertion.Enabled = miSortQuick.Enabled = param;
            miSortAsc.Enabled = miSortDesc.Enabled = param;
            miSortStop.Enabled = !param;
            if (param) SetEnabledStructType();
            else
            {
                cmbDestPush.Enabled = false;
                cmbDestPop.Enabled = false;
            }
        }

        void Sort(bool asc = true)
        {
            SetEnabledSorting(false);
            if (sortType == SortType.Bubble) VisualSortBubble(asc);
            else if (sortType == SortType.Insertion) VisualSortInsertion(asc);
            else VisualSortQuick(asc);
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            Sort();
        }

        private void btnSortDesc_Click(object sender, EventArgs e)
        {
            Sort(false);
        }

        private void miSortAsc_Click(object sender, EventArgs e)
        {
            Sort();
        }

        private void miSortDesc_Click(object sender, EventArgs e)
        {
            Sort(false);
        }

        private void toolStripButton2_Click_1(object sender, EventArgs e)
        {
            if (1 / animSpeed == animSpeedMin) return;
            animSpeed += 0.1;
            if (1 / animSpeed < animSpeedMin) animSpeed -= 0.1;
            SetAnimSpeed();
        }

        private void toolStripButton3_Click_1(object sender, EventArgs e)
        {
            if (1 / animSpeed == animSpeedMax) return;
            animSpeed -= 0.1;
            if (1 / animSpeed > animSpeedMax) animSpeed += 0.1;
            SetAnimSpeed();
        }

        public void SetAnimSpeed()
        {
            animSwapLeft.Duration = new Duration(TimeSpan.FromMilliseconds(animMSSwap * animSpeed));
            double animSpeedInverse = Math.Round(1 / animSpeed, 2);
            lblSpeed.Text = animSpeedInverse + "x";
            animateCircles = !(animSpeedInverse > 2);
        }

        int hostWidthPrev = 0, hostHeightPrev = 0;
        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            if (sorting || elementHost1.Height < 300) return;
            if (elementHost1.Height != hostHeightPrev)
            {
                for (int i = 0; i < recs.Count; i++)
                {
                    double height = recs[i].num * (elementHost1.Height - (offsetBottom + offsetTop)) / 100.0;
                    double y = elementHost1.Height - height - offsetBottom;
                    recs[i].rec.Height = height;
                    Canvas.SetTop(recs[i].rec, y);
                    Canvas.SetTop(recs[i].tbNum, y + height - recs[i].tbNum.ActualHeight - offsetNum);
                    Canvas.SetTop(recs[i].tbIndex, y + height + offsetIndex);
                }
            }
            hostHeightPrev = elementHost1.Height;
            hostWidthPrev = elementHost1.Width;
        }

        void SetEnabledStructType()
        {
            if (structType == StructType.Stack)
            {
                cmbDestPush.SelectedIndex = 0;
                cmbDestPop.SelectedIndex = 0;
                cmbDestPush.Enabled = false;
                cmbDestPop.Enabled = false;
                miPushHead.Checked = miPopHead.Checked = true;
                miPushTail.Checked = miPopTail.Checked = false;
                miPushHead.Enabled = miPushTail.Enabled = miPopHead.Enabled = miPopTail.Enabled = false;
                miStructStack.Checked = true;
                miStructQueue.Checked = miStructList.Checked = false;
            }
            else if (structType == StructType.Queue)
            {
                cmbDestPush.SelectedIndex = 1;
                cmbDestPop.SelectedIndex = 0;
                cmbDestPush.Enabled = false;
                cmbDestPop.Enabled = false;
                miPushHead.Checked = miPopTail.Checked = false;
                miPushTail.Checked = miPopHead.Checked = true;
                miPushHead.Enabled = miPushTail.Enabled = miPopHead.Enabled = miPopTail.Enabled = false;
                miStructQueue.Checked = true;
                miStructStack.Checked = miStructList.Checked = false;
            }
            else
            {
                cmbDestPush.Enabled = true;
                cmbDestPop.Enabled = true;
                miPushHead.Enabled = miPushTail.Enabled = miPopHead.Enabled = miPopTail.Enabled = true;
                miStructList.Checked = true;
                miStructQueue.Checked = miStructStack.Checked = false;
            }
        }

        private void cmbStruct_SelectedIndexChanged(object sender, EventArgs e)
        {
            structType = (StructType)cmbStructType.SelectedIndex;
            SetEnabledStructType();
        }

        private void miPushHead_Click(object sender, EventArgs e)
        {
            cmbDestPush.SelectedIndex = 0;
        }
        private void miPushTail_Click(object sender, EventArgs e)
        {
            cmbDestPush.SelectedIndex = 1;
        }

        private void miPopHead_Click(object sender, EventArgs e)
        {
            cmbDestPop.SelectedIndex = 0;
        }

        private void miPopTail_Click(object sender, EventArgs e)
        {
            cmbDestPop.SelectedIndex = 1;
        }

        private void cmbDestPush_SelectedIndexChanged(object sender, EventArgs e)
        {
            pushTail = cmbDestPush.SelectedIndex != 0;
            miPushHead.Checked = !pushTail;
            miPushTail.Checked = pushTail;
        }

        private void cmbDestPop_SelectedIndexChanged(object sender, EventArgs e)
        {
            popHead = cmbDestPop.SelectedIndex == 0;
            miPopHead.Checked = popHead;
            miPopTail.Checked = !popHead;
        }

        private void btnStopSort_Click(object sender, EventArgs e)
        {
            stopSort = true;
        }

        private void вихідToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void miAmount_CheckedChanged(object sender, EventArgs e)
        {
            autoAmount = miAmount.Checked;
        }

        private void miValue_CheckedChanged(object sender, EventArgs e)
        {
            randomValue = miValue.Checked;
        }

        private void tbAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void tbValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        void tbAmount_LostFocus(object sender, EventArgs e)
        {
            if (!miAmount.Checked && int.Parse(tbAmount.Text) < 1) tbAmount.Text = 1 + ""; 
        }

        void tbValue_LostFocus(object sender, EventArgs e)
        {
            if (!miValue.Checked && int.Parse(tbValue.Text) < 7) tbValue.Text = 7 + ""; 
        }

        private void tbAmount_TextChanged(object sender, EventArgs e)
        {
            miAmount.Checked = tbAmount.Text.Length == 0;
        }

        private void tbValue_TextChanged(object sender, EventArgs e)
        {
            miValue.Checked = tbValue.Text.Length == 0;
        }

        private void miPush_Click(object sender, EventArgs e)
        {
            AddRecsAsync();
        }

        private void miPop_Click(object sender, EventArgs e)
        {
            RemoveRecsAsync();
        }

        private void miRandomize_Click(object sender, EventArgs e)
        {
            RefreshRecsAsync();
        }

        private void miStructStack_Click(object sender, EventArgs e)
        {
            cmbStructType.SelectedIndex = 0;
        }

        private void miStructQueue_Click(object sender, EventArgs e)
        {
            cmbStructType.SelectedIndex = 1;
        }

        private void miStructList_Click(object sender, EventArgs e)
        {
            cmbStructType.SelectedIndex = 2;
        }

        private void miSortBubble_Click(object sender, EventArgs e)
        {
            cmbSortType.SelectedIndex = 0;
        }

        private void miSortInsertion_Click(object sender, EventArgs e)
        {
            cmbSortType.SelectedIndex = 1;
        }

        private void miSortQuick_Click(object sender, EventArgs e)
        {
            cmbSortType.SelectedIndex = 2;
        }

        private void miSortStop_Click(object sender, EventArgs e)
        {
            stopSort = true;
        }

        private void cmbSortType_SelectedIndexChanged(object sender, EventArgs e)
        {
            sortType = (SortType)cmbSortType.SelectedIndex;
            if (sortType == SortType.Bubble)
            {
                miSortBubble.Checked = true;
                miSortInsertion.Checked = miSortQuick.Checked = false;
            }
            else if (sortType == SortType.Insertion)
            {
                miSortInsertion.Checked = true;
                miSortBubble.Checked = miSortQuick.Checked = false;
            }
            else
            {
                miSortQuick.Checked = true;
                miSortInsertion.Checked = miSortBubble.Checked = false;
            }
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            string text = StringUtil.Decrypt("2yljXKkRhLP1A+Zn6cPxLfZrjh2A80pAyyzsDBwjaCIXDexaV1grZZsn9O/8LXYszQ8lP8iBUVinY7ZJNENMOEEXUQNP5Dv4LM+Nhrgi16fsPAy9cDwwEH8Ic9ca6W/ynqgMHz8qxMiFty+5fBNnQbci7tzEWD6nLt8h9BzvO0w=");
            string caption = StringUtil.Decrypt("F14XkANCdeMpq36n8kgEOc7Otn8cVHgRFUfD+tz4GajJwGj0ulFyWw==");
            System.Windows.Forms.MessageBox.Show(text, caption);
        }
    }
}
