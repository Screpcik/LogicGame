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
using System.Diagnostics;

namespace LogicGame
{
    /// <summary>
    /// Logika interakcji dla klasy CzasReakcjiWindow.xaml
    /// </summary>
    public partial class CzasReakcjiWindow : Window
    {
        List<long> timesTested = new List<long>();
        Random random = new Random();
        Stopwatch stopwatch = new Stopwatch();
        string nazwa;
        public CzasReakcjiWindow(string nick)
        {
            nazwa = nick;
            InitializeComponent();
        }

        private void ReactionButton_Click(object sender, RoutedEventArgs e)
        {
            if (stopwatch.IsRunning)
            {
                stopwatch.Stop();
                timesTested.Add(stopwatch.ElapsedMilliseconds);
                ReactionButton.Background = Brushes.Red;
                ReactionButton.Content = "próba " + timesTested.Count.ToString()+" z 3.";
                TimeLabel.Content = string.Format("{0} ms.", timesTested[timesTested.Count - 1]);
                if (timesTested.Count == 3)
                {
                    int suma = Convert.ToInt32(timesTested[0]) + Convert.ToInt32(timesTested[1]) + Convert.ToInt32(timesTested[2]);
                    int wynik = suma / 3;
                    User user = new User();
                    try
                    {
                        user.updateDateBase(nazwa, wynik, "Czas Reakcji");
                    }
                    catch
                    {
                        MessageBox.Show("Prawdopodobny brak połączenia z internetem.");
                    }
                    TimeLabel.Content = "Osiągnąłeś czasy: " + String.Join(", ", timesTested.ToArray());
                    Task.Delay(2000);
                    MenuWindow oknoPoZalogowaniu = new MenuWindow(nazwa);
                    oknoPoZalogowaniu.Show();
                    this.Close();
                }
            }
        }

        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            stopwatch.Reset();
            for (int i = 4; i > 0; --i)
            {
                ReactionButton.Content = i.ToString();
                Task.Delay(500).Wait();
                ReactionButton.IsEnabled = true;
            }
            ReactionButton.Content = "Wcisnij jak najszybciej gdy zrobi sie zielony";
            Task.Delay(random.Next(3000, 5000)).Wait();
            stopwatch.Start();
            ReactionButton.Background = Brushes.DodgerBlue;
            ReactionButton.Content = "WCISNIJ TERAZ";
        }
    }
}
