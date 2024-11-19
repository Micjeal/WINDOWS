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
    public sealed partial class MAMMALS : Page
    {
        private List<mammalDB> questions;
        private int currentquestionindex = 0;
        private int score = 0;

        private DispatcherTimer timer;
        private int timeleft;

        public async void showMessage(string title, string message)
        {
            var dialog = new ContentDialog()
            {
                Title = title, //this helps us to set a different title on every popup dialog message.
                Content = message,
                CloseButtonText = "CLOSE",
            };
            await dialog.ShowAsync();
        }

        public MAMMALS()
        {
            this.InitializeComponent();
            loadthequestion();
            setthequestion();
        }

        private void setthequestion()
        {
            //reset the radio buttons for better display.
            option1.IsChecked = false;
            option2.IsChecked = false;
            option3.IsChecked = false;
            option4.IsChecked = false;

            if (currentquestionindex < questions.Count)
            {
                var current = questions[currentquestionindex];
                Qtntxt.Text = current.questions;
                option1.Content = current.option1;
                option2.Content = current.option2;
                option3.Content = current.option3;
                option4.Content = current.option4;

                timeleft = 10;
                timerbx.Text = timeleft.ToString();
                timer = new DispatcherTimer();
                timer.Interval = TimeSpan.FromSeconds(1);
                timer.Tick += TimerTick;
                timer.Start();
            }
            else
            {
                Qtntxt.Text = "End of Quiz";
                option1.IsEnabled = false;
                option2.IsEnabled = false;
                option3.IsEnabled = false;
                option4.IsEnabled = false;
                showMessage("Quiz Complete", $"Your Score: {score} / {questions.Count}");
            }
        }

        private void TimerTick(object sender, object e)
        {
            timeleft--;
            timerbx.Text = timeleft.ToString();
            if (timeleft <= 0)
            {
                timer.Stop();
                currentquestionindex++;
                setthequestion();
            }
        }

        private void loadthequestion()
        {
            questions = new List<mammalDB>
            {
                new mammalDB
                {
                    questions = "what is the largest land animal",
                    option1 = "ELEPHANT",
                    option2 = "LION",
                    option3 = "GIRAFFE",
                    option4 = "BEAR",
                    correctAns = 1
                },
                new mammalDB
                {
                    questions = "what mammal is known for its ability to fly?",
                    option1 = "EAGLE",
                    option2 = "KANGAROO",
                    option3 = "SQUIRREL",
                    option4 = "BAT",
                    correctAns = 4
                },
                new mammalDB
                {
                    questions = "what is the king of the jungle?",
                    option1 = "LEOPARD",
                    option2 = "LION",
                    option3 = "TIGER",
                    option4 = "CHEETAH",
                    correctAns = 2
                },
                new mammalDB
                {
                    questions = "which animal has the longest neck?",
                    option1 = "ELEPHANT",
                    option2 = "CAMEL",
                    option3 = "GIRAFFE",
                    option4 = "HORSE",
                    correctAns = 3
                }
            };
        }

        private void OptionChecked(object sender, RoutedEventArgs e)
        {
            var selectedOption = -1;
            if (option1.IsChecked == true)
                selectedOption = 1;
            else if (option2.IsChecked == true)
                selectedOption = 2;
            else if (option3.IsChecked == true)
                selectedOption = 3;
            else if (option4.IsChecked == true)
                selectedOption = 4;

            var current = questions[currentquestionindex];
            if (selectedOption == current.correctAns)
            {
                score++;
                txtresult.Text = "Correct.";
                txtresult.Foreground = new SolidColorBrush(Windows.UI.Colors.Green);
            }
            else
            {
                txtresult.Text = "Wrong answer.";
                txtresult.Foreground = new SolidColorBrush(Windows.UI.Colors.Red);
            }

            timer.Stop();
            currentquestionindex++;
            setthequestion();
        }
    }
}
