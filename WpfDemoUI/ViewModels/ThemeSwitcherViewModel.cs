using System.ComponentModel;
using System.Runtime.CompilerServices;
using WpfDemoUI.Helpers;

namespace WpfDemoUI.ViewModels
{
    public class ThemeSwitcherViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public bool IsLightTheme
        {
            get => ThemeManager.CurrentTheme.Contains("Light");
            set
            {
                if (value)
                {
                    ThemeManager.ApplyTheme(ThemeManager.LightThemePath);
                    OnPropertyChanged(nameof(IsLightTheme));
                    OnPropertyChanged(nameof(IsDarkTheme));
                }
            }
        }

        public bool IsDarkTheme
        {
            get => ThemeManager.CurrentTheme.Contains("Dark");
            set
            {
                if (value)
                {
                    ThemeManager.ApplyTheme(ThemeManager.DarkThemePath);
                    OnPropertyChanged(nameof(IsLightTheme));
                    OnPropertyChanged(nameof(IsDarkTheme));
                }
            }
        }

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
