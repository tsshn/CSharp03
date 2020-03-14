using System.Windows;
using Yatsyshyn.Loader;

namespace Yatsyshyn
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new OverlayViewModel();
        }
    }
}