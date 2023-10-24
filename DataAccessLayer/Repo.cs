using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class Repo
    {
         
        public readonly string connectionString;

        public Repo()
        {
            connectionString = @"Data Source=LAPTOP-SU2R7JVL\SQLEXPRESS;Initial Catalog=""Shopping Cart"";Integrated Security=True";
        }

        public List<AddProduct> ListProduct()
        {
            try
            {
                List<AddProduct> constrain = new List<AddProduct>();

                var connection = new SqlConnection(connectionString);
                connection.Open();
                constrain = connection.Query<AddProduct>($" exec GetproductNo ").ToList();
                connection.Close();

                return constrain;


            }

            catch (SqlException er)
            {
                throw;
            }
            catch (Exception r)
            {
                throw r;
            }
        }

        public AddProduct Getproduct(int No)
        {
            try
            {
                SqlConnection con = new SqlConnection(connectionString);
                var connection = new SqlConnection(connectionString);
                con.Open();
                var product = connection.QueryFirst<AddProduct>($"exec Getproduct {No}");
                con.Close();



                return product;


            }

            catch (SqlException er)
            {
                throw;
            }
            catch (Exception r)
            {
                throw r;
            }
        }

        public void InsertProduct(AddProduct pro)
        {

            try
            {
                SqlConnection con = new SqlConnection(connectionString);

                con.Open();
                con.Execute($" exec Selectproduct'{pro.Code}', '{pro.ProductName}','{pro.Quantity}','{pro.Unitprice}','{pro.Subtotal}'");

                con.Close();

            }
            catch (SqlException ex)
            {
                throw;
            }
            catch (Exception e)
            {
                throw e;
            }

        }
        public void Delete(int No)
        {
            try
            {


                SqlConnection con = new SqlConnection(connectionString);

                con.Open();
                con.Execute($" exec Deleteproduct {No}");

                con.Close();

            }
            catch (SqlException ed)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public List<Total> Totalamount()
        {
            try
            {
                List<Total> constrain = new List<Total>();

                var connection = new SqlConnection(connectionString);
                connection.Open();
                constrain = connection.Query<Total>($" exec Total ").ToList();
                connection.Close();

                return constrain;


            }

            catch (SqlException er)
            {
                throw;
            }
            catch (Exception r)
            {
                throw r;
            }
        }

    }
}
