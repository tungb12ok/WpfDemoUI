using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Serilog;
using WpfDemoUI.Helpers;
using WpfDemoUI.Services;
using WpfDemoUI.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    public ObservableCollection<TabItemViewModel> Tabs { get; }
    private TabItemViewModel _selectedTab;

    public TabItemViewModel SelectedTab
    {
        get => _selectedTab;
        set => SetProperty(ref _selectedTab, value);
    }

    public ICommand NavigateCommand { get; }
    public INavigationService Navigation { get; }

    public MainWindowViewModel(IViewFactory viewFactory)
    {
        try
        {
            Log.Information("MainWindowViewModel constructor started");

            Tabs = new ObservableCollection<TabItemViewModel>();
            Navigation = new NavigationService(viewFactory, Tabs, tab => SelectedTab = tab);

            NavigateCommand = new RelayCommand(param =>
                                    {
                                        if (param is string key)
                                            Navigation.NavigateTo(key);
                                    });

            Log.Information("MainWindowViewModel initialized");
        }
        catch (Exception ex)
        {
            Log.Fatal(ex, "Failed in MainWindowViewModel constructor");
            throw;
        }
    }

}
