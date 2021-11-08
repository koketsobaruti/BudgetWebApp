using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BudgetWebApp.Classes;

namespace BudgetWebApp
{
    public partial class VehicleLoan : System.Web.UI.Page
    {
        private string _username;
        Vehicle vehicle = new Vehicle();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["name"]!=null)
                _username = Session["name"].ToString();

            vehicle = GetVehicle();

            txtMake.Text = vehicle.Make;
            txtModel.Text = vehicle.Model;
            txtDeposit.Text = vehicle.TotalDeposit.ToString();
            txtPurchasePrice.Text = vehicle.PurchasePrice.ToString();
            txtInsurance.Text = vehicle.Insurance.ToString();
            txtInterest.Text = vehicle.InterestRate.ToString();
            
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Session["name"] = _username;
            Response.Redirect("ViewExpenses.aspx");
        }

        private Vehicle GetVehicle()
        {
            Vehicle veh = new Vehicle();
            veh = VehicleDb.GetVehicleLoan(_username);
            return veh;
        }
    }
}