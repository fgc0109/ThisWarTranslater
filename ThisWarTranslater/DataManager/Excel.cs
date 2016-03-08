using System;
using System.Data;
using System.Collections;
using MySql.Data.MySqlClient;
using MySql.Data;
using System.Data.OleDb;

namespace ThisWarTranslater.DataManager
{
    public class Excel
    {
        static OleDbConnection dbConnection;

        /// <summary>
        /// 打开数据库
        /// </summary>
        /// <param name="host">主机地址</param>
        /// <param name="port">数据端口</param>
        /// <param name="user">用户名称</param>
        /// <param name="pass">用户密码</param>
        /// <param name="database">数据库名称</param>
        static public string OpenExcel(string filePath)
        {
            //string connectionString = string.Format("Server = {0};port={1};Database = {2}; User ID = {3}; Password = {4};", host, port, database, user, pass);
            string connectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source="
                + filePath
                + ";Extended Properties='Excel 8.0;HDR=False;IMEX=1'";

            try
            {
                dbConnection = new OleDbConnection(connectionString);
                dbConnection.Open();

                return "数据库连接成功!";
            }
            catch (Exception error)
            {
                return "数据库" + filePath + "打开失败!\r\n" + error.Message.ToString();
            }
        }

        /// <summary>
        /// 加载数据库数据至内存
        /// </summary>
        /// <param name="select_string">数据选择字符串</param>
        /// <returns>数据源缓存DataSet</returns>
        static public DataSet LoadExcel(string select_string)
        {
            string strSelect = select_string;

            DataSet local_dataset = new DataSet();
            OleDbDataAdapter local_adapter = new OleDbDataAdapter(strSelect, dbConnection);

            local_adapter.Fill(local_dataset, "data$");

            return local_dataset;
        }
    }
}
