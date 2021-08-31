using System;
using System.Collections.Generic;
using DEL;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
namespace DAL
{
    public class UserInfoDAL : IDAL<UserInfo>
    {
        #region Database Objects
        SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString);
        SqlCommand sqlCommand = new SqlCommand();
        SqlDataReader sqlDataReader;
        #endregion
        public bool Delete(object objDel)
        {
            throw new NotImplementedException();
        }

        public List<UserInfo> GetAll()
        {
            throw new NotImplementedException();
        }

        public UserInfo GetById(object objGet)
        {
            throw new NotImplementedException();
        }

        public bool Save(UserInfo entity)
        {
            throw new NotImplementedException();
        }

        public bool Update(object objUpdate)
        {
            throw new NotImplementedException();
        }

        public bool ValidateUser(string email,string password)
        {
            try
            {
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = SP.ValiadateEmployee.ToString();
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Add("@Email", SqlDbType.VarChar, 50).Value = email;
                sqlCommand.Parameters.Add("@pass", SqlDbType.VarChar, 20).Value = password;
                if (sqlConnection.State == ConnectionState.Closed)
                {
                    sqlConnection.Open();
                }
                sqlDataReader = sqlCommand.ExecuteReader();
                if (sqlDataReader.HasRows)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }catch(Exception ex)
            {
                return false;
            }
            finally
            {
                sqlConnection.Close();
            }
        }
    }
}
