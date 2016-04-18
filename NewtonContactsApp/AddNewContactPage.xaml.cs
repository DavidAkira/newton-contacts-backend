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
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace NewtonContactsApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AddNewContactPage : Page
    {
        MockContactsRepo Repo { get; set; }
        public AddNewContactPage()
        {
            this.InitializeComponent();
            Repo = new MockContactsRepo();
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

        private void btnAddNewPerson_Click(object sender, RoutedEventArgs e)
        {
            Repo.Create(new Contact {
                Name = txtboxName.Text,
                Address = txtboxAdress.Text,
                City = txtboxCity.Text,
                Country = txtboxCountry.Text,
                CareOf = txtboxCareOf.Text,
                PostalCode = txtboxPostalCode.Text,
                PhoneNumber = txtboxPhone.Text,
                EmailAddress = txtboxPhone.Text,
            });
        }
    }
}
