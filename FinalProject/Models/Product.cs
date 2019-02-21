using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace FinalProject.Models
{
    public class Product
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Price { get; set; }
        public string Size { get; set; }
        public string Description { get; set; }
        public string Color { get; set; }
        public string Material { get; set; }
        public static List<Product> GetAllProduct()
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
            string sql = "SELECT * FROM Product";
            Console.WriteLine(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
            if (con.State == System.Data.ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader rd = cmd.ExecuteReader();
            List<Product> products = new List<Product>();
            if (rd.HasRows)
            {
                while (rd.Read())
                {
                    int ID = rd.GetInt32(1);
                    string Name = rd.GetString(0);
                    string Price = rd.GetString(2);
                    string Color = rd.GetString(3);
                    string Size = rd.GetString(5);
                    string Desciption = rd.GetString(6);
                    string Material = rd.GetString(7);

                    products.Add(new Product { ID = ID, Name = Name, Price = Price, Color = Color, Size = Size, Description = Desciption, Material = Material });
                }
            }
            return products;
        }

        public static Product GetAllProductDetail(int id)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
            string sql = "SELECT * FROM Product where ID = " + id;
            Console.WriteLine(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
            if (con.State == System.Data.ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader rd = cmd.ExecuteReader();
            Product product = new Product();
            if (rd.HasRows)
            {
                while (rd.Read())
                {
                    int ID = rd.GetInt32(1);
                    string Name = rd.GetString(0);
                    string Price = rd.GetString(2);
                    string Color = rd.GetString(3);
                    string Size = rd.GetString(5);
                    string Desciption = rd.GetString(6);
                    string Material = rd.GetString(7);
                    product = new Product { ID = ID, Name = Name, Price = Price, Color = Color, Size = Size, Description = Desciption, Material = Material };
                }
            }
            return product;
        }

        public static bool updateProduct(Product product)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
            string sql = "UPDATE Product SET Name = @Name, Description = @Description, Price = @Price, Material = @Material, Color = @Color, Size = @Size WHERE ID = @ID";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@Name", product.Name);
            cmd.Parameters.AddWithValue("@Description", product.Description);
            cmd.Parameters.AddWithValue("@Price", product.Price);
            cmd.Parameters.AddWithValue("@Material", product.Material);
            cmd.Parameters.AddWithValue("@Color", product.Color);
            cmd.Parameters.AddWithValue("@Size", product.Size);
            cmd.Parameters.AddWithValue("@ID", product.ID);
            if (con.State == System.Data.ConnectionState.Closed)
            {
                con.Open();
            }
            int result = cmd.ExecuteNonQuery();
            if (result > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool addProduct(Product product)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
            string sql = "INSERT INTO Product(Name, Price, Color, Description, Size, Material) VALUES (@Name, @Price, @Color, @Description, @Size, @Material)";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@Name", product.Name);
            cmd.Parameters.AddWithValue("@Price", product.Price);
            cmd.Parameters.AddWithValue("@Color", product.Color);
            cmd.Parameters.AddWithValue("@Description", product.Description);
            cmd.Parameters.AddWithValue("@Size", product.Size);
            cmd.Parameters.AddWithValue("@Material", product.Material);
            if (con.State == System.Data.ConnectionState.Closed)
            {
                con.Open();
            }
            try
            {
                int result = cmd.ExecuteNonQuery();
                if (result > 0) return true;
                else return false;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public static bool deleteProduct(int id)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
            string sql = "DELETE FROM Product WHERE ID = " + id;
            SqlCommand cmd = new SqlCommand(sql, con);
            if (con.State == System.Data.ConnectionState.Closed)
            {
                con.Open();
            }
            try
            {
                int result = cmd.ExecuteNonQuery();
                if (result > 0) return true;
                else return false;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
