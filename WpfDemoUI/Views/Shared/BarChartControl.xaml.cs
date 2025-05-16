using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using WpfDemoUI.Helpers;
using WpfDemoUI.Models.Objects.Views;

namespace WpfDemoUI.Views.Shared
{
    public partial class BarChartControl : UserControl
    {
        public BarChartControl()
        {
            InitializeComponent();
            Loaded += (s, e) => CalculateAxes();
        }

        public static readonly DependencyProperty ItemsSourceProperty =
            DependencyProperty.Register("ItemsSource", typeof(ObservableCollection<BarChartItem>), typeof(BarChartControl),
                new PropertyMetadata(null, OnItemsChanged));

        public static readonly DependencyProperty TitleProperty =
            DependencyProperty.Register("Title", typeof(string), typeof(BarChartControl), new PropertyMetadata("Bar Chart"));

        public ObservableCollection<BarChartItem> ItemsSource
        {
            get => (ObservableCollection<BarChartItem>)GetValue(ItemsSourceProperty);
            set => SetValue(ItemsSourceProperty, value);
        }

        public string Title
        {
            get => (string)GetValue(TitleProperty);
            set => SetValue(TitleProperty, value);
        }

        public List<double> YAxisLabels { get; set; } = new List<double>();

        private static void OnItemsChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is BarChartControl ctrl)
            {
                ctrl.CalculateAxes();
            }
        }

        private void CalculateAxes()
        {
            if (ItemsSource == null || !ItemsSource.Any()) return;

            double maxVal = ItemsSource.Max(x => x.Value);
            double roundedMax = System.Math.Ceiling(maxVal / 10) * 10;

            // Y-Axis (Top to bottom)
            YAxisLabels.Clear();
            for (int i = 5; i >= 0; i--)
            {
                YAxisLabels.Add((roundedMax / 5) * i);
            }

            // Update Converter
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
