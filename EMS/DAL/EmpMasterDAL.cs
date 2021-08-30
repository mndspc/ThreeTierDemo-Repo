using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using DEL;
using System.Data;
namespace DAL
{
  public  class EmpMasterDAL : IDAL<EmpMaster>
    {
        #region Database Objects
        SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString);
        SqlCommand sqlCommand = new SqlCommand();
        SqlDataReader sqlDataReader;
        #endregion
        public bool Delete(object objDel)
        {
            try
            {
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = SP.DeleteEmployee.ToString();
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Add("@EmpCode", SqlDbType.Int).Value =Convert.ToInt32 (objDel);
                if (sqlConnection.State == System.Data.ConnectionState.Closed)
                {
                    sqlConnection.Open();
                }
                sqlCommand.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                sqlConnection.Close();
            }
        }

        public List<EmpMaster> GetAll()
        {
            throw new NotImplementedException();
        }

        public EmpMaster GetById(object objGet)
        {
            throw new NotImplementedException();
        }

        public bool Save(EmpMaster entity)
        {
            try
            {
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = SP.SaveEmployee.ToString();
                sqlCommand.Parameters.Add("@EmpCode", SqlDbType.Int).Value = entity.EmpCode;
                sqlCommand.Parameters.Add("@EmpName", SqlDbType.VarChar, 50).Value = entity.EmpName;
                sqlCommand.Parameters.Add("@DateOfBirth", SqlDbType.DateTime).Value = entity.DateOfBirth;
                sqlCommand.Parameters.Add("@Email", SqlDbType.VarChar, 50).Value = entity.Email;
                sqlCommand.Parameters.Add("@DeptCode", SqlDbType.Int).Value = entity.DeptCode;
                sqlCommand.CommandType = CommandType.StoredProcedure;
                if (sqlConnection.State == ConnectionState.Closed)
                {
                    sqlConnection.Open();
                }
                sqlCommand.ExecuteNonQuery();
                return true;
            }
            catch (SqlException ex)
            {           
                return false;
            }
            finally
            {
                sqlConnection.Close();
            }
        }

        public bool Update(object objUpdate)
        {
            throw new NotImplementedException();
        }
    }
}
