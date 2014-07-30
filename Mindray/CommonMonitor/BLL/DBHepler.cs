using System;
using System.Data;
using System.Data.SqlClient;

namespace BLL
{
    class DBHepler
    {
        public DBHepler(string connStr)
        {
            m_connStr = connStr;
        }
        private string m_connStr;

        public DataSet GetProcDS(string procName, params SqlParameter[] sqlParams)
        {
            try
            {
                SqlConnection conn = new SqlConnection(m_connStr);
                SqlCommand comm = new SqlCommand(procName, conn);
                foreach (SqlParameter sqlParam in sqlParams)
                {
                    comm.Parameters.Add(sqlParam);
                }
                comm.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter da = new SqlDataAdapter(comm);
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;
            }
            catch (Exception ee)
            {
            }
            return null;
        }


        public DataSet GetSQLDS(string sql, params SqlParameter[] sqlParams)
        {
            try
            {
                SqlConnection conn = new SqlConnection(m_connStr);
                SqlCommand comm = new SqlCommand(sql, conn);
                foreach (SqlParameter sqlParam in sqlParams)
                {
                    comm.Parameters.Add(sqlParam);
                }
                comm.CommandType = CommandType.Text;

                SqlDataAdapter da = new SqlDataAdapter(comm);
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;
            }
            catch (Exception ee)
            {
                Logger.AddLogMsg(ee.Message);
                Logger.AddLogMsg(sql);
            }
            return null;
        }

    }
}
