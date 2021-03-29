using DAL.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Serilog;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace DAL
{
    public class ConnectDB
    {
        private readonly IConfiguration configuration;
        private readonly string _strConn;
        private const string __DEFAULT_CONN = "DB_3Tier";
        private readonly SqlConnection _sqlConnection;
        private readonly ILogger<ConnectDB> _logger;

        public ConnectDB(IConfiguration config, ILogger<ConnectDB> logger)
        {
           
            _logger = logger;

            this.configuration = config;
            _strConn = configuration.GetConnectionString(__DEFAULT_CONN);
            _sqlConnection = new SqlConnection(_strConn);
        }
        //private const string __CONNECT = "Data Source=ADMIN;Initial Catalog=FPTS;Persist Security Info=True;User ID=sa;Password=123456;"; 
        public DataTable ReadProduct()
        {

            //Log.Logger = new LoggerConfiguration()
            //   .MinimumLevel.Debug()
            //   .WriteTo.File("E://FPTS/3_Tier/3Tier/Logging/demo_log-20210329.txt", rollingInterval: RollingInterval.Day)
            //   .CreateLogger();

            //Log.Information("Hello, world!");

            DataTable dt = new DataTable();

            try
            {
               // Log.Debug("Debuggingg");
                if (ConnectionState.Closed == _sqlConnection.State)
                {
                    _sqlConnection.Open();
                }
                SqlCommand cmd = new SqlCommand("Sp_SelectProduct123", _sqlConnection);
                SqlDataReader rd = cmd.ExecuteReader();
                dt.Load(rd);
            }
            catch(Exception e)
            {

               // Log.Error(e.Message, "Something went wrong");
                //_logger.LogWarning(e.Message);
                throw ;
            }
            finally
            {
                //Log.CloseAndFlush();
                _sqlConnection.Close();
            }
            return dt;
        }
        public DataTable GetProductById(int? id)
        {
            DataTable dt = new DataTable();
            try
            {
                if (ConnectionState.Closed == _sqlConnection.State)
                {
                    _sqlConnection.Open();
                }
                SqlCommand cmd = new SqlCommand("Sp_GetIdProduct", _sqlConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID", id);
                SqlDataReader rd = cmd.ExecuteReader();
                dt.Load(rd);
            }
            catch
            {
                throw;
            }
            finally
            {
                _sqlConnection.Close();
            }
            return dt;
        }
        public void InsertProduct(Product product)
        {
            try
            {
                if (ConnectionState.Closed == _sqlConnection.State)
                {
                    _sqlConnection.Open();
                }
                SqlCommand cmd = new SqlCommand("Sp_AddProduct", _sqlConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@NAME", product.Name);
                cmd.Parameters.AddWithValue("@PRICE", product.Price);
                cmd.Parameters.AddWithValue("@QUANTITY", product.Quantity);
                cmd.Parameters.AddWithValue("@ID_CATEGORIES", product.Id_categories);
                cmd.Parameters.AddWithValue("@ID_BRANDS", product.Id_brands);
                cmd.Parameters.AddWithValue("@CREATED_AT", product.Created_Date);
                cmd.ExecuteNonQuery();
            }
            catch
            {
                throw;
            }
            finally
            {
                _sqlConnection.Close();
            }
        }
        public void UpdateProduct(Product product)
        {
            try
            {
                if (ConnectionState.Closed == _sqlConnection.State)
                {
                    _sqlConnection.Open();
                }
                SqlCommand cmd = new SqlCommand("Sp_UpdateProduct", _sqlConnection);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@ID", product.Id);
                cmd.Parameters.AddWithValue("@NAME", product.Name);
                cmd.Parameters.AddWithValue("@PRICE", product.Price);
                cmd.Parameters.AddWithValue("@QUANTITY", product.Quantity);
                cmd.Parameters.AddWithValue("@ID_CATEGORIES", product.Id_categories);
                cmd.Parameters.AddWithValue("@ID_BRANDS", product.Id_brands);
                cmd.Parameters.AddWithValue("@CREATED_AT", product.Created_Date);
                cmd.ExecuteNonQuery();
            }
            catch
            {
                throw;
            }
            finally
            {
                _sqlConnection.Close();
            }
        }
        public DataSet AllBrand()
        {
            DataSet ds = new DataSet();
            try
            {
                if (ConnectionState.Closed == _sqlConnection.State)
                {
                    _sqlConnection.Open();
                }
                SqlCommand cmd = new SqlCommand("Sp_SelectBrand", _sqlConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
            }
            catch
            {
                throw;
            }
            finally
            {
                _sqlConnection.Close();
            }
            return ds;
        }
        public DataSet AllCategory()
        {
            DataSet ds = new DataSet();
            try
            {
                if (ConnectionState.Closed == _sqlConnection.State)
                {
                    _sqlConnection.Open();
                }
                SqlCommand cmd = new SqlCommand("Sp_SelectCategory", _sqlConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
            }
            catch
            {
                throw;
            }
            finally
            {
                _sqlConnection.Close();
            }
            return ds;
        }
        public void DeleteProduct(int? id)
        {
            SqlCommand cmd = new SqlCommand("Sp_DeleteProduct", _sqlConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ID", id);
            _sqlConnection.Open();
            cmd.ExecuteReader();
            _sqlConnection.Close();

        }
        public DataTable ProductJoinBrand()
        {
            DataTable dt = new DataTable();
            try
            {
                if (ConnectionState.Closed == _sqlConnection.State)
                {
                    _sqlConnection.Open();
                }
               
                SqlCommand cmd = new SqlCommand("Sp_ProductJoinBrand", _sqlConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader rd = cmd.ExecuteReader();
                dt.Load(rd);
            }
            catch
            {
                throw;
            }
            finally
            {
                _sqlConnection.Close();
            }
            return dt;
           
        }






        //K thoong qua BLL
        public IEnumerable<Product> GetAllProduct()
        {
            List<Product> listProduct = new List<Product>();
            using (_sqlConnection)
            {
                SqlCommand cmd = new SqlCommand("Sp_SelectProduct", _sqlConnection);
                cmd.CommandType = CommandType.StoredProcedure;

                _sqlConnection.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    Product product = new Product();
                    product.Id = Convert.ToInt32(sdr["id"]);
                    product.Name = sdr["name"].ToString();
                    product.Quantity = string.IsNullOrEmpty(sdr["quantity"].ToString()) ? 0 : Convert.ToInt32(sdr["quantity"]);
                    product.Price = string.IsNullOrEmpty(sdr["price"].ToString()) ? 0 : float.Parse(sdr["price"].ToString());
                    product.Id_brands = string.IsNullOrEmpty(sdr["id_brands"].ToString()) ? 0 : Convert.ToInt32(sdr["id_brands"]);
                    product.Id_categories = string.IsNullOrEmpty(sdr["id_categories"].ToString()) ? 0 : Convert.ToInt32(sdr["id_categories"]);
                    product.Created_Date = string.IsNullOrEmpty(sdr["CreatedAt"].ToString()) ? DateTime.Now : DateTime.Parse(sdr["CreatedAt"].ToString());
                    listProduct.Add(product);
                }
                _sqlConnection.Close();
            }
            return listProduct;
        }
        public void AddProduct(Product product)
        {
            using (_sqlConnection)
            {
                SqlCommand cmd = new SqlCommand("Sp_AddProduct", _sqlConnection);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@NAME", product.Name);
                cmd.Parameters.AddWithValue("@PRICE", product.Price);
                cmd.Parameters.AddWithValue("@QUANTITY", product.Quantity);
                cmd.Parameters.AddWithValue("@ID_CATEGORIES", product.Id_categories);
                cmd.Parameters.AddWithValue("@ID_BRANDS", product.Id_brands);
                cmd.Parameters.AddWithValue("@CREATED_AT", product.Created_Date);

                _sqlConnection.Open();
                cmd.ExecuteNonQuery();
                _sqlConnection.Close();
            }
        }
        public void UpdateProduct123(Product product)
        {
            using (_sqlConnection)
            {
                SqlCommand cmd = new SqlCommand("Sp_UpdateProduct", _sqlConnection);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@ID", product.Id);
                cmd.Parameters.AddWithValue("@NAME", product.Name);
                cmd.Parameters.AddWithValue("@PRICE", product.Price);
                cmd.Parameters.AddWithValue("@QUANTITY", product.Quantity);
                cmd.Parameters.AddWithValue("@ID_CATEGORIES", product.Id_categories);
                cmd.Parameters.AddWithValue("@ID_BRANDS", product.Id_brands);
                cmd.Parameters.AddWithValue("@CREATED_AT", product.Created_Date);

                _sqlConnection.Open();
                cmd.ExecuteNonQuery();
                _sqlConnection.Close();
            }
        }
        public Product GetProductById2(int? id)
        {
            Product product = new Product();

            SqlCommand cmd = new SqlCommand("Sp_GetIdProduct", _sqlConnection);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@ID", id);
            _sqlConnection.Open();
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

                _sqlConnection.Close();
            }
            return product;
        }
        
        public DataSet SelectBrand()
        {
            using (_sqlConnection)
            {
                DataSet ds = new DataSet();
                try
                {
                    _sqlConnection.Open();
                    SqlCommand command = new SqlCommand("Sp_SelectBrand", _sqlConnection);
                    command.CommandType = CommandType.StoredProcedure;

                    SqlDataAdapter da = new SqlDataAdapter(command);
                    da.Fill(ds);
                    _sqlConnection.Close();
                    return ds;
                }
                catch
                {
                    _sqlConnection.Close();
                    return ds;
                }
            }
        }
        public DataSet SelectCate()
        {
            using (_sqlConnection)
            {
                DataSet ds = new DataSet();
                try
                {
                    _sqlConnection.Open();
                    SqlCommand sqlCommand = new SqlCommand("Sp_SelectCategory", _sqlConnection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
                    adapter.Fill(ds);
                    _sqlConnection.Close();
                    return ds;
                }
                catch
                {
                    _sqlConnection.Close();
                    return ds;
                }
            }
        }

        public void ExecuteStoredProcedure(string Sp_AddProduct, Product product)
        {
            var parameters = GenerateSQLParameters(product);
            //SqlConnection sqlConnObj = new SqlConnection(_);

            SqlCommand sqlCmd = new SqlCommand("Sp_AddProduct", _sqlConnection);
            sqlCmd.CommandType = CommandType.StoredProcedure;

            foreach (var param in parameters)
            {
                sqlCmd.Parameters.Add(param);
            }

            _sqlConnection.Open();
            sqlCmd.ExecuteNonQuery();
            _sqlConnection.Close();
        }
        private List<SqlParameter> GenerateSQLParameters(Product product)
        {
            var paramList = new List<SqlParameter>();
            Type modelType = product.GetType();
            var properties = modelType.GetProperties();
            foreach (var property in properties)
            {
                if (property.GetValue(product) == null)
                {
                    paramList.Add(new SqlParameter(property.Name, DBNull.Value));
                }
                else
                {
                    paramList.Add(new SqlParameter(property.Name, property.GetValue(product)));
                }
            }
            return paramList;

        }
    }
}
