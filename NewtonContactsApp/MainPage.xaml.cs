using System.Collections.ObjectModel;
using System.Linq;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using NewtonContactsApp.Model;

namespace NewtonContactsApp
{
    public sealed partial class MainPage : Page
    {
        public static ObservableCollection<Contact> FilteredContacts; 
        public MainPage()
        {
            this.InitializeComponent();
            frameMain.Navigate(typeof (GridViewPage));
        }
        private void BtnHamburger_OnClick(object sender, RoutedEventArgs e)
        {
            splitviewMenu.IsPaneOpen = !splitviewMenu.IsPaneOpen;
        }
        private void BtnSearch_OnClick(object sender, RoutedEventArgs e)
        {
            string searchValue = txtboxSearch.Text.ToLower();

                var searchResult = MockContactsRepo.DbInstance.GetAll()
                .Where(c => 
                c.Name.ToLower().Contains(searchValue) ||
                c.Address.ToLower().Contains(searchValue) ||
                c.City.ToLower().Contains(searchValue) ||
                c.CareOf.ToLower().Contains(searchValue) ||
                c.Country.ToLower().Contains(searchValue) ||
                c.EmailAddress.ToLower().Contains(searchValue) ||
                c.PostalCode.ToLower().Contains(searchValue) ||
                c.PhoneNumber.ToLower().Contains(searchValue)
                ).ToList();

            FilteredContacts = new ObservableCollection<Contact>(searchResult);
            txtboxSearch.Text="";
            frameMain.Navigate(typeof (ListViewPage));
            
        }

        private void ListBoxMenu_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ListBoxItem1.IsSelected)
            {
                FilteredContacts = null;
                frameMain.Navigate(typeof(GridViewPage));
            }
            else if (ListBoxItem2.IsSelected)
            {
                FilteredContacts = null;
                frameMain.Navigate(typeof(ListViewPage));

            }
            else if (ListBoxItem3.IsSelected)
            {
                FilteredContacts = null;
                frameMain.Navigate(typeof(AddNewContactPage));
            }
        }
    }
}
