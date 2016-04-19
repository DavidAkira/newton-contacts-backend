using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;
using NewtonContactsApp.Model;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace NewtonContactsApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ListViewPage : Page
    {
        public ObservableCollection<Contact> Contacts { get; set; } 
        public ListViewPage()
        {
            this.InitializeComponent();
            Contacts = MockContactsRepo.DbInstance.GetAll();
        }

        private void ListViewMaster_OnItemClick(object sender, ItemClickEventArgs e)
        {
            gridDetail.Visibility = Visibility.Visible;
            if (VisualStateGroup.CurrentState == Mobile)
            {
                listViewMaster.Visibility = Visibility.Collapsed;
                gridDetail.Visibility = Visibility.Visible;
            }
            var clickedContact = (Contact)e.ClickedItem;
            imageDetail.Source = new BitmapImage(
                new Uri(clickedContact.AppData, UriKind.Absolute));
            txtblockDetailName.Text = clickedContact.Name;
            txtblockDetailAddress.Text = clickedContact.Address;
            txtblockDetailMail.Text = clickedContact.EmailAddress;
            txtblockDetailPhone.Text = clickedContact.PhoneNumber;
            txtblockDetailCareOf.Text = clickedContact.CareOf;
            txtblockDetailCity.Text = clickedContact.City;
            txtblockDetailCountry.Text = clickedContact.Country;
            txtblockDetailPostalCode.Text = clickedContact.PostalCode;

        }

        private void BtnBack_OnClick(object sender, RoutedEventArgs e)
        {
            gridDetail.Visibility = Visibility.Collapsed;
            listViewMaster.Visibility = Visibility.Visible;
        }

        private void ListViewPage_OnLoaded(object sender, RoutedEventArgs e)
        {
            listViewMaster.Visibility = Visibility.Visible;
            gridDetail.Visibility = Visibility.Collapsed;
        }
    }
}
