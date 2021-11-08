using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.WebPages;
using BudgetWebApp.Classes;

namespace BudgetWebApp
{
    public partial class AddOtherExpenses : System.Web.UI.Page
    {
        private string _otherName;
        private string _username;
        private List<string> _name = new List<string>();
        private List<decimal> _cost = new List<decimal>();
        private decimal _otherCost;
        private readonly IDictionary<string, decimal> _otherDictionary = new Dictionary<string, decimal>();
        protected void Page_Load(object sender, EventArgs e)
        {
            string g = "";
            //if (!IsPostBack)
            if (Session["username"] != null)
            {
                g = Session["username"].ToString();
            }

            username.Value = g;
            btnSaveOther.Enabled = true;
            errLbl.Visible = false;
        }

        /// <summary>
        /// METHOD TO ADD VALUES TO THE LISTBOX 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            btnSaveOther.Enabled = true;
            if (!txtOtherExp.Text.IsEmpty() || !txtOtherCost.Text.IsEmpty())
            {
                string name = txtOtherCost.Text;
                decimal cost = Convert.ToDecimal(txtOtherCost.Text);
                _otherDictionary.Add(name, cost);

                Thread thread = new Thread(AddOther);
                thread.Start();

                string item = txtOtherExp.Text + " : R " + txtOtherCost.Text;
                otherList.Items.Add(item);

            }
            else
            {
                errLbl.Visible = true;
            }

        }

        protected void btnSaveOther_Click(object sender, EventArgs e)
        {
            /*Expenses expenses = new Expenses();
            expenses = GeneralExpensesDb.GetExpenses(username.Value);
            decimal subtotal = expenses.Groceries + expenses.Utilities + expenses.Communication +
                            expenses.Travel;
            int x = _otherDictionary.Count;*/
            
            //decimal sum = OtherExpensesDb.GetSum(username.Value);

            //get the total expenses
            //decimal totalExpenses = subtotal + sum;

            //Session["totalExp"] = totalExpenses;
            Session["username"] = username.Value;
            Response.Redirect("NewAccomodation.aspx");
        }

        public void AddOther()
        {
            OtherExpensesDb.AddOther(txtOtherExp.Text, Convert.ToDecimal(txtOtherCost.Text), username.Value);
            // OtherExpensesDb.AddOther(exp,cost,name);
            //OtherExpensesDb.AddOtherExpenses(username.Value,_otherDictionary);
        }

    }
}