using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.WebPages;
using BudgetWebApp.Classes;

namespace BudgetWebApp
{
    public partial class AddVehicle : System.Web.UI.Page
    {
        private Income _incomePassed;
        private String _username;
        private Vehicle _vehicle;
        private bool added = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            string g = "";
            
                if (Session["username"] != null)
                {
                    g = Session["username"].ToString();
                }
            
            
            username.Value = g;
            Label1.Visible = false;
        }

        protected void btnReturn_Click(object sender, EventArgs e)
        {
            Session["name"] = username.Value;
            Response.Redirect("NewAccomodation.aspx");
        }

        protected void btnComplete_Click(object sender, EventArgs e)
        {
            bool found = FindVeh();
            if (found)
            {
                Session["name"] = username.Value;
                Response.Redirect("Homepage.aspx");
            }
            else
            {
                Label1.Visible = true;
                Label1.Text = "You need to add your vehicle details first.";
            }
                
            
        }

        

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (!txtMake.Text.IsEmpty() || !txtModel.Text.IsEmpty() || !txtDeposit.Text.IsEmpty() ||
                !txtPurchasePrice.Text.IsEmpty()
                || !txtInsurance.Text.IsEmpty() || !txtInterest.Text.IsEmpty())
            {
                //use the calculation library class to get the total monthly amount to be paid as will as the total cost of the car
                decimal totalMonthlyPayment = Calculations.PaymentsCalculations.VehicleRepayementCalculation(60, Convert.ToDecimal(txtPurchasePrice.Text),
                    Convert.ToDecimal(txtInterest.Text), Convert.ToDecimal(txtDeposit.Text), Convert.ToDecimal(txtInsurance.Text));

                decimal totalCarPayment = Calculations.PaymentsCalculations.TotalPaymentCalculation(60, Convert.ToDecimal(txtPurchasePrice.Text),
                    Convert.ToDecimal(txtInterest.Text), Convert.ToDecimal(txtDeposit.Text));
                _vehicle = new Vehicle
                {
                    Make = txtMake.Text,
                    Model = txtModel.Text,
                    Insurance = Convert.ToDecimal(txtInsurance.Text),
                    InterestRate = Convert.ToDecimal(txtInterest.Text),
                    PurchasePrice = Convert.ToDecimal(txtPurchasePrice.Text),
                    TotalVehiclePayment = totalCarPayment,
                    TotalDeposit = Convert.ToDecimal(txtDeposit.Text),
                    VehicleMonthlyPayment = totalMonthlyPayment
                };
                Thread addVehThread = new Thread(LoadVehicle);
                addVehThread.Start();
                Label1.Visible = true;
            }
        }
        public void LoadVehicle()
        {
            VehicleDb.AddVehicle(username.Value, _vehicle);
        }

        public bool FindVeh()
        {
            bool found = VehicleDb.FindVehicleUser(username.Value);
            return found;
        }
    }
}