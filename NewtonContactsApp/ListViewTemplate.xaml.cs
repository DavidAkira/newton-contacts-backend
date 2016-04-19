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

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace NewtonContactsApp
{
    public sealed partial class ListViewTemplate : UserControl
    {
        public Contact Contact { get { return this.DataContext as Contact; } }
        public ListViewTemplate()
        {
            this.InitializeComponent();
            this.DataContextChanged += (s, e) => Bindings.Update();
        }
    }
}
