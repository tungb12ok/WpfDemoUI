using System.Windows;
using WpfDemoUI.ViewModels;

namespace WpfDemoUI.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow(MainWindowViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }
    }
}
