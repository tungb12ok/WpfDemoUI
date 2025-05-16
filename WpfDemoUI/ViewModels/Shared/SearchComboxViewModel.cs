using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfDemoUI.Models.Objects.Views;

namespace WpfDemoUI.ViewModels.Shared
{
    public class SearchComboxViewModel : ViewModelBase
    {
        private string _searchText;
        public string SearchText
        {
            get => _searchText;
            set
            {
                if (_searchText != value)
                {
                    _searchText = value;
                    OnPropertyChanged(nameof(SearchText));
                }
            }
        }
        private ObservableCollection<Member> _items = new ObservableCollection<Member>();

        public ObservableCollection<Member> Items
        {
            get => _items;
            set
            {
                if (_items != value)
                {
                    _items = value;
                    OnPropertyChanged(nameof(Items));
                }
            }
        }   

        private ObservableCollection<Member> _filteredItems = new ObservableCollection<Member>();

        public ObservableCollection<Member> FilteredItems
        {
            get => _filteredItems;
            set
            {
                if (_filteredItems != value)
                {
                    _filteredItems = value;
                    OnPropertyChanged(nameof(FilteredItems));
                }
            }
        }
            
        public void FilterItems()
        {
            if (string.IsNullOrEmpty(SearchText))
            {
                FilteredItems = new ObservableCollection<Member>(Items);
            }
            else
            {
                SearchText = SearchText.Trim().ToLower();
                var filtered = Items.Where(i => i.Display.Contains(SearchText));
                FilteredItems = new ObservableCollection<Member>(filtered);
            }
        }
    }
}
