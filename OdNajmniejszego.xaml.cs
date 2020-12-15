using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;
using System.Text.RegularExpressions;

namespace LogicGame
{
    /// <summary>
    /// Logika interakcji dla klasy OdNajmniejszego.xaml
    /// </summary>
    public partial class OdNajmniejszego : Window
    {
        int timeelapsed = 0;
        int liczba;
        int licznik = 0;
        DispatcherTimer timer = new DispatcherTimer();
        Random rnd = new Random();
        string nazwa;
        List<int> liczby = new List<int>();
        public OdNajmniejszego(string nick)
        {
            nazwa = nick;
            InitializeComponent();
        }
        void randomize()
        {
            for (int i = 0; i < 15; i++)
            {
                liczba = rnd.Next(0, 100);
                liczby.Add(liczba);
                NumbersLabel.Text += liczba.ToString() + ", ";
                liczby.Sort();
            }
        }

        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            timeelapsed = 0;
            AnswerTextBox.Text = "";
            randomize();
            AnswerTextBox.IsEnabled = true;
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += timer_Tick;
            timer.Start();
        }
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
        public void timer_Tick(object sender, EventArgs e)
        {
            timeelapsed++;
        }

        private void AnswerTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                check();
                AnswerTextBox.Text = "";              
            }
        }
        
        public bool check()
        {
            if (AnswerTextBox.Text == liczby[licznik].ToString())
            {
                JustLabel.Content = "Dobrych odpowiedzi " + (licznik + 1);
                licznik++;
                if(licznik == 15)
                {
                    JustLabel.Content = "Brawo wygrałeś zajęło Ci to:";
                    NumbersLabel.Text = timeelapsed.ToString() + ".0 sekundy.";
                    liczby.Clear();
                    AnswerTextBox.IsEnabled = false;
                    User user = new User();
                    try
                    {
                        user.updateDateBase(nazwa, timeelapsed, "Od Najmniejszego");
                    }
                    catch
                    {
                        MessageBox.Show("Prawdopodobny brak połączenia z internetem.");
                    }
                    timer.Stop();
                    Task.Delay(2000);
                    MenuWindow oknoPoZalogowaniu = new MenuWindow(nazwa);
                    oknoPoZalogowaniu.Show();
                    this.Close();

                }
                return true;
            }
            else
            {
                JustLabel.Content = "Wprowadziles zla liczbe";
                return false;
            }
        }
    }
}
