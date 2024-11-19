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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace WINDOWS
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public async void showMessage(string title, string message)
        {
            var dialog = new ContentDialog()
            {
                Title = title,//this helps us to set a diffenert title on every popup dialog message.
                Content = message,
                CloseButtonText = "CLOSE",

            };
            await dialog.ShowAsync();
        }
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void loginBtn(object sender, RoutedEventArgs e)
        {
            string name = usertbx.Text;
            if (usertbx.Text == "" && pass.Password == "")
            {


                showMessage("LOGIN TEXT", "FILL ALL THE BLANK AREAS");
                return;
            }
            else if (usertbx.Text == "")
            {
                showMessage("LOGIN TEXT", "FILL ALL THE BLANK AREAS");
                return;
            }
            else if (pass.Password == "")
            {
                showMessage("LOGIN PASSWORD", " No password");
                return;
            }
            
            else if (usertbx.Text == "STUDENT" && pass.Password == "12345")

            {
                Frame.Navigate(typeof(home));
                showMessage("WELCOME", "WELCOME");
                return;
            }
            else if(usertbx.Text == "" && pass.Password == "")
                {
                showMessage("WELCOME", "LOGIN UNSUCCESSFULL");
                }
            else
            {
                showMessage("WELCOME", "LOGIN SUCCESSFULL");
            }
        }
    }
}
