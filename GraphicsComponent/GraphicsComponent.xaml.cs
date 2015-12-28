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
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GraphicsComponent
{
    /// <summary>
    /// Логика взаимодействия для GraphicsComponent.xaml
    /// </summary>
    public partial class GraphicsComponent : UserControl
    {
        public GraphicsComponent()
        {
            InitializeComponent();
            canvasGraphics.Background = Brushes.White;
        }
    }
}
