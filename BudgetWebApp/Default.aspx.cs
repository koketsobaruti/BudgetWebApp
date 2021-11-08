using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BudgetWebApp.Classes;

namespace BudgetWebApp
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            errLabel.Visible = false;
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string hash = Calculations.HashClass.GetHash(txtPass.Text);
            string username = txtUsername.Text;

            
            //create a task to search for the username in the database
            Task<bool> taskFindUsername = new Task<bool>(() => CheckUsername(username));
            taskFindUsername.Start();
            bool found = taskFindUsername.Result;

            //task to find out if the account exists
            Task<bool> findAccount = new Task<bool>(()=>CheckAccount(username,hash));
            findAccount.Start();
            bool accFound = findAccount.Result;

            //checks if the input is valid while processing to find out if the username exists
            if (!found)
            {
                errLabel.Visible = true;
                errLabel.Text = "The username you have entered does not exist.";
            }
            else if (!accFound)
            {
                errLabel.Visible = true;
                errLabel.Text = "Enter the correct username/password.";
            }
            else
            {
                Session["username"] = txtUsername.Text;
                Response.Redirect("Homepage.aspx");
            }
        }

        //method used to find out if the user exists
        private bool CheckUsername(string user)
        {
            bool found = UserDB.FindUsername(user);
            Console.WriteLine("found state " + found);
            return found;
        }

        //method to find out if the account exists
        private bool CheckAccount(string username, string hashPassword)
        {
            bool accFound = UserDB.FindAccount(username, hashPassword);
            return accFound;
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            Response.Redirect("Register.aspx");
        }
    }

}