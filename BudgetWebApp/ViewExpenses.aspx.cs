using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BudgetWebApp.Classes;

namespace BudgetWebApp
{
    public partial class ViewExpenses : System.Web.UI.Page
    {
        private string _username;
        private string accomodationType;
        protected void Page_Load(object sender, EventArgs e)
        {
            string g = "";
            //if (!IsPostBack)
            if (Session["username"] != null)
            {
                g = Session["username"].ToString();
            }

            username.Value = g; ;
            //task used to get the general expenses
            //T/ask<Expenses> getExpThread = new Task<Expenses>(ReturnExpenses);
            //getExpThread.Start();

            Expenses expense = new Expenses();
            expense = GeneralExpensesDb.GetExpenses(username.Value);

            //task used to find out whether the user is renting or not
            Task<string> taskFindUser = new Task<string>(FindUser);
            taskFindUser.Start();
            accomodationType = taskFindUser.Result;

            Task<bool> findVehTask = new Task<bool>(VehicleUser);
            findVehTask.Start();

            txtGroceries.Enabled = false;
            txtUtilies.Enabled = false;
            txtCommunication.Enabled = false;
            txtTravel.Enabled = false;

            txtGroceries.Text = expense.Groceries.ToString();
            txtUtilies.Text = expense.Utilities.ToString();
            txtCommunication.Text = expense.Communication.ToString();
            txtTravel.Text = expense.Travel.ToString();

            //makes the gridview invisible if the user does not have other expenses
            taskFindUser.Wait();
            if (accomodationType.Equals("house"))
            {
                GridView1.Visible = false;
            }
            else if (accomodationType.Equals("rent"))
            {
                btnHome.Enabled = false;
                btnHome.BackColor = System.Drawing.Color.LightSalmon;
            }

            //this disables the vehicle button if the user does not own one.
            bool veh = findVehTask.Result;
            if (!veh)
            {
                btnVehicle.Enabled = false;
                btnVehicle.BackColor = System.Drawing.Color.PaleGreen;
            }
            

        }

        public Expenses ReturnExpenses()
        {
            Expenses exp = new Expenses();
            exp = GeneralExpensesDb.GetExpenses(username.Value);
            return exp;
        }

        public string FindUser()
        {
            string acc="";
            bool rentalUser = RentalDB.FindRentalUser(username.Value);
            bool houseUser = HomeLoanDb.FindHouseUser(username.Value);

            if (rentalUser)
                acc = "rent";
            else if (houseUser)
                acc = "house";

            return acc;

        }

        public bool VehicleUser()
        {
            bool found = VehicleDb.FindVehicleUser(username.Value);
            return found;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Session["name"] = username.Value;
            Response.Redirect("HomeLoan.aspx");
        }

        protected void btnVehicle_Click(object sender, EventArgs e)
        {
            Session["name"] = username.Value;
            Response.Redirect("VehicleLoan.aspx");
        }
    }
}