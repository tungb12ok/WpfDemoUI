using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using WpfDemoUI.Helpers;

namespace WpfDemoUI.ViewModels
{
    public class LayoutHostViewModel : INotifyPropertyChanged
    {
        private string _selectedSection;
        public string SelectedSection
        {
            get => _selectedSection;
            set
            {
                if (_selectedSection != value)
                {
                    _selectedSection = value;
                    OnPropertyChanged();
                }
            }
        }

        public ICommand ShowButtonLayout { get; }
        public ICommand ShowInputLayout { get; }
        public ICommand ShowListLayout { get; }
        public ICommand ShowDialogLayout { get; }
        public ICommand ShowTabLayout { get; }
        public ICommand ShowChartLayout { get; }
        public ICommand ShowCardLayout { get; }

        public LayoutHostViewModel()
        {
            ShowButtonLayout = new RelayCommand(_ => Navigate("Button"));
            ShowInputLayout = new RelayCommand(_ => Navigate("Input"));
            ShowListLayout = new RelayCommand(_ => Navigate("List"));
            ShowDialogLayout = new RelayCommand(_ => Navigate("Dialog"));
            ShowTabLayout = new RelayCommand(_ => Navigate("Tab"));
            ShowChartLayout = new RelayCommand(_ => Navigate("Chart"));
            ShowCardLayout = new RelayCommand(_ => Navigate("Card"));

            SelectedSection = "Button"; // default
        }

        private void Navigate(string section)
        {
            SelectedSection = section;

            // TODO: Gán ViewModel/Page tương ứng cho CurrentLayout (nếu dùng ContentControl bên phải)
            // CurrentLayout = new ButtonLayoutViewModel()...
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
