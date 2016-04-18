using NewtonContactsApp.Model;
using System;
using System.Collections.Generic;
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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace NewtonContactsApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class GridViewPage : Page
    {
        private IList<Contact> Contacts { get; set; }
        private int currentContact { get; set; }
        public GridViewPage()
        {
            this.InitializeComponent();
            Contacts = MockContactsRepo.DbInstance.GetAll();
        }

        private void gridViewMain_ItemClick(object sender, ItemClickEventArgs e)
        {
            Contact clickedContact = (Contact)e.ClickedItem;
            currentContact = clickedContact.Index;
            imageDetail.Source = new BitmapImage(
            new Uri(clickedContact.AppData, UriKind.Absolute));

            gridViewMain.Visibility = Visibility.Collapsed;
            gridViewDetail.Visibility = Visibility.Visible;

            txtblockDetailName.Text = clickedContact.Name;
            txtblockDetailAddress.Text = clickedContact.Address;
            txtblockDetailMail.Text = clickedContact.EmailAddress;
            txtblockDetailPhone.Text = clickedContact.PhoneNumber;
            txtblockDetailCareOf.Text = clickedContact.CareOf;
            txtblockDetailCity.Text = clickedContact.City;
            txtblockDetailCountry.Text = clickedContact.Country;
            txtblockDetailPostalCode.Text = clickedContact.PostalCode;
        }

        private void btnRemove_Click(object sender, RoutedEventArgs e)
        {
            MockContactsRepo.DbInstance.Delete(currentContact);

            
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
