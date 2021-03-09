using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace BLL.Common
{
    class GetParam
    {
        private readonly IConfiguration configuration;
        private readonly string _strConn;
        private const string __DEFAULT_CONN = "DB_3Tier";
        private readonly SqlConnection _sqlConnection;

        public GetParam(IConfiguration config)
        {
            this.configuration = config;
            _strConn = configuration.GetConnectionString(__DEFAULT_CONN);
            _sqlConnection = new SqlConnection(_strConn);
        }
        private List<SqlParameter> GenerateSQLParameters(object model)
        {
            var paramList = new List<SqlParameter>();
            Type modelType = model.GetType();
            var properties = modelType.GetProperties();
            foreach (var property in properties)
            {
                if (property.GetValue(model) == null)
                {
                    paramList.Add(new SqlParameter(property.Name, DBNull.Value));
                }
                else
                {
                    paramList.Add(new SqlParameter(property.Name, property.GetValue(model)));
                }
            }
            return paramList;

        }
        public void ExecuteStoredProcedure(string procedureName, object model)
        {
            var parameters = GenerateSQLParameters(model);
            SqlConnection sqlConnObj = new SqlConnection(_strConn);

            SqlCommand sqlCmd = new SqlCommand(procedureName, sqlConnObj);
            sqlCmd.CommandType = CommandType.StoredProcedure;

            foreach (var param in parameters)
            {
                sqlCmd.Parameters.Add(param);
            }

            sqlConnObj.Open();
            sqlCmd.ExecuteNonQuery();
            sqlConnObj.Close();
        }
    }
}
