using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace BookShopDAL
{
    public class SqlHelper
    {
        private static readonly string connStr = ConfigurationManager.ConnectionStrings["sqlConnStr"].ConnectionString;

        /// <summary>
        /// 查询：DataTable
        /// </summary>
        /// <param name="sqlStr"></param>
        /// <param name="sqlParams"></param>
        /// <returns></returns>
        public static DataTable ExcuteDataTable(string sqlStr, SqlParameter[] sqlParams)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                using (SqlCommand cmd = new SqlCommand(sqlStr, conn))
                {
                    if (sqlParams != null)
                        cmd.Parameters.AddRange(sqlParams);
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                        return dt;
                    }
                }
            }
        }
        
        /// <summary>
        /// 查询：DataReader(Command.ExecuteReader)
        /// </summary>
        /// <param name="sqlStr"></param>
        /// <param name="sqlParams"></param>
        /// <returns></returns>
        public static SqlDataReader ExcuteReader(string sqlStr, SqlParameter[] sqlParams)
        {
            SqlConnection conn = new SqlConnection(connStr);
            SqlCommand cmd = new SqlCommand(sqlStr,conn);
            try
            {
                if(sqlParams!=null)
                    cmd.Parameters.AddRange(sqlParams);
                conn.Open();
                return cmd.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// 查询:Object(Command.ExecuteScalar)
        /// </summary>
        /// <param name="sqlStr"></param>
        /// <param name="sqlParams"></param>
        /// <returns></returns>

        public static Object ExecuteScalar(string sqlStr, SqlParameter[] sqlParams)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                using (SqlCommand cmd = new SqlCommand(sqlStr, conn))
                {
                    cmd.Parameters.AddRange(sqlParams);
                    conn.Open();
                    return cmd.ExecuteScalar();
                }
            }
        }

        /// <summary>
        /// 编辑：int（Command.ExecuteNonQuery）
        /// </summary>
        /// <param name="sqlStr"></param>
        /// <param name="sqlParams"></param>
        /// <returns></returns>

        public static int ExecuteNonQuery(string sqlStr, SqlParameter[] sqlParams)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                using (SqlCommand cmd = new SqlCommand(sqlStr, conn))
                {
                    cmd.Parameters.AddRange(sqlParams);
                    conn.Open();
                    return cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
