using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Xml.Serialization;

namespace util.lib
{
    internal class Sql
    {
        public SqlConnection Conn { get; set; }

        public Sql()
        {
            Conn = new SqlConnection(Config.ConectionString);
        }
        /// <summary>
        /// 依照Cmd回傳DataTable
        /// </summary>
        /// <returns>DataTable</returns>
        /// <Programmer>Ryan Liang</Programmer>
        public DataTable GetDataTable(SqlCommand Cmd)
        {
            DataSet ds = GetDataSet(Cmd);

            if (ds.Tables.Count > 0)
                return ds.Tables[0];
            else
                return new DataTable();
        }

        /// <summary>
        /// 依照Cmd回傳DataSet
        /// </summary>
        /// <returns>DataSet</returns>
        /// <Programmer>Ryan Liang</Programmer>
        public DataSet GetDataSet(SqlCommand Cmd)
        {
            DataSet ds = new DataSet();
            try
            {
                Conn.Open();
                Cmd.Connection = Conn;
                using (SqlDataAdapter adapter = new SqlDataAdapter(Cmd))
                    adapter.Fill(ds);
            }
            catch (Exception e)
            {
                if (Conn.State == ConnectionState.Open)
                    Conn.Close();
                throw e;
            }
            finally
            {
                if (Conn.State == ConnectionState.Open)
                    Conn.Close();
            }
            return ds;
        }

        /// <summary>
        /// 依照Cmd回傳第一筆值
        /// </summary>
        /// <returns>object</returns>
        /// <Programmer>Ryan Liang</Programmer>
        public object GetSingleValue(SqlCommand Cmd)
        {
            object _result;
            try
            {
                Conn.Open();
                Cmd.Connection = Conn;
                _result = Cmd.ExecuteScalar();
            }
            catch (Exception e)
            {
                if (Conn.State == ConnectionState.Open)
                    Conn.Close();
                throw e;
            }
            finally
            {
                if (Conn.State == ConnectionState.Open)
                    Conn.Close();
            }
            return _result;
        }

        /// <summary>
        /// 執行單筆Cmd
        /// </summary>
        /// <returns>影響的資料筆數</returns>
        public int ExecSQL(SqlCommand Cmd)
        {
            int _Result;
            try
            {
                Conn.Open();
                Cmd.Connection = Conn;
                _Result = Cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                if (Conn.State == ConnectionState.Open)
                    Conn.Close();
                throw e;
            }
            finally
            {
                if (Conn.State == ConnectionState.Open)
                    Conn.Close();
            }
            return _Result;
        }

        /// <summary>
        /// 以Transaction執行多筆Cmds
        /// </summary>
        /// <returns>影響的資料筆數</returns>
        public int ExecSQLs(List<SqlCommand> Cmds)
        {
            int _Result = 0;
            Conn.Open();
            SqlTransaction Trans = Conn.BeginTransaction();
            try
            {
                foreach (SqlCommand Cmd in Cmds)
                {
                    Cmd.Transaction = Trans;
                    Cmd.Connection = Conn;
                    _Result += Cmd.ExecuteNonQuery();
                }
                Trans.Commit();
            }
            catch (Exception e)
            {
                Trans.Rollback();
                if (Conn.State == ConnectionState.Open)
                    Conn.Close();
                throw e;
            }
            finally
            {
                if (Conn.State == ConnectionState.Open)
                    Conn.Close();
            }
            return _Result;
        }

    }
}