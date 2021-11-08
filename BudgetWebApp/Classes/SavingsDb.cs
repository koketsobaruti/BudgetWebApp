using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BudgetWebApp.Classes
{
    public class SavingsDb
    {
        public static void AddSavings(string name, UserSavings savings)
        {
            using (var connection = new SqlConnection(DatabaseConnection.GetConnection()))
            {
                try
                {
                    connection.Open();
                    try
                    {
                        var command = new SqlCommand("INSERT INTO TBL_SAVINGS(FK_USERNAME,REASON,INVESTED_AMOUNT,INTEREST_RATE,INVESTMENT_START_DATE," +
                                                     "INVESTMENT_END_DATE,SAVINGS_GOAL,INTEREST_METHOD) VALUES(@FK_USERNAME,@REASON,@INVESTED_AMOUNT,@INTEREST_RATE,@INVESTMENT_START_DATE," +
                                                     "@INVESTMENT_END_DATE,@SAVINGS_GOAL,@INTEREST_METHOD) ",connection);

                        command.Parameters.AddWithValue("@FK_USERNAME", name);
                        command.Parameters.AddWithValue("@REASON",savings.Reason);
                        command.Parameters.AddWithValue("@INVESTED_AMOUNT", savings.Investment);
                        command.Parameters.AddWithValue("@INTEREST_RATE", savings.InterestRate);
                        command.Parameters.AddWithValue("@INVESTMENT_START_DATE", savings.StartDate);
                        command.Parameters.AddWithValue("@INVESTMENT_END_DATE", savings.EndDate);
                        command.Parameters.AddWithValue("@SAVINGS_GOAL", savings.SavingsGoal);
                        command.Parameters.AddWithValue("@INTEREST_METHOD", savings.InterestMethod);

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

        public static bool findSavings(String username)
        {
            bool found = false;
            using (var connection = new SqlConnection(DatabaseConnection.GetConnection()))
            {
                try
                {
                    connection.Open();
                    try
                    {
                        var command = new SqlCommand(@"SELECT FK_USERNAME FROM TBK_SAVINGS WHERE (FK_USERNAME = @username)", connection);

                        command.Parameters.AddWithValue("@username", username);
                        SqlDataReader reader = command.ExecuteReader();
                        if (reader.HasRows)
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

        public static void UpdateSavings(string name, UserSavings savings)
        {
            using (var connection = new SqlConnection(DatabaseConnection.GetConnection()))
            {
                try
                {
                    connection.Open();
                    try
                    {
                        var command = new SqlCommand("UPDATE TBL_SAVINGS SET REASON=@REASON,INVESTED_AMOUNT=@INVESTED_AMOUNT,INTEREST_RATE=@INTEREST_RATE," +
                                                     "INVESTMENT_END_DATE=@INVESTMENT_END_DATE, SAVINGS_GOAL=@SAVINGS_GOAL," +
                                                     "INTEREST_METHOD=@INTEREST_METHOD WHERE FK_USERNAME=@FK_USERNAME", connection);

                        command.Parameters.AddWithValue("@FK_USERNAME", name);
                        command.Parameters.AddWithValue("@REASON", savings.Reason);
                        command.Parameters.AddWithValue("@INVESTED_AMOUNT", savings.Investment);
                        command.Parameters.AddWithValue("@INTEREST_RATE", savings.InterestRate);
                        command.Parameters.AddWithValue("@INVESTMENT_END_DATE", savings.EndDate);
                        command.Parameters.AddWithValue("@SAVINGS_GOAL", savings.SavingsGoal);
                        command.Parameters.AddWithValue("@INTEREST_METHOD", savings.InterestMethod);

                        command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                    finally
                    {
                        connection.Close();
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    connection.Close();
                }
            }

        }

        public static Collection<UserSavings> GetSavingsList(string name)
        {
            UserSavings savings;
            var userList = new Collection<UserSavings>();
            using (var connection = new SqlConnection(DatabaseConnection.GetConnection()))
            {
                try
                {
                    connection.Open();
                    try
                    {
                        var command = new SqlCommand("SELECT REASON,INVESTED_AMOUNT,INTEREST_RATE,INVESTMENT_START_DATE" +
                                                     "INVESTMENT_END_DATE,SAVINGS_GOAL,INTEREST_METHOD FROM TBL_SAVINGS WHERE FK_USERNAME=@FK_USERNAME");

                        command.Parameters.AddWithValue("@FK_USERNAME", name);
                        SqlDataReader reader = command.ExecuteReader();
                        if (reader.HasRows)
                        {
                            while (reader != null)
                            {
                                savings = new UserSavings
                                {
                                    Reason = (string) reader["REASON"],
                                    EndDate = (DateTime) reader["INVESTMENT_END_DATE"],
                                    InterestRate = (double) reader["INTEREST_RATE"] ,
                                    InterestMethod = (string) reader["INTEREST_METHOD"],
                                    Investment = (double) reader["INVESTED_AMOUNT"],
                                    SavingsGoal = (decimal) reader["SAVINGS_GOAL"],
                                    StartDate = (DateTime) reader["INVESTMENT_START_DATE"]
                                };

                                userList.Add(savings);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                    finally
                    {
                        connection.Close();
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    connection.Close();
                }

                return userList;
            }
        }
    }
}