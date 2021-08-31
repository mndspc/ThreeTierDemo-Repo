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

        public List<EmpMaster> GetByName(string EmpName)
        {
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
            DataSet ds = new DataSet();
            List<EmpMaster> empList = new List<EmpMaster>();
            try
            {
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = "Select * from EmpMaster where EmpName='" + EmpName + "' ";
                sqlCommand.CommandType = CommandType.Text;
                sqlDataAdapter.SelectCommand = sqlCommand;
                sqlDataAdapter.Fill(ds, "Emp");
                if (ds.Tables["Emp"].Rows.Count > 0)
                {
                    foreach(DataRow dataRow in ds.Tables["Emp"].Rows)
                    {
                        EmpMaster empMaster = new EmpMaster();
                        empMaster.EmpCode = Convert.ToInt32(dataRow["EmpCode"]);
                        empMaster.EmpName = Convert.ToString(dataRow["EmpName"]);
                        empMaster.DateOfBirth = DateTime.Parse(dataRow["DateOfBirth"].ToString());
                        empMaster.Email = Convert.ToString(dataRow["Email"]);
                        empMaster.DeptCode = Convert.ToInt32(dataRow["DeptCode"]);
                        empList.Add(empMaster);
                    }
                }
                return empList;
            }catch(Exception ex)
            {
                return empList;
            }
            finally
            {
                sqlConnection.Close();
            }
        }
    }
}
