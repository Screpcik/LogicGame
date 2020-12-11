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
using System.Data;
using MySql.Data.MySqlClient;

namespace LogicGame
{
    /// <summary>
    /// Logika interakcji dla klasy RankingWindow.xaml
    /// </summary>
    public partial class RankingWindow : Window
    {
        string nazwa;
        public RankingWindow(string nick)
        {
            nazwa = nick;
            string connectionString = "server=logicgames.j.pl;uid=LogicGames;pwd=Log!cGame5;database=screpcik";
            MySqlDataAdapter da = new MySqlDataAdapter("SELECT * FROM ranking", connectionString);
            DataSet ds = new DataSet();
            da.Fill(ds, "ranking");
            InitializeComponent();
            BaseDataGrid.ItemsSource= ds.Tables["ranking"].DefaultView;
        }
    }
}
