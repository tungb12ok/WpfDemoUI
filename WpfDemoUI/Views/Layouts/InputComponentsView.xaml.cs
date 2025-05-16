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
using WpfDemoUI.ViewModels;

namespace WpfDemoUI.Views.Layouts
{
    /// <summary>
    /// Interaction logic for InputComponentsView.xaml
    /// </summary>
    public partial class InputComponentsView : UserControl
    {
        public InputComponentsView()
        {
            InitializeComponent();
            DataContext = new InputComponentsViewModel();
        }
    }
}
