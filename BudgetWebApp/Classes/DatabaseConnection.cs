using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace BudgetWebApp.Classes
{
    public class DatabaseConnection 
    {
        public static string GetConnection()
        {
            var connectionFromWebConfiguration = WebConfigurationManager.ConnectionStrings["DBConnection"]; 
            string conn = connectionFromWebConfiguration.ConnectionString;
            return conn;
        }
    }

   
}