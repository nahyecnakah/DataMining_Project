using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace WebFW
{
    class Helper
    {
        string constr;

        public Helper()
        {
            this.constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        }

        public Helper(string constr)
        {
            this.constr = constr;
        }


        public int myExecuteNonQuery(string sqlstr, CommandType type, SqlParameter[] paramdizi)
        {
            SqlConnection conn = new SqlConnection(constr);
            SqlCommand cmd = new SqlCommand(sqlstr, conn);
            cmd.CommandType = type;
            if (paramdizi != null)
            {
                cmd.Parameters.AddRange(paramdizi);

            }

            try
            {
                if (conn.State != ConnectionState.Open)
                    conn.Open();
                int sayi = cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
                return sayi;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                if (conn.State != ConnectionState.Closed)
                    conn.Close();
            }
        }

        public int myExecuteNonQuery(string sqlstr, CommandType type, SqlParameter param)
        {
            SqlConnection conn = new SqlConnection(constr);
            SqlCommand cmd = new SqlCommand(sqlstr, conn);
            cmd.CommandType = type;
            if (param != null)
            {
                cmd.Parameters.Add(param);

            }

            try
            {
                if (conn.State != ConnectionState.Open)
                    conn.Open();
                int sayi = cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
                return sayi;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                if (conn.State != ConnectionState.Closed)
                    conn.Close();
            }
        }

        public object myExecuteScalar(string sqlstr, CommandType type, SqlParameter[] paramdizi)
        {
            SqlConnection conn = new SqlConnection(constr);
            SqlCommand cmd = new SqlCommand(sqlstr, conn);
            cmd.CommandType = type;
            if (paramdizi != null)
            {
                cmd.Parameters.AddRange(paramdizi);
            }

            try
            {
                if (conn.State != ConnectionState.Open)
                    conn.Open();
                return cmd.ExecuteScalar();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                if (conn.State != ConnectionState.Closed)
                    conn.Close();
            }
        }

        public SqlDataReader myExecuteReader(string sqlstr, CommandType type, SqlParameter[] paramdizi)
        {
            SqlConnection conn = new SqlConnection(constr);
            SqlCommand cmd = new SqlCommand(sqlstr, conn);
            cmd.CommandType = type;
            if (paramdizi != null)
            {
                cmd.Parameters.AddRange(paramdizi);
            }

            try
            {
                if (conn.State != ConnectionState.Open)
                    conn.Open();
                return cmd.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch (SqlException ex)
            {
                throw ex;
            }

        }
    }
}
