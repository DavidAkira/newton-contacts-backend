using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel.Activation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Graphics.Imaging;
using Windows.Networking.Sockets;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.Storage.Streams;
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
    public sealed partial class AddNewContactPage : Page
    {
        public StorageFile ImageFile { get; set; }
        public AddNewContactPage()
        {
            this.InitializeComponent();
        }
        private void BtnClear_OnClick(object sender, RoutedEventArgs e)
        {
            txtboxAdress.Text = "";
            txtboxCareOf.Text = "";
            txtboxCity.Text = "";
            txtboxCountry.Text = "";
            txtboxMail.Text = "";
            txtboxName.Text = "";
            txtboxPhone.Text = "";
            txtboxPostalCode.Text = "";
        }

        private void BtnAddNewPerson_OnClick(object sender, RoutedEventArgs e)
        {
            Contact newContact = new Contact
            {
                Name = txtboxName.Text,
                Address = txtboxAdress.Text,
                CareOf = txtboxCareOf.Text,
                City = txtboxCity.Text,
                Country = txtboxCountry.Text,
                EmailAddress = txtboxMail.Text,
                PhoneNumber = txtboxPhone.Text,
                PostalCode = txtboxPostalCode.Text,
                AppData = "ms-appx://NewtonContactsApp/Assets/default.jpg"
            };      
            MockContactsRepo.DbInstance.Create(newContact);
        }

        private async void BtnAddPicture_OnClick(object sender, RoutedEventArgs e)
        {
            FileOpenPicker opener = new FileOpenPicker();
            opener.ViewMode = PickerViewMode.Thumbnail;
            opener.SuggestedStartLocation = PickerLocationId.PicturesLibrary;
            opener.CommitButtonText = "Select a picture";
            opener.FileTypeFilter.Add(".jpg");
            opener.FileTypeFilter.Add(".png");
            StorageFile file = await opener.PickSingleFileAsync();
            if (file != null)
            {
                await file.CopyAsync(ApplicationData.Current.LocalFolder, file.Name, NameCollisionOption.GenerateUniqueName);
                var stream = await file.OpenAsync(FileAccessMode.Read);
                var bitmapImage = new BitmapImage();
                await bitmapImage.SetSourceAsync(stream);     

                imgDisplay.Source = bitmapImage;
                //addImage = bitmapImage;
                //txtDisplay.Text = bitmapImage.UriSource.ToString();  
            }
        }


    }
}
