using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
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
    /// Logika interakcji dla klasy ByloNieByloWindow.xaml
    /// </summary>
    public partial class ByloNieByloWindow : Window
    {
        string wylosowane = "";
        int pkt = 0;
        int x;
        Random rnd = new Random();
        List<string> WylosowaneSlowa = new List<string>();
        List<string> Slowa = new List<string>();
        bool bylo = false;
        string nazwa;
        public ByloNieByloWindow(string nick)
        {
            nazwa = nick;
            InitializeComponent();
            SlowoLabel.Content = "Wcisnij start";
        }

        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            Slowa.Add("szaławiła");
            Slowa.Add("ladaco");
            Slowa.Add("wykidajło");
            Slowa.Add("basałyk");
            Slowa.Add("urwipołeć");
            Slowa.Add("melepeta");
            Slowa.Add("koafiura");
            Slowa.Add("wiktuały");
            Slowa.Add("ramota");
            Slowa.Add("humbug");
            Slowa.Add("monidło");
            Slowa.Add("blurb");
            Slowa.Add("prodiż");
            Slowa.Add("wszeteczeństwo");
            Slowa.Add("frymuśny");
            Slowa.Add("buńczuczny");
            Slowa.Add("ciekawy");
            Slowa.Add("ciekawski");
            Slowa.Add("ciekawostka");
            Slowa.Add("mały");
            Slowa.Add("mniejszy");
            Slowa.Add("malutki");
            Slowa.Add("małostkowy");
            Slowa.Add("klik");
            Slowa.Add("klikać");
            Slowa.Add("klikanie");
            Slowa.Add("klikał");
            Slowa.Add("nacisnął");
            Slowa.Add("długi");
            Slowa.Add("długa");
            Slowa.Add("długe");
            Slowa.Add("miasto");
            Slowa.Add("miasteczko");
            Slowa.Add("mieszczanin");
            Slowa.Add("wieś");
            Slowa.Add("buda");
            losuj();
        }

        private void NieByloButton_Click(object sender, RoutedEventArgs e)
        {
            check();
            if (!bylo)
            {
                pkt++;
                losuj();
            }
            else
            {
                User user = new User();
                SlowoLabel.Content = "przegrales " + pkt + " pkt.";
                user.updateDateBase(nazwa, pkt, "Bylo Nie Bylo");
                WylosowaneSlowa.Clear();
                pkt = 0;
            }
        }

        private void ByloButton_Click(object sender, RoutedEventArgs e)
        {
            check();
            if (bylo)
            {
                pkt++;
                losuj();
            }
            else
            {
                User user = new User();
                SlowoLabel.Content = "przegrales " + pkt + " pkt.";
                user.updateDateBase(nazwa, pkt, "Bylo Nie Bylo");
                WylosowaneSlowa.Clear();
                pkt = 0;
            }
            bylo = false;
        }
        void losuj()
        {
            x = rnd.Next(0, Slowa.Count - 1);
            SlowoLabel.Content = Slowa[x];
            wylosowane = Slowa[x];
        }
        void check()
        {
            for (int i = 0; i < WylosowaneSlowa.Count; i++)
            {
                if (WylosowaneSlowa[i].Contains(wylosowane))
                {
                    bylo = true;
                }
            }
            if (!WylosowaneSlowa.Contains(Slowa[x]))
            {
                WylosowaneSlowa.Add(Slowa[x]);
            }
        }
    }
 }

