using DAL.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace DAL
{
    public class BrandDAL
    {
        private readonly IConfiguration configuration;
        private readonly string _strConn;
        private const string __DEFAULT_CONN = "DB_3Tier";
        private readonly SqlConnection _sqlConnection;

        public BrandDAL(IConfiguration config)
        {
            this.configuration = config;
            _strConn = configuration.GetConnectionString(__DEFAULT_CONN);
            _sqlConnection = new SqlConnection(_strConn);
        }
        public DataTable GetBrand()
        {
            DataTable dt = new DataTable();

            try
            {
                if (ConnectionState.Closed == _sqlConnection.State)
                {
                    _sqlConnection.Open();
                }
                SqlCommand cmd = new SqlCommand("Sp_SelectBrand", _sqlConnection);
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
        public void AddBrand(Brand brand)
        {
            try
            {
                if (ConnectionState.Closed == _sqlConnection.State)
                {
                    _sqlConnection.Open();
                }
                SqlCommand cmd = new SqlCommand("Sp_AddBrand", _sqlConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@NAME", brand.name);
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
        public void DeleteBrand(int? id)
        {
            try
            {
                if (ConnectionState.Closed == _sqlConnection.State)
                {
                    _sqlConnection.Open();
                }
                SqlCommand cmd = new SqlCommand("Sp_DeleteBrand", _sqlConnection);
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
        public DataTable GetBrandById(int? id)
        {
            DataTable dt = new DataTable();
            try
            {
                if (ConnectionState.Closed == _sqlConnection.State)
                {
                    _sqlConnection.Open();
                }
                SqlCommand cmd = new SqlCommand("Sp_GetIdBrand", _sqlConnection);
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
        public void UpdateBrand(Brand brand)
        {
            try
            {
                if (ConnectionState.Closed == _sqlConnection.State)
                {
                    _sqlConnection.Open();
                }
                SqlCommand cmd = new SqlCommand("Sp_UpdateBrand", _sqlConnection);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@ID", brand.id);
                cmd.Parameters.AddWithValue("@NAME", brand.name);                
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
