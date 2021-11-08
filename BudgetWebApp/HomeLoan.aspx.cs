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
    public partial class HomeLoan : System.Web.UI.Page
    {
        private string _username;
        Expenses home= new Expenses();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["name"]!=null)
                _username = Session["name"].ToString();

            home = GetHome();

            txtPurchase.Text = home.PurchasePrice.ToString();
            txtDeposit.Text = home.Deposit.ToString();
            txtInterest.Text = home.Interest.ToString();
            txtPaymentMonths.Text = home.MonthsToPay.ToString();

            txtMonthly.Text = home.MonthlyPayment.ToString();
            txtTotal.Text = home.TotalPayment.ToString();
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Session["name"] = _username;
            Response.Redirect("ViewExpenses.aspx");
        }

        private Expenses GetHome()
        {
            Expenses h = new Expenses();
            h = HomeLoanDb.GetHomeLoan(_username);
            return h;
        }
    }
}