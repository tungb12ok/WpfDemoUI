using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using WpfDemoUI.Views.Layouts;
using WpfDemoUI.Views.Shared;

namespace WpfDemoUI.Services
{
    public interface IViewFactory
    {
        UserControl CreateView(string key);
    }
    public class ViewFactory : IViewFactory
    {
        private readonly Dictionary<string, Func<UserControl>> _map = new Dictionary<string, Func<UserControl>>
        {
            { "Button Components", () => new ButtonComponentsView() },
            { "Input Components", () => new InputComponentsView() },
            { "Theme Settings", () => new ThemeSwitcherView() },
            { "Charts", () => new ChartsView() },
            { "Home", () => new ButtonComponentsView() },
        };

        public UserControl CreateView(string key)
        {
            return _map.TryGetValue(key, out var factory) ? factory() : null;
        }
    }

}
