using System;
using System.Windows;
using System.Windows.Input;
using System.Text.RegularExpressions;
using System.Windows.Threading;
namespace LogicGame
{
    /// <summary>
    /// Logika interakcji dla klasy DzialaniaMatematyczneWindow.xaml
    /// </summary>
    public partial class DzialaniaMatematyczneWindow : Window
    {
        bool IsStopped = false;
        int Timeleft;
        int FirstNumber;
        int SecondNumber;
        int wynikPunktowy;
        int wynik;
        Random rnd = new Random();
        DispatcherTimer timer = new DispatcherTimer();
        public DzialaniaMatematyczneWindow()
        {
            InitializeComponent();
        }
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
        private void ResultTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter && !IsStopped)
            {
                if (int.Parse(ResultTextBox.Text) == wynik)
                {
                    ResultTextBox.Text = "";
                    wynikPunktowy++;
                    WynikLabel.Content = wynikPunktowy.ToString();
                    randomize();
                    AnswerLabel.Content = "Brawo dobra odpowiedz";
                }
                else AnswerLabel.Content = "Niestety spróbuj ponownie";
            }
        }
        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            Timeleft = 30;          
            randomize();
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += timer_Tick;
            timer.Start();
            TimeleftLabel.Content = "Pozostało "+ Timeleft +"s.";
        }
        void timer_Tick(object sender, EventArgs e)
        {
            if (Timeleft > 0)
            {
                TimeleftLabel.Content = "Pozostało " + Timeleft + "s.";
                Timeleft--;
            }
            else
            {
                IsStopped = true;
                FirstNumber = -123;
                SecondNumber = -122;
                ResultTextBox.Text = "";
                TimeleftLabel.Content = "Koniec Gry. Uzyskałeś " + wynikPunktowy + " punktów.";
            }           
        }
        void randomize()
        {
            FirstNumber = rnd.Next(0, 100);
            SecondNumber = rnd.Next(0, 100);
            wynik = FirstNumber + SecondNumber;
            FirstNumberLabel.Content = FirstNumber.ToString();
            SecondNumberLabel.Content = SecondNumber.ToString();
            SymbolLabel.Content = "+";
            
        }
    }
}
