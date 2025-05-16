using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfDemoUI.ViewModels;

namespace WpfDemoUI.Services
{
    public interface INavigationService
    {
        void NavigateTo(string key);
    }

    public class NavigationService : INavigationService
    {
        private readonly IViewFactory _viewFactory;
        private readonly ObservableCollection<TabItemViewModel> _tabs;
        private readonly Action<TabItemViewModel> _setSelected;

        public NavigationService(IViewFactory viewFactory, ObservableCollection<TabItemViewModel> tabs, Action<TabItemViewModel> setSelected)
        {
            _viewFactory = viewFactory;
            _tabs = tabs;
            _setSelected = setSelected;
        }

        public void NavigateTo(string key)
        {
            var existing = _tabs.FirstOrDefault(t => t.Title == key);
            if (existing != null)
            {
                _setSelected(existing);
                return;
            }

            var view = _viewFactory.CreateView(key);
            if (view == null) return;

            var newTab = new TabItemViewModel(key, view, CloseTab);
            _tabs.Add(newTab);
            _setSelected(newTab);
        }

        private void CloseTab(TabItemViewModel tab)
        {
            _tabs.Remove(tab);
        }
    }

}
