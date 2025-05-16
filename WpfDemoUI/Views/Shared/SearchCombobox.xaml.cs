using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using WpfDemoUI.Models.Objects.Views;

namespace WpfDemoUI.Views.Shared
{
    public partial class SearchCombobox : UserControl
    {
        public SearchCombobox()
        {
            InitializeComponent();
            FilteredItems = new ObservableCollection<Member>();
        }

        public static readonly DependencyProperty ItemsProperty =
            DependencyProperty.Register(nameof(Items), typeof(ObservableCollection<Member>), typeof(SearchCombobox),
                new PropertyMetadata(null, OnItemsChanged));

        public ObservableCollection<Member> Items
        {
            get => (ObservableCollection<Member>)GetValue(ItemsProperty);
            set => SetValue(ItemsProperty, value);
        }

        private static void OnItemsChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var control = (SearchCombobox)d;
            control.FilterItems();
        }
        public static readonly DependencyProperty DisplayMemberPathProperty =
            DependencyProperty.Register(nameof(DisplayMemberPath), typeof(string), typeof(SearchCombobox), new PropertyMetadata("Display"));

        public static readonly DependencyProperty SelectedValuePathProperty =
            DependencyProperty.Register(nameof(SelectedValuePath), typeof(string), typeof(SearchCombobox), new PropertyMetadata("Value"));

        public string DisplayMemberPath
        {
            get => (string)GetValue(DisplayMemberPathProperty);
            set => SetValue(DisplayMemberPathProperty, value);
        }

        public string SelectedValuePath
        {
            get => (string)GetValue(SelectedValuePathProperty);
            set => SetValue(SelectedValuePathProperty, value);
        }

        public static readonly DependencyProperty SelectedValueProperty =
            DependencyProperty.Register(nameof(SelectedValue), typeof(string), typeof(SearchCombobox),
                new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

        public string SelectedValue
        {
            get => (string)GetValue(SelectedValueProperty);
            set => SetValue(SelectedValueProperty, value);
        }

        private string _searchText;
        public string SearchText
        {
            get => _searchText;
            set
            {
                _searchText = value;
                FilterItems();
            }
        }

        public ObservableCollection<Member> FilteredItems { get; set; }

        private void FilterItems()
        {
            if (Items == null)
            {
                FilteredItems.Clear();
                return;
            }

            var filtered = string.IsNullOrWhiteSpace(SearchText)
                ? Items
                : new ObservableCollection<Member>(
                    Items.Where(m => m.Display?.ToLower().Contains(SearchText.ToLower()) == true));

            FilteredItems.Clear();
            foreach (var item in filtered)
                FilteredItems.Add(item);
        }
    }
}
