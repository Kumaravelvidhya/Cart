using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class dropdownrepo
    {

        public readonly string connectionString;

        public dropdownrepo()
        {
            connectionString = @"Data Source=LAPTOP-SU2R7JVL\SQLEXPRESS;Initial Catalog=""Shopping Cart"";Integrated Security=True";
        }

        public List<Dropdownmodels> ListProduct()
        {
            try
            {


                List<Dropdownmodels> constrain = new List<Dropdownmodels>();

                var connection = new SqlConnection(connectionString);
                connection.Open();
                constrain = connection.Query<Dropdownmodels>($" exec dropNo ").ToList();
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

        public Dropdownmodels Getproduct(int id)
        {
            try
            {
                SqlConnection con = new SqlConnection(connectionString);
                var connection = new SqlConnection(connectionString);
                con.Open();
                var student = connection.QueryFirst<Dropdownmodels>($" exec Getpro {id} ");
                con.Close();

                return student;


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
