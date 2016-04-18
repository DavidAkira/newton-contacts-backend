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
                AppData = "http://images.fun.com/products/20244/1-1/spider-man-masks-pack-of-8.jpg"

            };
            int returnedId = MockContactsRepo.DbInstance.Create(newContact);
            txtReturnedvalue.Text = returnedId.ToString();
        }
    }
}
