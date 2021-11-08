using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BudgetWebApp.Classes;

namespace BudgetWebApp
{
    public partial class Homepage : System.Web.UI.Page
    {
        private Income income;
        protected void Page_Load(object sender, EventArgs e)
        {
            string g = "";

            if (Session["username"] != null)
            {
                g = Session["username"].ToString();
            }

            

            username.Value = g;

            Income userIncome = new Income();
            userIncome = IncomeDb.GetIncome(username.Value);

            Income userExpense = new Income();
            userExpense = IncomeExpensesDb.GetIncome(username.Value);

            txtIncome.Text = userIncome.GrossIncome.ToString();
            txtTax.Text = userIncome.Tax.ToString();
            txtAfterTax.Text = userIncome.IncomeAfterTax.ToString();
            txtNet.Text = userExpense.NetIncome.ToString();
            txtTotalExpenses.Text = userExpense.TotalExpenses.ToString();

            txtIncome.Enabled = false;
            txtTax.Enabled = false;
            txtAfterTax.Enabled = false;
            txtTotalExpenses.Enabled = false;
            txtNet.Enabled = false;

            btnSave.Enabled = false;
            errLbl.Visible = false;

            
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            txtIncome.Enabled = true;
            txtTax.Enabled = true;
            btnEdit.Enabled = false;
            btnSave.Enabled = true;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(txtIncome.Text) || string.IsNullOrEmpty(txtTax.Text))
            {
                errLbl.Visible = true;
            }
            else
            {
                // calculate the sums of the income after and before expenses and tax
                decimal total = IncomeDb.GetTotalExpense(username.Value);
                decimal afterTax = Calculations.IncomeCalculations.AfterTaxCalculation(Convert.ToDecimal(txtIncome.Text), Convert.ToDecimal(txtTax.Text));
                //get the remaining income of the user after all expenses have been removed(monthly house payment/rent and all the other expenses included)
                decimal afterExpenses = NewAccomodation.NetCalculation(afterTax,total,username.Value);

                //generate new income instance
                income = new Income
                {
                    GrossIncome = Convert.ToDecimal(txtIncome.Text),
                    Tax = Convert.ToDecimal(txtTax.Text),
                    IncomeAfterTax = afterTax,
                    NetIncome = afterExpenses,
                    TotalExpenses = total
                };
                //use this to create a thread that will update the user's income values
                Thread updateThread = new Thread(UpdateUserIncome);
                updateThread.Start();
                btnSave.Enabled = false;
                btnEdit.Enabled = true;

            }

            
        }

        

        /// <summary>
        /// method to update the income information of the user
        /// </summary>
        public void UpdateUserIncome()
        {
            IncomeDb.UpdateIncome(username.Value, income);
        }
    }
}