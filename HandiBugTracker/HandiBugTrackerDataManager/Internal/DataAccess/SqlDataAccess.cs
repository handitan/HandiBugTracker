using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace HandiBugTrackerDataManager.Internal.DataAccess
{
    public class SqlDataAccess : ISqlDataAccess
    {
        public string GetConnectionString(string pName)
        {
            return ConfigurationManager.ConnectionStrings[pName].ConnectionString;
        }

        public async Task<List<T>> LoadDataAsync<T, U>(string pStoredProcedure, U pParams, string pConnStringName)
        {
            try
            {
                string connString = GetConnectionString(pConnStringName);
                using (IDbConnection conn = new SqlConnection(connString))
                {
                    var result = await conn.QueryAsync<T>(pStoredProcedure, pParams, commandType: CommandType.StoredProcedure);

                    return result.ToList();
                }
            }
            catch (TimeoutException ex)
            {
                throw new Exception(String.Format("{0}.WithConnection() experienced a SQL timeout", GetType().FullName), ex);
            }
            catch (SqlException ex)
            {
                throw new Exception(String.Format("{0}.WithConnection() experienced a SQL exception (not a timeout)", GetType().FullName), ex);
            }
            catch (InvalidOperationException ex)
            {
                throw new Exception(String.Format("{0}.WithConnection() experienced a SQL Invalid operation exception", GetType().FullName), ex);
            }
        }

        public async Task SaveDataAsync<T>(string pStoredProcedure, T pParams, string pConnStringName)
        {
            try
            {
                string connString = GetConnectionString(pConnStringName);
                using (IDbConnection conn = new SqlConnection(connString))
                {
                    await conn.ExecuteAsync(pStoredProcedure, pParams, commandType: CommandType.StoredProcedure);
                }
            }
            catch (TimeoutException ex)
            {
                throw new Exception(String.Format("{0}.WithConnection() experienced a SQL timeout", GetType().FullName), ex);
            }
            catch (SqlException ex)
            {
                throw new Exception(String.Format("{0}.WithConnection() experienced a SQL exception (not a timeout)", GetType().FullName), ex);
            }
            catch (InvalidOperationException ex)
            {
                throw new Exception(String.Format("{0}.WithConnection() experienced a SQL Invalid operation exception", GetType().FullName), ex);
            }
        }
    }
}
