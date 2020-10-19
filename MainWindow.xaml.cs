using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LogicGame
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {   
        public MainWindow()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            otworzOkno(LoginTextBox.Text);
            this.Close();
        }

        private void GuessLoginButton_Click(object sender, RoutedEventArgs e)
        {
            otworzOkno("Gość");
            this.Close();
        }
        private static void otworzOkno(string nazwa)
        {
            MenuWindow oknoPoZalogowaniu = new MenuWindow(nazwa);
            oknoPoZalogowaniu.Show();        
        }
    }
}
