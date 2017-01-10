using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LRezLib.Connections
{
    class DB
    {
        private static string ConnectionString
        {
            get
            {
                return ConfigurationManager.ConnectionStrings["LRezDB"].ConnectionString;
            }
        }

        public static DataTable query(string sql)
        {
            SqlConnection conn = new SqlConnection(ConnectionString);
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);

            DataTable dt = new DataTable();
            try
            {
                conn.Open();
                da.Fill(dt);
            }
            catch (Exception e)
            {
                Log.Error(e.Message);
                throw e;
            }
            finally
            {
                if (conn != null && conn.State != ConnectionState.Closed)
                    conn.Close();
                da.Dispose();
            }

            return dt;
        }

        public static DataTable query(string sql, Parameter parameter)
        {
            SqlConnection conn = new SqlConnection(ConnectionString);
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlParameter p = new SqlParameter(parameter.ParameterName, parameter.Value);
            cmd.Parameters.AddWithValue(parameter.ParameterName, parameter.Value);
            SqlDataAdapter da = new SqlDataAdapter(cmd);

            DataTable dt = new DataTable();
            try
            {
                conn.Open();
                da.Fill(dt);
            }
            catch (Exception e)
            {
                Log.Error(e.Message);
                throw e;
            }
            finally
            {
                if (conn != null && conn.State != ConnectionState.Closed)
                    conn.Close();
                da.Dispose();
            }

            return dt;
        }

        public static DataTable query(string sql, List<Parameter> parameters)
        {
            SqlConnection conn = new SqlConnection(ConnectionString);
            SqlCommand cmd = new SqlCommand(sql, conn);
            foreach (Parameter p in parameters)
                cmd.Parameters.AddWithValue(p.ParameterName, p.Value);
            SqlDataAdapter da = new SqlDataAdapter(cmd);

            DataTable dt = new DataTable();
            try
            {
                conn.Open();
                da.Fill(dt);
            }
            catch (Exception e)
            {
                Log.Error(e.Message);
                throw e;
            }
            finally
            {
                if (conn != null && conn.State != ConnectionState.Closed)
                    conn.Close();
                da.Dispose();
            }

            return dt;
        }

        public static int execute(string sql)
        {
            SqlConnection conn = new SqlConnection(ConnectionString);
            SqlCommand cmd = new SqlCommand(sql, conn);
            int result = -1;

            try
            {
                conn.Open();
                result = cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Log.Error(e.Message);
                throw e;
            }
            finally
            {
                if (conn != null && conn.State != ConnectionState.Closed)
                    conn.Close();
            }

            return result;
        }

        public static int execute(string sql, Parameter parameter)
        {
            SqlConnection conn = new SqlConnection(ConnectionString);
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue(parameter.ParameterName, parameter.Value);
            int result = -1;

            try
            {
                conn.Open();
                result = cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Log.Error(e.Message);
                throw e;
            }
            finally
            {
                if (conn != null && conn.State != ConnectionState.Closed)
                    conn.Close();
            }

            return result;
        }

        public static int execute(string sql, List<Parameter> parameters)
        {
            SqlConnection conn = new SqlConnection(ConnectionString);
            SqlCommand cmd = new SqlCommand(sql, conn);
            foreach (Parameter p in parameters)
                cmd.Parameters.AddWithValue(p.ParameterName, p.Value);
            int result = -1;

            try
            {
                conn.Open();
                result = cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Log.Error(e.Message);
                throw e;
            }
            finally
            {
                if (conn != null && conn.State != ConnectionState.Closed)
                    conn.Close();
            }

            return result;
        }

    }
}
