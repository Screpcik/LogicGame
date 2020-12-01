using System;
using System.Windows;
using System.Windows.Input;
using System.Text.RegularExpressions;
using System.Windows.Threading;

namespace LogicGame
{
    /// <summary>
    /// Logika interakcji dla klasy ZapamietajNumerWindow.xaml
    /// </summary>
    ///        timer.Interval = TimeSpan.FromSeconds(1);
    ///        timer.Tick += timer_Tick;
    ///        timer.Start();
    public partial class ZapamietajNumerWindow : Window
    {
        string liczba;
        int pliczba;
        int LabelTime = 1;
        int wynik;
        Random rnd = new Random();
        DispatcherTimer timer = new DispatcherTimer();
        public ZapamietajNumerWindow()
        {
            InitializeComponent();
        }
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            Generate();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += timer_Tick;
        }
        void Generate()
        {
            timer.Start();
            AnswerTextBox.Text = "";
            pliczba = rnd.Next(0, 10);
            liczba = liczba + pliczba.ToString();
            LiczbaLabel.Content = liczba;
        }
        void timer_Tick(object sender, EventArgs e)
        {
            if(LabelTime % 4 != 0 )
            {              
                LabelTime++;
            }
            if (LabelTime % 4 == 0)
            {
                timer.Stop();
                AnswerTextBox.IsEnabled = true;
                LiczbaLabel.Content = "Wpisz liczbę poniżej";
            }

        }

        private void AnswerTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                AnswerTextBox.IsEnabled = false;
                if (AnswerTextBox.Text == liczba)
                {
                    LabelTime = 1;
                    Generate();
                }
                else
                {
                    wynik = liczba.Length;
                    LiczbaLabel.Content = "Przegrałeś twój wynik to " + wynik;
                }
            }

        }
    }
}
