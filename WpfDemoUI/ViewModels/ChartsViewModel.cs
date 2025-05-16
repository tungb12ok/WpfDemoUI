using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Media;
using WpfDemoUI.Models.Objects.Views;

namespace WpfDemoUI.ViewModels
{
    public class ChartsViewModel : ViewModelBase
    {
        private ObservableCollection<BarChartItem> _barData;
        public ObservableCollection<BarChartItem> BarData
        {
            get => _barData;
            set => SetProperty(ref _barData, value);
        }

        private ObservableCollection<GroupedBarChartItem> _groupedBarData;
        public ObservableCollection<GroupedBarChartItem> GroupedBarData
        {
            get => _groupedBarData;
            set => SetProperty(ref _groupedBarData, value);
        }

        public ChartsViewModel()
        {
            LoadChartData();
        }

        private void LoadChartData()
        {
            BarData = new ObservableCollection<BarChartItem>
            {
                new BarChartItem{Label="Jan",Value=120,FillColor=Brushes.CadetBlue},
                new BarChartItem{Label="Feb",Value=80,FillColor=Brushes.Coral},
                new BarChartItem{Label="Mar",Value=150,FillColor=Brushes.DarkCyan},
                new BarChartItem{Label="Apr",Value=60,FillColor=Brushes.Gold},
                new BarChartItem{Label="May",Value=90,FillColor=Brushes.LightSeaGreen},
                new BarChartItem{Label="Jun",Value=110,FillColor=Brushes.OrangeRed},
            };

            GroupedBarData = new ObservableCollection<GroupedBarChartItem>
            {
                new GroupedBarChartItem
                {
                    GroupLabel = "Jan",
                    Items = new List<BarItem>
                    {
                        new BarItem {Series = "A", Value = 50, FillColor = Brushes.Blue},
                        new BarItem {Series = "B", Value = 70, FillColor = Brushes.Red},
                        new BarItem {Series = "C", Value = 90, FillColor = Brushes.Green}
                    }
                },
                new GroupedBarChartItem
                {
                    GroupLabel = "Feb",
                    Items = new List<BarItem>
                    {
                        new BarItem {Series = "A", Value = 60, FillColor = Brushes.Blue},
                        new BarItem {Series = "B", Value = 80, FillColor = Brushes.Red},
                        new BarItem {Series = "C", Value = 110, FillColor = Brushes.Green}
                    }
                },
                new GroupedBarChartItem
                {
                    GroupLabel = "Mar",
                    Items = new List<BarItem>
                    {
                        new BarItem {Series = "A", Value = 55, FillColor = Brushes.Blue},
                        new BarItem {Series = "B", Value = 65, FillColor = Brushes.Red},
                        new BarItem {Series = "C", Value = 95, FillColor = Brushes.Green}
                    }
                },
            };
        }
    }
}
