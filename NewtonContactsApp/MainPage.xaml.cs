using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Core;
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

        }

        //private void BtnBack_OnClick(object sender, RoutedEventArgs e)
        //{
        //    if (frameMain.CanGoBack)
        //    {
        //        frameMain.GoBack();
        //    }
        //}

        private void ListBoxMenu_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ListBoxItem1.IsSelected)
            {
                frameMain.Navigate(typeof(GridViewPage));
            }
            else if (ListBoxItem2.IsSelected)
            {
                frameMain.Navigate(typeof(ListViewPage));
                
            }
            else if (ListBoxItem3.IsSelected)
            {
                frameMain.Navigate(typeof(AddNewContactPage));
            }
        }
    }
}
