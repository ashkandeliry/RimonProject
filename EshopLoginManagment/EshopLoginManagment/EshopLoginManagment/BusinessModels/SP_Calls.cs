using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace DataAccessLayer.GenericRepositoty
{
    public class SP_Calls
    {
        public T ExecUDF_scalar<T>(string UDFName, string[] ParamNames, object[] ParamValues)
        {
            try
            {
                SqlCommand Comm = new SqlCommand();
                Comm.Connection = new SqlConnection("Server=.\\;Database=Ashkandeliry;Trusted_Connection=True;");
                Comm.CommandText = string.Format("SELECT [dbo].[{0}] ({1}) ", UDFName, string.Join(",", ParamNames));
                Comm.Parameters.Clear();

                for (int i = 0; i < ParamNames.Length; i++)
                    Comm.Parameters.AddWithValue(ParamNames[i], ParamValues[i]);

                DataSet ds = new DataSet();
                {
                    new SqlConnection("Server=.\\;Database=Ashkandeliry;Trusted_Connection=True;").Open();
                }

                var result = Comm.ExecuteNonQuery();

                return (T)Convert.ChangeType(
                    result.ToString(), typeof(T));
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
            finally
            {
                new SqlConnection("Server=.\\;Database=Ashkandeliry;Trusted_Connection=True;").Close();
            }
        }
    }
}
