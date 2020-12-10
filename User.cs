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
            string connectionString = "server=***;uid=LogicGames;pwd=***;database=screpcik";
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();
            MySqlCommand cmd = connection.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT COUNT(*) FROM ranking WHERE (Nick = '"+ nazwa +  "' AND Gra = '" + gra + "')";
            int UserExist = Convert.ToInt32(cmd.ExecuteScalar());
            if (UserExist > 0)
            {
                Console.WriteLine("Record exists");
                MySqlCommand updateUser = connection.CreateCommand();
                updateUser.CommandType = CommandType.Text;
                updateUser.CommandText = "UPDATE ranking " +
                                         "SET Punkty="+ punkty +
                                         " WHERE (Nick = '" + nazwa + "' AND Gra = '" + gra + "')";
                updateUser.ExecuteNonQuery();

            }
            else
            {
                Console.WriteLine("Record does not exist");
                MySqlCommand addUser = connection.CreateCommand();
                addUser.CommandType = CommandType.Text;
                addUser.CommandText = "INSERT INTO ranking " +
                                      "VALUES ('" + nazwa + "','" + punkty + "','" + gra + "')";
                addUser.ExecuteNonQuery();
            }
        }
    }
}
