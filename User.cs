using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace LogicGame
{
    public class User
    {
        public int Id;
        public string UserName;
        public string Password;
        public User(int Id, string login, string password)
        {
            this.Id = Id;
            this.UserName = login;
            this.Password = password;
        }
        public bool checkPassword(string Password)
        {
            byte[] salat = Encoding.ASCII.GetBytes(Id + "LogicGames");
            Rfc2898DeriveBytes pdkdf2 = new Rfc2898DeriveBytes(Password, salat);
            Password = Encoding.ASCII.GetString(pdkdf2.GetBytes(20));
            if (this.Password == Password) return true;
            else return false;
        }
    }
}
