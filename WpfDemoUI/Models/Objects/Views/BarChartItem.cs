using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace WpfDemoUI.Models.Objects.Views
{
    public class BarChartItem
    {
        public string Label { get; set; }          // Column name (e.g., "Q1")
        public double Value { get; set; }          // Numerical value (e.g., 75)
        public Brush FillColor { get; set; }       // Bar color
    }

}
