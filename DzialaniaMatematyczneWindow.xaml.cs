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
using System.Text.RegularExpressions;

namespace LogicGame
{
    /// <summary>
    /// Logika interakcji dla klasy DzialaniaMatematyczneWindow.xaml
    /// </summary>
    public partial class DzialaniaMatematyczneWindow : Window
    {
        int FirstNumber;
        int SecondNumber;
        string Symbol = "+";
        int wynikPunktowy;
        int wynik;
        Random rnd = new Random();

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
            if (e.Key == Key.Enter)
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
            randomize();
        }
        void randomize()
        {
            FirstNumber = rnd.Next(0, 100);
            SecondNumber = rnd.Next(0, 100);
            wynik = FirstNumber + SecondNumber;
            FirstNumberLabel.Content = FirstNumber.ToString();
            SecondNumberLabel.Content = SecondNumber.ToString();
            SymbolLabel.Content = Symbol;
        }
    }
}
