using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BudgetWebApp
{
    public class UserClass
    {

        public string Name { get; set; }
        public string Surname { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public UserClass()
        {
                
        }
        public UserClass(string name, string surname, string username, string password)
        {
            Name = name;
            Surname = surname;
            Username = username;
            Password = password;
        }
    }
}