using System;
using System.IO;
using System.Linq;
using System.Windows;

namespace WpfDemoUI.Helpers
{
    public static class ThemeManager
    {
        private const string ThemeFile = "theme.txt";

        public const string LightThemePath = "Resources/Themes/LightTheme.xaml";
        public const string DarkThemePath = "Resources/Themes/DarkTheme.xaml";

        public static string CurrentTheme => File.Exists(ThemeFile)
            ? File.ReadAllText(ThemeFile)
            : LightThemePath;

        public static void ApplyTheme(string relativeThemePath)
        {
            try
            {
                var uri = new Uri($"pack://application:,,,/{relativeThemePath}", UriKind.Absolute);
                var newDict = new ResourceDictionary { Source = uri };

                var oldDict = Application.Current.Resources.MergedDictionaries
                    .FirstOrDefault(d => d.Source != null && d.Source.OriginalString.Contains("/Resources/Themes/"));

                if (oldDict != null)
                    Application.Current.Resources.MergedDictionaries.Remove(oldDict);

                Application.Current.Resources.MergedDictionaries.Add(newDict);

                File.WriteAllText(ThemeFile, relativeThemePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error applying theme: {ex.Message}", "Theme Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public static void LoadLastUsedTheme()
        {
            ApplyTheme(CurrentTheme);
        }
    }
}
