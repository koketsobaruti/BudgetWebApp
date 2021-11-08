using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.WebPages;
using System.Xml.Schema;
using BudgetWebApp.Classes;
using Microsoft.Ajax.Utilities;

namespace BudgetWebApp
{
    public partial class AddGeneralExpenses : System.Web.UI.Page
    { 
        string namePassed;
        decimal _total;

        private Expenses expenses;
        private Income income;

        protected void Page_Load(object sender, EventArgs e)
        {
            string g="";
            //if (!IsPostBack)
                if (Session["username"] != null)
                {
                    g = Session["username"].ToString();
                }
                
            
            
           Label1.Text = g;
            //Label1.Visible = true;
            username.Value = g;
            errorEmptyLbl.Visible = false;
            panelExpenseList.Visible = false;
            //lblRentConfirmation.Visible = false;
            //houseConfirmation.Visible = false;
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            if ((txtMonthlyIncome.Text.IsEmpty()) || (txtTax.Text.IsEmpty()) || (txtGroceries.Text.IsEmpty()) ||
                (txtCommunication.Text.IsEmpty()) || (txtTravel.Text.IsEmpty()) || (txtUtilies.Text.IsEmpty()))
            {
                errorEmptyLbl.Visible = true;
            }
        }



        protected void btnContinue_Click(object sender, EventArgs e)
        {
            if (!txtMonthlyIncome.Text.IsEmpty() || !txtTax.Text.IsEmpty() || !txtGroceries.Text.IsEmpty() ||
                !txtCommunication.Text.IsEmpty() || !txtTravel.Text.IsEmpty() || !txtUtilies.Text.IsEmpty())
            {

                decimal afterTax = Calculations.IncomeCalculations.AfterTaxCalculation(Convert.ToDecimal(txtMonthlyIncome.Text), Convert.ToDecimal(txtTax.Text));

                /*Task<bool> findTask = new Task<bool>(FindOther);
                findTask.Start();
                bool found = findTask.Result;*/
                expenses = new Expenses
                {
                    Groceries = Convert.ToDecimal(txtGroceries.Text),
                    Utilities = Convert.ToDecimal(txtUtilies.Text),
                    Communication = Convert.ToDecimal(txtCommunication.Text),
                    Travel = Convert.ToDecimal(txtTravel.Text)
                };
                //wait until the username is found in the other expenses table
                //findTask.Wait();
                Thread addExpThread = new Thread(AddGeneral);
                addExpThread.Start();
                //Calculate total expenses
                decimal total = 0;
                /*if (found)
                {
                    var otherList = OtherExpensesDb.GetCostList(_username);
                    otherList = GetExpenseList(otherList, expenses);

                    total = Calculations.IncomeCalculations.TotalExpensesCalculation(otherList);
                }
                else
                {*/
                    total = expenses.Groceries + expenses.Utilities + expenses.Communication +
                            expenses.Travel;

                //}

                //create instance of income which which is used to add details to the income table in the next page
                income = new Income()
                {
                    GrossIncome = Convert.ToDecimal(txtMonthlyIncome.Text),
                    Tax = Convert.ToDecimal(txtTax.Text),
                    IncomeAfterTax = afterTax,
                    //TotalExpenses = total
                };

                Thread addThread = new Thread(AddIncome);
                addThread.Start();

                //Session["income"] = income;
                Session["username"] = username.Value;
                Response.Redirect("NewAccomodation.aspx");
            }
        }
        public static List<decimal> GetExpenseList(List<decimal> otherList, Expenses exp)
        {
            otherList.Add(exp.Groceries);
            otherList.Add(exp.Utilities);
            otherList.Add(exp.Communication);
            otherList.Add(exp.Travel);
            return otherList;
        }
        public void AddGeneral()
        {
            GeneralExpensesDb.AddGeneralExpenses(username.Value, expenses);
        }
        protected void btnAddOther_Click(object sender, EventArgs e)
        {
            //name = Label1.Text;

            expenses = new Expenses
            {
                Groceries = Convert.ToDecimal(txtGroceries.Text),
                Utilities = Convert.ToDecimal(txtUtilies.Text),
                Communication = Convert.ToDecimal(txtCommunication.Text),
                Travel = Convert.ToDecimal(txtTravel.Text)
            };
            decimal afterTax = Calculations.IncomeCalculations.AfterTaxCalculation(Convert.ToDecimal(txtMonthlyIncome.Text), Convert.ToDecimal(txtTax.Text));

            Thread addThread = new Thread(AddGeneral);
            addThread.Start();

            income = new Income()
            {
                GrossIncome = Convert.ToDecimal(txtMonthlyIncome.Text),
                Tax = Convert.ToDecimal(txtTax.Text),
                IncomeAfterTax = afterTax,
                //TotalExpenses = total
            };

            Thread addIncomeThread = new Thread(AddIncome);
            addIncomeThread.Start();

            Session["username"] = username.Value;
            //Session["income"] = income;
            Response.Redirect("AddOtherExpenses.aspx");
            //otherExpensesPanel.Visible = true;
            //otherList.Visible = true;
        }

        //method to add income details into the database
        public void AddIncome()
        {
            IncomeDb.AddIncome(username.Value, income);
        }
       
    }
}
