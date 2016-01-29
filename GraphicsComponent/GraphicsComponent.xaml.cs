using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GraphicsComponent
{
    public partial class GraphicsComponent : UserControl
    {
        public Storyboard storybAppear;
        public Storyboard storybDisappear;
        public Storyboard storybRefresh;
        public Storyboard storybTransform;
        public Storyboard storybSwap;
        public Storyboard storybRemove;
        public Storyboard storybMoveLeft;
        public Storyboard storybMoveTop;

        public GraphicsComponent()
        {
            InitializeComponent();
            canvasGraphics.Background = Brushes.White;
            this.Name = "graphicsComponentName";
        }
    }
}
