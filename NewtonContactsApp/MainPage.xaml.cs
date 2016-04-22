using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.ServiceModel.Channels;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.System;
using Windows.UI.Core;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using NewtonContactsApp.Model;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace NewtonContactsApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
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
