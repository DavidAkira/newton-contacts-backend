using System;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Imaging;
using NewtonContactsApp.Model;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace NewtonContactsApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AddNewContactPage : Page
    {
        public string ImageFilePath { get; set; }
        public string ContactPhoto { get; set; }
        public AddNewContactPage()
        {
            this.InitializeComponent();
        }
        private void BtnClear_OnClick(object sender, RoutedEventArgs e)
        {
            ClearAll();
        }

        private void BtnAddNewPerson_OnClick(object sender, RoutedEventArgs e)
        {
            if (ImageFilePath != null)
            {
                ContactPhoto = ImageFilePath;
            }
            else
            {
                ContactPhoto = "ms-appx://NewtonContactsApp/Assets/default.jpg";
            }
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
                AppData = ContactPhoto
            };      
            MockContactsRepo.DbInstance.Create(newContact);
            ClearAll();
        }

        private async void BtnAddPicture_OnClick(object sender, RoutedEventArgs e)
        {
            //Copying a image from harddrive to a local storage and then sending the filepath of that image and adding it to a new contact.
            FileOpenPicker opener = new FileOpenPicker();
            opener.ViewMode = PickerViewMode.Thumbnail;
            opener.SuggestedStartLocation = PickerLocationId.PicturesLibrary;
            opener.CommitButtonText = "Select a picture";
            opener.FileTypeFilter.Add(".jpg");
            opener.FileTypeFilter.Add(".png");
            StorageFile file = await opener.PickSingleFileAsync();
            if (file != null)
            {
                var newFile = await file.CopyAsync(ApplicationData.Current.LocalFolder, file.Name, NameCollisionOption.GenerateUniqueName);
                var stream = await newFile.OpenAsync(FileAccessMode.Read);
                var bitmapImage = new BitmapImage();
                await bitmapImage.SetSourceAsync(stream);     
                var uri = new Uri((newFile.Path),UriKind.Absolute);
                imgDisplay.Source = new BitmapImage(uri);
                ImageFilePath = newFile.Path;
            }
        }

        private void ClearAll()
        {
            imgDisplay.Source = null;
            ImageFilePath = null;
            txtboxAdress.Text = "";
            txtboxCareOf.Text = "";
            txtboxCity.Text = "";
            txtboxCountry.Text = "";
            txtboxMail.Text = "";
            txtboxName.Text = "";
            txtboxPhone.Text = "";
            txtboxPostalCode.Text = "";
        }


    }
}
