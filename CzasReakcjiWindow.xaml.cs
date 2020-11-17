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
        public CzasReakcjiWindow()
        {
            InitializeComponent();
        }

        private void ReactionButton_Click(object sender, RoutedEventArgs e)
        {
            if (stopwatch.IsRunning)
            {
                stopwatch.Stop();
                timesTested.Add(stopwatch.ElapsedMilliseconds);
                ReactionButton.Background = Brushes.Red;
                ReactionButton.Content = string.Format("Twój czas to {0} millisekund",
                                                       timesTested[timesTested.Count - 1]);
                if (timesTested.Count == 3)
                {
                    MessageBox.Show("Osiągnąłeś czasy: " + String.Join(", ", timesTested.ToArray()));
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
            ReactionButton.Background = Brushes.Green;
            ReactionButton.Content = "WCISNIJ TERAZ";
        }
    }
}
