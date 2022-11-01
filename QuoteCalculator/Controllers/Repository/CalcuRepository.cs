using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using System.Runtime.InteropServices.ComTypes;
using System.Reflection;
using System.Web.Helpers;

namespace QuoteCalculator.Controllers.Repository
{
    public class CalcuRepository
    {
        string constr = ConfigurationManager.ConnectionStrings["CALCUEntities"].ConnectionString;
        
        public string GetProduct()
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(constr))
            {
                SqlCommand cmd = new SqlCommand("proc_getproduct", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                con.Open();
                da.Fill(dt);
                con.Close();
            }
            return JsonConvert.SerializeObject(dt);
        }

        public string InsertQuote(
            string AmountRequired,
            string Term,
            string Title,
            string FirstName,
            string LastName,
            string DateOfBirth,
            string Mobile,
            string Email,
            string Product
            )
        {
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    SqlCommand cmd = new SqlCommand("proc_insertquote", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    
                    //parameter
                    cmd.Parameters.AddWithValue("@Title", Title);
                    cmd.Parameters.AddWithValue("@FirstName", FirstName);
                    cmd.Parameters.AddWithValue("@LastName", LastName);
                    cmd.Parameters.AddWithValue("@Product", Product);
                    cmd.Parameters.AddWithValue("@Amount", AmountRequired);
                    cmd.Parameters.AddWithValue("@Term", Term);
                    cmd.Parameters.AddWithValue("@Email", Email);
                    cmd.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
                    cmd.Parameters.AddWithValue("@Mobile", Mobile);

                    //output paramete
                    SqlParameter outPutParameter = new SqlParameter();
                    outPutParameter.ParameterName = "@QID";
                    outPutParameter.SqlDbType = System.Data.SqlDbType.Int;
                    outPutParameter.Direction = System.Data.ParameterDirection.Output;
                    cmd.Parameters.Add(outPutParameter);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();

                    string str_QID = outPutParameter.Value.ToString();
                    return str_QID;
                }
            }
            catch (Exception ex)
            {
                return "Error connecting to the database";
            }
        }
        public string UpdateQuote(
            string AmountRequired,
            string Term,
            string Title,
            string FirstName,
            string LastName,
            string DateOfBirth,
            string Mobile,
            string Email,
            string Product,
            string Weekly,
            string QID
            )
        {
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    SqlCommand cmd = new SqlCommand("proc_updatedquote", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    //parameter
                    cmd.Parameters.AddWithValue("@Title", Title);
                    cmd.Parameters.AddWithValue("@FirstName", FirstName);
                    cmd.Parameters.AddWithValue("@LastName", LastName);
                    cmd.Parameters.AddWithValue("@Product", Product);
                    cmd.Parameters.AddWithValue("@Amount", AmountRequired);
                    cmd.Parameters.AddWithValue("@Term", Term);
                    cmd.Parameters.AddWithValue("@Email", Email);
                    cmd.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
                    cmd.Parameters.AddWithValue("@Mobile", Mobile);
                    cmd.Parameters.AddWithValue("@Weekly", Weekly);
                    cmd.Parameters.AddWithValue("@QID", QID);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();

                    return "SUCCESS";
                }
            }
            catch (Exception ex)
            {
                return "Error connecting to the database";
            }
        }
        public string GetQuote()
        {
            try
            {
                DataTable dt = new DataTable();
                using (SqlConnection con = new SqlConnection(constr))
                {
                    SqlCommand cmd = new SqlCommand("proc_getQuotes", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    con.Open();
                    da.Fill(dt);
                    con.Close();

                    return JsonConvert.SerializeObject(dt);
                }
            }
            catch (Exception ex)
            {
                return "Error connecting to the database";
            }
        }
    }
}