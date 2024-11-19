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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace WINDOWS
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class home : Page
    {
        public home()
        {
            this.InitializeComponent();
        }

        private void Onnavigation_selected(NavigationView sender, NavigationViewSelectionChangedEventArgs args)
        {
            if (args.IsSettingsSelected)
            {
                ContentFrame.Navigate(typeof(MARINE));
            }
            else if (args.SelectedItem is NavigationViewItem selectedItem)
            {

                string declaration = selectedItem.Content.ToString();

                switch (declaration)
                {

                    case "MAMMALS":
                        ContentFrame.Navigate(typeof(MAMMALS));
                        break;
                    case "BIRDS":
                        ContentFrame.Navigate(typeof(BIRDS));
                        break;
                    case "REPTILES":
                        ContentFrame.Navigate(typeof(REPTILES));
                        break;
                    case "MARINE LIFE":
                        ContentFrame.Navigate(typeof(MARINE));
                        break;

                    default:
                        break;
                }



            }
        }
    }
}
