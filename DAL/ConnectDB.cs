using DAL.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class ConnectDB
    { 
        private const string __CONNECT = "Data Source=ADMIN;Initial Catalog=FPTS;Persist Security Info=True;User ID=sa;Password=123456;";      

        public IEnumerable<Product> GetAllProduct()
        {
            List<Product> listProduct = new List<Product>();
            using (SqlConnection sqlConnection = new SqlConnection(__CONNECT))
            {
                SqlCommand cmd = new SqlCommand("Sp_SelectProduct", sqlConnection);
                cmd.CommandType = CommandType.StoredProcedure;

                sqlConnection.Open();
                SqlDataReader sdr = cmd.ExecuteReader();

                while (sdr.Read())
                {
                    Product product = new Product();
                    product.Id = Convert.ToInt32(sdr["id"]);
                    product.Name = sdr["name"].ToString();
                    product.Quantity = string.IsNullOrEmpty(sdr["quantity"].ToString()) ?  0 : Convert.ToInt32(sdr["quantity"]);
                    product.Price = string.IsNullOrEmpty( sdr["price"].ToString()) ?  0 : float.Parse(sdr["price"].ToString());
                    product.Id_brands = string.IsNullOrEmpty( sdr["id_brands"].ToString() ) ? 0 : Convert.ToInt32(sdr["id_brands"]);
                    product.Id_categories = string.IsNullOrEmpty( sdr["id_categories"].ToString())  ? 0 : Convert.ToInt32(sdr["id_categories"]);
                    product.Created_Date = string.IsNullOrEmpty( sdr["CreatedAt"].ToString() ) ? DateTime.Now : DateTime.Parse(sdr["CreatedAt"].ToString());
                    listProduct.Add(product);
                }
                sqlConnection.Close();               
            }
            return listProduct;
        }
        public void AddProduct(Product product)
        {
            using (SqlConnection sqlConnection = new SqlConnection(__CONNECT))
            {
                SqlCommand cmd = new SqlCommand("Sp_AddProduct", sqlConnection);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@NAME",product.Name);
                cmd.Parameters.AddWithValue("@PRICE", product.Price);
                cmd.Parameters.AddWithValue("@QUANTITY", product.Quantity);
                cmd.Parameters.AddWithValue("@ID_CATEGORIES", product.Id_categories);
                cmd.Parameters.AddWithValue("@ID_BRANDS", product.Id_brands);
                cmd.Parameters.AddWithValue("@CREATED_AT", product.Created_Date);

                sqlConnection.Open();
                cmd.ExecuteNonQuery();
                sqlConnection.Close();
            }
        }
        public void UpdateProduct(Product product)
        {
            using (SqlConnection sqlConnection = new SqlConnection(__CONNECT))
            {
                SqlCommand cmd = new SqlCommand("Sp_UpdateProduct", sqlConnection);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@ID", product.Id);
                cmd.Parameters.AddWithValue("@NAME", product.Name);
                cmd.Parameters.AddWithValue("@PRICE", product.Price);
                cmd.Parameters.AddWithValue("@QUANTITY", product.Quantity);
                cmd.Parameters.AddWithValue("@ID_CATEGORIES", product.Id_categories);
                cmd.Parameters.AddWithValue("@ID_BRANDS", product.Id_brands);
                cmd.Parameters.AddWithValue("@CREATED_AT", product.Created_Date);

                sqlConnection.Open();
                cmd.ExecuteNonQuery();
                sqlConnection.Close();
            }
        }
        public Product GetProductById(int? id)
        {
            Product product = new Product();
            using (SqlConnection sqlConnection = new SqlConnection(__CONNECT))
            {
                SqlCommand cmd = new SqlCommand("Sp_GetIdProduct", sqlConnection);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@ID", id);
                sqlConnection.Open();
                SqlDataReader sdr = cmd.ExecuteReader();

                while (sdr.Read())
                {         
                    product.Id = Convert.ToInt32(sdr["id"]);
                    product.Name = sdr["name"].ToString();
                    product.Quantity = Convert.ToInt32(sdr["quantity"]);
                    product.Price = float.Parse(sdr["price"].ToString());
                    product.Id_brands = Convert.ToInt32(sdr["id_brands"]);
                    product.Id_categories = Convert.ToInt32(sdr["id_categories"]);
                    product.Created_Date = DateTime.Parse(sdr["CreatedAt"].ToString());                   
                }
                sqlConnection.Close();
            }
            return product;
        }
        public void DeleteProduct(int? id)
        {
            using (SqlConnection sqlConnection = new SqlConnection(__CONNECT))
            {
                SqlCommand cmd = new SqlCommand("Sp_DeleteProduct", sqlConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID", id);
                sqlConnection.Open();
                cmd.ExecuteReader();
                sqlConnection.Close();
            }
        }
        public DataSet SelectBrand()
        {
            using (SqlConnection sqlConnection = new SqlConnection(__CONNECT))
            {
                DataSet ds = new DataSet();
                try
                {
                    sqlConnection.Open();
                    SqlCommand command = new SqlCommand("Sp_SelectBrand", sqlConnection);
                    command.CommandType = CommandType.StoredProcedure;

                    SqlDataAdapter da = new SqlDataAdapter(command);
                    da.Fill(ds);
                    sqlConnection.Close();
                    return ds;
                }
                catch
                {
                    sqlConnection.Close();
                    return ds;
                }
            }
        }
        public DataSet SelectCate()
        {
            using (SqlConnection sqlConnection = new SqlConnection(__CONNECT))
            {
                DataSet ds = new DataSet();
                try
                {
                    sqlConnection.Open();
                    SqlCommand sqlCommand = new SqlCommand("Sp_SelectCategory", sqlConnection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
                    adapter.Fill(ds);
                    sqlConnection.Close();
                    return ds;
                }
                catch
                {
                    sqlConnection.Close();
                    return ds;
                }
            }
        }
    }
}
