using System;
using System.Windows.Controls;
using System.Windows.Input;
using WpfDemoUI.Helpers;

namespace WpfDemoUI.ViewModels
{
    public class TabItemViewModel : ViewModelBase
    {
        public string Title { get; }
        public UserControl Content { get; }

        public ICommand CloseCommand { get; }

        public TabItemViewModel(string title, UserControl content, Action<TabItemViewModel> closeAction)
        {
            Title = title;
            Content = content;
            CloseCommand = new RelayCommand(_ => closeAction?.Invoke(this));
        }
    }
}
