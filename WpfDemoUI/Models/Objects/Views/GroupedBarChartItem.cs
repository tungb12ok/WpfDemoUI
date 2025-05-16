using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace WpfDemoUI.Models.Objects.Views
{
    public class GroupedBarChartItem
    {
        public string GroupLabel { get; set; } // Tháng
        public List<BarItem> Items { get; set; } // Dữ liệu các cột
    }
    public class BarItem
    {
        public string Group { get; set; }
        public double Value { get; set; }
        public Brush FillColor { get; set; }
        public string Series { get; set; }
    }
}
