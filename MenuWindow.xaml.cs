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
    public partial class MenuWindow : Window
    {
        string login;
        int gameNumber;
        public MenuWindow(string login)
        {
            this.login = login;
            InitializeComponent();
        }
        void ChooseGame()
        {
            switch (gameNumber)
            {
                case 1:

                    break;

                case 2:

                    break;

                case 3:

                    break;

                case 4:

                    break;

                case 5:

                    break;

                case 6:

                    break;

            }
                
        }
    }
}
