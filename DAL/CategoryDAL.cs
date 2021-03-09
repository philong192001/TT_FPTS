using DAL.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace DAL
{
    public class CategoryDAL
    {
        private readonly IConfiguration configuration;
        private readonly string _strConn;
        private const string __DEFAULT_CONN = "DB_3Tier";
        private readonly SqlConnection _sqlConnection;

        public CategoryDAL(IConfiguration config)
        {
            this.configuration = config;
            _strConn = configuration.GetConnectionString(__DEFAULT_CONN);
            _sqlConnection = new SqlConnection(_strConn);
        }
        public DataTable GetCategory()
        {
            DataTable dt = new DataTable();

            try
            {
                if (ConnectionState.Closed == _sqlConnection.State)
                {
                    _sqlConnection.Open();
                }
                SqlCommand cmd = new SqlCommand("Sp_SelectCategory", _sqlConnection);
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
        public void AddCategory(Category category)
        {
            try
            {
                if (ConnectionState.Closed == _sqlConnection.State)
                {
                    _sqlConnection.Open();
                }
                SqlCommand cmd = new SqlCommand("Sp_AddCategory", _sqlConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@NAME", category.name);
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
        public void DeleteCategory(int? id)
        {
            try
            {
                if (ConnectionState.Closed == _sqlConnection.State)
                {
                    _sqlConnection.Open();
                }
                SqlCommand cmd = new SqlCommand("Sp_DeleteCategory", _sqlConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID", id);
                cmd.ExecuteReader();
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
        public DataTable GetCategoryById(int? id)
        {
            DataTable dt = new DataTable();
            try
            {
                if (ConnectionState.Closed == _sqlConnection.State)
                {
                    _sqlConnection.Open();
                }
                SqlCommand cmd = new SqlCommand("Sp_GetIdCategory", _sqlConnection);
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
        public void UpdateCategory(Category category)
        {
            try
            {
                if (ConnectionState.Closed == _sqlConnection.State)
                {
                    _sqlConnection.Open();
                }
                SqlCommand cmd = new SqlCommand("Sp_UpdateCategory", _sqlConnection);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@ID", category.id);
                cmd.Parameters.AddWithValue("@NAME", category.name);
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
    }
}
