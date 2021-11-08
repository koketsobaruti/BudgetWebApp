using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.WebPages;
using BudgetWebApp.Classes;
using static BudgetWebApp.Classes.UserDB;

namespace BudgetWebApp
{
    public partial class Register : System.Web.UI.Page
    {
        private UserClass uc;
        protected void Page_Load(object sender, EventArgs e)
        {
            takenLabel.Visible = false;
        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            if ((!txtName.Text.IsEmpty()) && (!txtSurname.Text.IsEmpty()) &&
                (!txtUsername.Text.IsEmpty())
                && (!txtPassword.Text.IsEmpty()) && (!txtCompare.Text.IsEmpty()))
            {
                //create a task to search for the username in the database
                Task<bool> taskFindUsername = new Task<bool>(() => CheckUsername(txtUsername.Text));
                taskFindUsername.Start();
                bool found = taskFindUsername.Result;

                if (txtPassword.Text.Equals(txtCompare.Text))
                {
                    Task<string> passTask = new Task<string>(()=> GetHash(txtCompare.Text));
                    passTask.Start();

                    //passTask.Wait();
                    if (!found)
                    {
                        string name = txtUsername.Text;
                        //waits for the application to get the password value 
                        var hashPass = Calculations.HashClass.GetHash(txtCompare.Text);
                        uc =new UserClass()
                        {
                            Name = txtName.Text,
                            Surname = txtSurname.Text,
                            Username = txtUsername.Text,
                            Password = hashPass
                        };
                        //begin a thread to add a usr ot the database
                        Thread writeThread = new Thread(AddUser);
                        writeThread.Start();

                        Session["username"] = name;
                        Response.Redirect("AddGeneralExpenses.aspx");
                        
                    }else{ takenLabel.Visible = true; }
                }
            }
        }

        //method to get the password hash
        public string GetHash(string pass)
        {
            string hashPass = Calculations.HashClass.GetHash(pass);
            return hashPass;
        }

        //method to check if the username exists
        private bool CheckUsername(string user)
        {
            bool found = UserDB.FindUsername(user);
            //Console.WriteLine("found state " + found);
            return found;
        }

        //method to add a new user
        public void AddUser()
        {
            UserDB.AddUser(uc);
        }
        protected void btnReturn_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }
    }
}