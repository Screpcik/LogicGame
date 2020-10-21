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

namespace LogicGame
{
    /// <summary>
    /// Logika interakcji dla klasy MenuWindow.xaml
    /// </summary>
    /// 1 - Działania Matematyczne
    /// 2 - Zapamiętywanie
    /// 3 - było nie było
    /// 4 - czas reakcji
    /// 5 - Zapamiętaj Numer
    /// 6 - Od najmniejszego
    /// 7 - Alfabet
    /// 8 - Ranking
    public partial class MenuWindow : Window
    {
        string login;
        int buttonNumber;
        public MenuWindow(string login)
        {
            this.login = login;
            InitializeComponent();
            LoggedAsLabel.Content = "Zalogowano jako " + login;
        }
        void ChooseGame(int button)
        {
            switch (button)
            {
                case 1:
                    DzialaniaMatematyczneWindow dzialaniaMatematyczneWindow = new DzialaniaMatematyczneWindow();
                    dzialaniaMatematyczneWindow.Show();
    
                    break;

                case 2:
                    ZapamietywanieWindow zapamietywanieWindow = new ZapamietywanieWindow();
                    zapamietywanieWindow.Show();
                    break;

                case 3:
                    ByloNieByloWindow byloNieByloWindow = new ByloNieByloWindow();
                    byloNieByloWindow.Show();
                    break;

                case 4:
                    CzasReakcjiWindow czasReakcjiWindow = new CzasReakcjiWindow();
                    czasReakcjiWindow.Show();
                    break;

                case 5:
                    ZapamietajNumerWindow zapamietajNumerWindow = new ZapamietajNumerWindow();
                    zapamietajNumerWindow.Show();
                    break;

                case 6:
                    OdNajmniejszego odNajmniejszego = new OdNajmniejszego();
                    odNajmniejszego.Show();
                    break;

                case 7:
                    AlfabetWindow alfabetWindow = new AlfabetWindow();
                    alfabetWindow.Show();
                    break;

                case 8:
                    RankingWindow rankingWindow = new RankingWindow();
                    rankingWindow.Show();
                    break;

            }
                
        }

        private void DzialaniaMatematyczneButton_Click(object sender, RoutedEventArgs e)
        {
            ChooseGame(1);
            this.Close();
        }

        private void ZapamietywanieButton_Click(object sender, RoutedEventArgs e)
        {
            ChooseGame(2);
            this.Close();
        }

        private void ByloNieByloButton_Click(object sender, RoutedEventArgs e)
        {
            ChooseGame(3);
            this.Close();
        }

        private void CzasReakcjiButton_Click(object sender, RoutedEventArgs e)
        {
            ChooseGame(4);
            this.Close();
        }

        private void ZapamietajNumerButton_Click(object sender, RoutedEventArgs e)
        {
            ChooseGame(5);
            this.Close();
        }

        private void OdNajmniejszegoButton_Click(object sender, RoutedEventArgs e)
        {
            ChooseGame(6);
            this.Close();
        }

        private void AlfabetButton_Click(object sender, RoutedEventArgs e)
        {
            ChooseGame(7);
            this.Close();
        }

        private void RankButton_Click(object sender, RoutedEventArgs e)
        {
            ChooseGame(8);
            this.Close();
        }
    }
}
