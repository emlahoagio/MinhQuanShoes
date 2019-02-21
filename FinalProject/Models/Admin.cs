using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace FinalProject.Models
{
    public class Admin
    {
        public string username;
        public string password;
        public static bool CheckLogin(string username, string password)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
            string sql = "SELECT * FROM Admin WHERE username='" + username + "' and password='" + password + "'";
            Console.WriteLine(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
            if (con.State == System.Data.ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader rd = cmd.ExecuteReader();
            return rd.HasRows;
        }
    }
}