using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
namespace LogicGame
{ 
    class User
    {
        public void updateDateBase(string nazwa, int punkty, string gra)
        {
            string czyJestWBazie = "";
            string connectionString = "server=logicgames.j.pl;uid=LogicGames;pwd=Log!cGame5;database=screpcik";
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();
            MySqlCommand cmd = connection.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT COUNT(*) FROM ranking WHERE (Nick = '@param1' AND Gra = '@param2')";
            cmd.Parameters.AddWithValue("@param1", nazwa);
            cmd.Parameters.AddWithValue("@param2", gra);
            MySqlDataReader dr = cmd.ExecuteReader();
            //int czyJestWBazie = int.Parse(dt.Rows[0].Field<string>(0));
            // Console.WriteLine(czyJestWBazie);
            while (dr.Read())
            {
                string chuj = dr[0].ToString();
                Console.WriteLine(chuj);
            }
            if (czyJestWBazie == "-1") //Jeśli nie ma takiego usera.
            {
                MySqlCommand addUserAndPoints = new MySqlCommand("INSERT INTO ranking(Nick, Punkty, Gra) VALUES(@param1, @param2, @param3)", connection);
                addUserAndPoints.Parameters.AddWithValue("@param1", nazwa);
                addUserAndPoints.Parameters.AddWithValue("@param2", punkty);
                addUserAndPoints.Parameters.AddWithValue("@param3", gra);
                addUserAndPoints.ExecuteNonQuery();
                connection.Close();
            }
            else                    // jesli jest
            {
                MySqlCommand updateUsersPoints = new MySqlCommand("");
            }
        }
    }
}
