using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfDemoUI.Models.Objects.Views;

namespace WpfDemoUI.ViewModels
{
    public class InputComponentsViewModel : ViewModelBase
    {
        public ObservableCollection<Member> MemberOptions { get; set; }
        public string SelectedValue { get; set; }

        public InputComponentsViewModel()
        {
           
        }
    }

}
