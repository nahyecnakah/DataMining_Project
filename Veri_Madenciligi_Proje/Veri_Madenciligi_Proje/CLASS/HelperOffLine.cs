using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace WebFW.CLASS
{
    public class HelperOffLine
    {
        string constr;

        public HelperOffLine()
        {
            this.constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        }

        public HelperOffLine(string constr)
        {
            this.constr = constr;
        }

        public DataSet getDataset(string sqlstr, CommandType type, string dtName)
        {
            try
            {
                SqlConnection conn = new SqlConnection(constr);
                SqlCommand cmd = new SqlCommand(sqlstr, conn);
                cmd.CommandType = type;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                SqlCommandBuilder cb = new SqlCommandBuilder(da);
                DataSet ds = new DataSet();

                da.Fill(ds, dtName);
                return ds;
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                return null;
            }
            
        }


        public DataSet getDatasetWithParameter(string sqlstr, CommandType type, string dtName, SqlParameter[] paramdizi)
        {
            try
            {
                SqlConnection conn = new SqlConnection(constr);
                SqlCommand cmd = new SqlCommand(sqlstr, conn);
                cmd.CommandType = type;

                if (paramdizi != null)
                {
                    cmd.Parameters.AddRange(paramdizi);
                }

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                SqlCommandBuilder cb = new SqlCommandBuilder(da);
                DataSet ds = new DataSet();

                da.Fill(ds, dtName);
                return ds;
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                return null;
            }

        }
    }
}
