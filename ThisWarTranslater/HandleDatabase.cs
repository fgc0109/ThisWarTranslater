using System;
using System.Data;
using System.Collections;
using MySql.Data.MySqlClient;
using MySql.Data;

public class HandleDatabase
{
    static MySqlConnection dbConnection;

    /// <summary>
    /// 打开数据库
    /// </summary>
    /// <param name="host">主机地址</param>
    /// <param name="port">数据端口</param>
    /// <param name="user">用户名称</param>
    /// <param name="pass">用户密码</param>
    /// <param name="database">数据库名称</param>
    static public string OpenDatabase(string host, string port, string user, string pass, string database)
    {
        string connectionString = string.Format("Server = {0};port={1};Database = {2}; User ID = {3}; Password = {4};", host, port, database, user, pass);

        try
        {
            dbConnection = new MySqlConnection(connectionString);
            dbConnection.Open();

            return "数据库连接成功!";
        }
        catch (Exception error)
        {
            return "数据库" + database + "打开失败!\r\n" + error.Message.ToString();
        }
    }

    /// <summary>
    /// 加载数据库数据至内存
    /// </summary>
    /// <returns>数据源缓存DataSet</returns>
    static public DataSet LoadDatabase()
    {
        string strSelect = "select * from skilldata_npc;";

        DataSet local_dataset = new DataSet();
        MySqlDataAdapter local_adapter = new MySqlDataAdapter(strSelect, dbConnection);

        local_adapter.Fill(local_dataset);

        return local_dataset;
    }

    /// <summary>
    /// 加载数据库数据至内存
    /// </summary>
    /// <param name="select_string">数据选择字符串</param>
    /// <returns>数据源缓存DataSet</returns>
    static public DataSet LoadDatabase(string select_string)
    {
        string strSelect = select_string;

        DataSet local_dataset = new DataSet();
        MySqlDataAdapter local_adapter = new MySqlDataAdapter(strSelect, dbConnection);

        local_adapter.Fill(local_dataset);

        return local_dataset;
    }

    /// <summary>
    /// 将内存数据保存至数据库
    /// </summary>
    /// <param name="update_string">数据库命令字符串</param>
    static public void SaveDatabase(string update_string)
    {
        MySqlCommand m_command = dbConnection.CreateCommand();
        m_command.CommandText = update_string;
        m_command.ExecuteNonQuery();
    }
}
