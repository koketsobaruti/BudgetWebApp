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
    public partial class Savings : System.Web.UI.Page
    {
        private DateTime _selectedDate;
        private decimal _monthlySimple,_monthlyCompound;
        private int _dateDifference;
        private UserSavings savings;
            string interestType="";
        protected void Page_Load(object sender, EventArgs e)
        {
            string g = "";
            //if (!IsPostBack)
            if (Session["username"] != null)
            {
                g = Session["username"].ToString();
            }

            username.Value = g;
            TextBox1.Enabled = false;
            errLbl.Visible = false;
        }

        protected void btnCalculate_Click(object sender, EventArgs e)
        {
            if (!txtReason.Text.IsEmpty() || !txtGoal.Text.IsEmpty() || !txtInterestRate.Text.IsEmpty()
                || !txtYears.Text.IsEmpty())
            {
                DateTime currentDate = Calculations.SavingsCalculations.GetCurrentDateTime();
                DateTime d2 = currentDate.AddYears(Convert.ToInt32(txtYears.Text));
                //_dateDifference = Calculations.SavingsCalculations.GetMonthDifference(currentDate,Convert.ToDateTime(txtDateChosen.Text));
                if(TextBox1.Text.IsEmpty())
                {
                    int months = Convert.ToInt32(txtYears.Text) * 12;
                    _monthlySimple = Calculations.SavingsCalculations.SimpleInterestCalculation(
                        Convert.ToDecimal(txtGoal.Text.ToString()), Convert.ToDecimal(txtInterestRate.Text),
                        months);
                    txtRequiredAmount.Text = _monthlySimple.ToString();
                    UserSavings savings = new UserSavings
                    {
                        Reason = txtReason.Text,
                        EndDate = d2,
                        InterestMethod = "single",
                        InterestRate = Convert.ToDouble(txtInterestRate.Text),
                        Investment = (double) _monthlySimple,
                        SavingsGoal = Convert.ToDecimal(txtGoal.Text),
                        StartDate = currentDate
                    };
                    SavingsDb.AddSavings(username.Value, savings);
                    txtReason.Enabled = false;
                    txtGoal.Enabled = false;
                    txtInterestRate.Enabled = false;
                    txtYears.Enabled = false;
                }
                else if (!TextBox1.Text.IsEmpty())
                {
                    int months = Convert.ToInt32(txtYears.Text) * 12;
                    _monthlyCompound = Calculations.SavingsCalculations.CompoundInterestCalculation(
                        Convert.ToDecimal(txtGoal.Text), Convert.ToDecimal(txtInterestRate.Text),
                        months, Convert.ToInt32(TextBox1.Text));
                    txtRequiredAmount.Text = _monthlyCompound.ToString();

                    UserSavings savings = new UserSavings
                    {
                        Reason = txtReason.Text,
                        EndDate = d2,
                        InterestMethod = "compound",
                        InterestRate = Convert.ToDouble(txtInterestRate.Text),
                        Investment = (double)_monthlyCompound,
                        SavingsGoal = Convert.ToDecimal(txtGoal.Text),
                        StartDate = currentDate
                    };
                    SavingsDb.AddSavings(username.Value, savings);
                    txtReason.Enabled = false;
                    txtGoal.Enabled = false;
                    txtInterestRate.Enabled = false;
                    txtYears.Enabled = false;
                }
            }
        }


        protected void btnCompound_Click(object sender, EventArgs e)
        {
            btnSimple.BackColor = System.Drawing.Color.LightSalmon;
            btnCompound.BackColor = System.Drawing.Color.MediumBlue;
            interestType = "compound";
            btnAdd.Enabled = true;
            TextBox1.Enabled = true;
            btnAdd.BackColor = System.Drawing.Color.MediumSeaGreen;
        }

        protected void btnSimple_Click(object sender, EventArgs e)
        {
            btnSimple.BackColor = System.Drawing.Color.OrangeRed;
            btnCompound.BackColor = System.Drawing.Color.LightSteelBlue;
            interestType = "simple";
            TextBox1.Enabled = false;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            txtReason.Enabled = true;
            txtGoal.Enabled = true;
            txtInterestRate.Enabled = true;
            txtYears.Enabled = true;
        }

        

    }

}