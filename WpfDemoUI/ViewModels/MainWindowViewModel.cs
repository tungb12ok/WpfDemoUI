using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Input;
using WpfDemoUI.Helpers;
using WpfDemoUI.Views.Layouts;

namespace WpfDemoUI.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        // Tab Collection
        public ObservableCollection<TabItemViewModel> Tabs { get; } = new ObservableCollection<TabItemViewModel>();

        private TabItemViewModel _selectedTab;
        public TabItemViewModel SelectedTab
        {
            get => _selectedTab;
            set => SetProperty(ref _selectedTab, value);
        }

        // Commands
        public ICommand ShowButtonLayout { get; }
        public ICommand ShowThemeLayout { get; }

        public MainWindowViewModel()
        {
            ShowButtonLayout = new RelayCommand(_ => OpenTab("Button Components", new ButtonComponentsView()));
            ShowThemeLayout = new RelayCommand(_ => OpenTab("Theme Settings", new ThemeSwitcherView()));
        }

        // Tab Navigation
        private void OpenTab(string title, UserControl view)
        {
            var existing = Tabs.FirstOrDefault(t => t.Title == title);
            if (existing != null)
            {
                SelectedTab = existing;
                return;
            }

            var newTab = new TabItemViewModel(title, view, CloseTab);
            Tabs.Add(newTab);
            SelectedTab = newTab;
        }

        private void CloseTab(TabItemViewModel tab)
        {
            if (Tabs.Contains(tab))
                Tabs.Remove(tab);

            if (SelectedTab == tab)
                SelectedTab = Tabs.LastOrDefault();
        }
    }
}
