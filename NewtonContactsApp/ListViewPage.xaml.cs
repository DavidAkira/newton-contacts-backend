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
        private int CurrentContactIndex { get; set; }
        public ListViewPage()
        {
            this.InitializeComponent();
            if (MainPage.FilteredContacts == null)
            {
                Contacts = MockContactsRepo.DbInstance.GetAll();                
            }
            else
            {
                Contacts = MainPage.FilteredContacts;
            }
        }

        private void ListViewMaster_OnItemClick(object sender, ItemClickEventArgs e)
        {
            Contact clickedContact = (Contact)e.ClickedItem;
            CurrentContactIndex = clickedContact.Index;

            gridDetail.Visibility = Visibility.Visible;
            if (VisualStateGroup.CurrentState == Mobile)
            {
                listViewMaster.Visibility = Visibility.Collapsed;
                gridDetail.Visibility = Visibility.Visible;
            }

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
            CloseEdit();
        }

        private void BtnBack_OnClick(object sender, RoutedEventArgs e)
        {
            gridDetail.Visibility = Visibility.Collapsed;
            listViewMaster.Visibility = Visibility.Visible;
            CloseEdit();
        }

        private void ListViewPage_OnLoaded(object sender, RoutedEventArgs e)
        {
            listViewMaster.Visibility = Visibility.Visible;
            gridDetail.Visibility = Visibility.Collapsed;
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            Contact currentContact = MockContactsRepo.DbInstance.Get(CurrentContactIndex);
            OpenEdit();
            TextBoxChangeName.Text = currentContact.Name;
            TextBoxChangeAddress.Text = currentContact.Address;
            TextBoxChangeCity.Text = currentContact.City;
            TextBoxChangePostalCode.Text = currentContact.PostalCode;
            TextBoxChangeCareOf.Text = currentContact.CareOf;
            TextBoxChangeMail.Text = currentContact.EmailAddress;
            TextBoxChangePhone.Text = currentContact.PhoneNumber;
            TextBoxChangeCountry.Text = currentContact.Country;
        }

        private void btnRemove_Click(object sender, RoutedEventArgs e)
        {
            
            MockContactsRepo.DbInstance.Delete(CurrentContactIndex);
            gridDetail.Visibility = Visibility.Collapsed;
            listViewMaster.Visibility = Visibility.Visible;
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
        private void UpdateUserTextboxes()
        {
            Contact updatedUser = MockContactsRepo.DbInstance.Get(CurrentContactIndex);
            txtblockDetailName.Text = updatedUser.Name;
            txtblockDetailAddress.Text = updatedUser.Address;
            txtblockDetailCareOf.Text = updatedUser.CareOf;
            txtblockDetailCity.Text = updatedUser.City;
            txtblockDetailPostalCode.Text = updatedUser.PostalCode;
            txtblockDetailCountry.Text = updatedUser.Country;
            txtblockDetailMail.Text = updatedUser.EmailAddress;
            txtblockDetailPhone.Text = updatedUser.PhoneNumber;
        }

        private void BtnSaveChanges_OnClick(object sender, RoutedEventArgs e)
        {
            Contact currentContact = MockContactsRepo.DbInstance.Get(CurrentContactIndex);
            Contact updatedContact = new Contact
            {
                Index = CurrentContactIndex,
                Name = TextBoxChangeName.Text,
                Address = TextBoxChangeAddress.Text,
                PostalCode = TextBoxChangePostalCode.Text,
                City = TextBoxChangeCity.Text,
                CareOf = TextBoxChangeCareOf.Text,
                Country = TextBoxChangeCountry.Text,
                PhoneNumber = TextBoxChangePhone.Text,
                EmailAddress = TextBoxChangeMail.Text,
                AppData = currentContact.AppData
            };
            MockContactsRepo.DbInstance.Update(updatedContact);
            UpdateUserTextboxes(); //Re-adding the data so the information gets refreshed
            CloseEdit();
        }
    }
}
