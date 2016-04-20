using NewtonContactsApp.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        private ObservableCollection<Contact> Contacts { get; set; }
        private int currentContactIndex { get; set; }
        public GridViewPage()
        {
            this.InitializeComponent();
            Contacts = MockContactsRepo.DbInstance.GetAll();
        }

        private void gridViewMain_ItemClick(object sender, ItemClickEventArgs e)
        {

            Contact clickedContact = (Contact)e.ClickedItem; 
            currentContactIndex = clickedContact.Index;
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
            MockContactsRepo.DbInstance.Delete(currentContactIndex);
            gridViewDetail.Visibility = Visibility.Collapsed;
            gridViewMain.Visibility = Visibility.Visible;

        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            OpenEdit();
        }

        private void BtnBack_OnClick(object sender, RoutedEventArgs e)
        {
            gridViewDetail.Visibility = Visibility.Collapsed;
            gridViewMain.Visibility = Visibility.Visible;
        }

        private void BtnSaveChanges_OnClick(object sender, RoutedEventArgs e)
        {
            Contact currentContact = MockContactsRepo.DbInstance.Get(currentContactIndex);
            
            Contact updateContact = new Contact
            {
                Index = currentContactIndex,
                Name = TextBoxChangeName.Text,
                Address = TextBoxChangeName.Text,
                PostalCode = TextBoxChangePostalCode.Text,
                City = TextBoxChangeCity.Text,
                CareOf = TextBoxChangeCareOf.Text,
                Country = TextBoxChangeCountry.Text,
                PhoneNumber = TextBoxChangePhone.Text,
                EmailAddress = TextBoxChangeMail.Text,
                AppData = currentContact.AppData
            };

            MockContactsRepo.DbInstance.Update(updateContact);
            CloseEdit();

        }

        private void CloseEdit()
        {
            TextBoxChangeName.Visibility = Visibility.Collapsed;
            TextBoxChangeAddress.Visibility = Visibility.Collapsed;
            TextBoxChangePostalCode.Visibility = Visibility.Collapsed;
            TextBoxChangeCity.Visibility = Visibility.Collapsed;
            TextBoxChangeCareOf.Visibility = Visibility.Collapsed;
            TextBoxChangeCountry.Visibility = Visibility.Collapsed;
            TextBoxChangePhone.Visibility = Visibility.Collapsed;
            TextBoxChangeMail.Visibility = Visibility.Collapsed;
            btnSaveChanges.Visibility = Visibility.Collapsed;
            
        }

        private void OpenEdit()
        {
            TextBoxChangeName.Visibility = Visibility.Visible;
            TextBoxChangeAddress.Visibility = Visibility.Visible;
            TextBoxChangePostalCode.Visibility = Visibility.Visible;
            TextBoxChangeCity.Visibility = Visibility.Visible;
            TextBoxChangeCareOf.Visibility = Visibility.Visible;
            TextBoxChangeCountry.Visibility = Visibility.Visible;
            TextBoxChangePhone.Visibility = Visibility.Visible;
            TextBoxChangeMail.Visibility = Visibility.Visible;
            btnSaveChanges.Visibility = Visibility.Visible;
        }
    }
}
