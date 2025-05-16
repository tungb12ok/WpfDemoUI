using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using WpfDemoUI.Models.Objects.Views;
using WpfDemoUI.Helpers;

namespace WpfDemoUI.Views.Shared
{
    public partial class GroupedBarChartControl : UserControl
    {
        public GroupedBarChartControl()
        {
            InitializeComponent();
            Loaded += (s, e) => UpdateScale();
        }

        public static readonly DependencyProperty ItemsSourceProperty =
            DependencyProperty.Register("ItemsSource", typeof(ObservableCollection<GroupedBarChartItem>), typeof(GroupedBarChartControl),
                new PropertyMetadata(null, OnItemsChanged));

        public static readonly DependencyProperty TitleProperty =
            DependencyProperty.Register("Title", typeof(string), typeof(GroupedBarChartControl), new PropertyMetadata("Grouped Bar Chart"));

        public ObservableCollection<GroupedBarChartItem> ItemsSource
        {
            get => (ObservableCollection<GroupedBarChartItem>)GetValue(ItemsSourceProperty);
            set => SetValue(ItemsSourceProperty, value);
        }

        public string Title
        {
            get => (string)GetValue(TitleProperty);
            set => SetValue(TitleProperty, value);
        }

        private static void OnItemsChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is GroupedBarChartControl ctrl)
                ctrl.UpdateScale();
        }

        private void UpdateScale()
        {
            if (ItemsSource == null || !ItemsSource.Any()) return;

            var maxVal = ItemsSource.SelectMany(g => g.Items).Max(b => b.Value);
            var roundedMax = System.Math.Ceiling(maxVal / 10) * 10;

            Resources["ValueToHeightConverter"] = new ValueToHeightConverter
            {
                MaxValue = roundedMax,
                MaxHeight = 150
            };

            DataContext = null;
            DataContext = this;
        }
    }
}
