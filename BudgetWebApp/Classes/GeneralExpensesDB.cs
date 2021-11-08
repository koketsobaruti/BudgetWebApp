using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BudgetWebApp.Classes
{
    public class GeneralExpensesDb
    {
        public static void AddGeneralExpenses(string name, Expenses expenses)
        {
            using (var connection = new SqlConnection(DatabaseConnection.GetConnection()))
            {
                try
                {
                    connection.Open();
                    try
                    {
                        var command = new SqlCommand("INSERT INTO TBL_GENERAL_EXPENSES(FK_USERNAME,GROCERIES,WATER_LIGHTS,TRAVEL,COMMUNICATION) " +
                                "VALUES(@FK_USERNAME,@GROCERIES,@WATER_LIGHTS,@TRAVEL,@COMMUNICATION)", connection);

                        command.Parameters.AddWithValue("@FK_USERNAME", name);
                        command.Parameters.AddWithValue("@GROCERIES", expenses.Groceries);
                        command.Parameters.AddWithValue("@WATER_LIGHTS", expenses.Utilities);
                        command.Parameters.AddWithValue("@TRAVEL", expenses.Travel);
                        command.Parameters.AddWithValue("@COMMUNICATION", expenses.Communication);

                        command.ExecuteNonQuery();
                    }
                    catch (Exception ex) { throw ex; }
                    finally
                    {
                        connection.Close();
                    }
                }
                catch (Exception ex) { throw ex; }
                finally
                {
                    connection.Close();
                }
            }

        }
        public static bool FindEntry(string username)
        {
            bool found = false;
            using (var connection = new SqlConnection(DatabaseConnection.GetConnection()))
            {
                try
                {
                    connection.Open();
                    try
                    {
                        var command = new SqlCommand(@"SELECT COUNT(*) FROM TBL_GENERAL_EXPENSES WHERE (FK_USERNAME = @username)", connection);

                        command.Parameters.AddWithValue("@username", username);
                        int count = (int)command.ExecuteScalar();
                        if (count > 0)
                        {
                            found = true;
                        }
                    }
                    catch (Exception ex) { throw ex; }
                    finally
                    {
                        connection.Close();
                    }

                }
                catch (Exception ex) { throw ex; }
                finally
                {
                    connection.Close();
                }


            }
            return found;
        }
        public static Expenses GetExpenses(string name)
        {
            var exp = new Expenses();
            using (var connection = new SqlConnection(DatabaseConnection.GetConnection()))
            {
                try
                {
                    connection.Open();
                    try
                    {
                        var command = new SqlCommand("SELECT GROCERIES,WATER_LIGHTS,TRAVEL,COMMUNICATION FROM TBL_GENERAL_EXPENSES" +
                            " WHERE FK_USERNAME = @FK_USERNAME", connection);

                        command.Parameters.AddWithValue("@FK_USERNAME", name);

                        SqlDataReader reader = command.ExecuteReader();
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                exp = new Expenses
                                {
                                    Groceries = Convert.ToDecimal(reader["GROCERIES"]),
                                    Utilities = Convert.ToDecimal(reader["WATER_LIGHTS"]),
                                    Travel = Convert.ToDecimal(reader["TRAVEL"]),
                                    Communication = Convert.ToDecimal(reader["COMMUNICATION"]),
                                };
                            }
                        }
                    }
                    catch (Exception ex) { throw ex; }
                    finally
                    {
                        connection.Close();
                    }
                }
                catch (Exception ex) { throw ex; }
                finally
                {
                    connection.Close();
                }
            }

            return exp;
        }
    }
}