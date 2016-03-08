using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThisWarTranslater.DataManager
{
    /// <summary>
    /// 容纳数据库事件的附加信息
    /// </summary>
    internal class DatabaseEventArgs : EventArgs
    {
        private readonly Boolean m_state;
        private readonly String m_info;

        public DatabaseEventArgs(Boolean state, String info)
        {
            m_state = state;
            m_info = info;
        }

        public Boolean State
        {
            get { return m_state; }
        }
        public String Info
        {
            get { return m_info; }
        }
    }

    /// <summary>
    /// 容纳表格事件的附加信息
    /// </summary>
    internal class ExcelEventArgs : EventArgs
    {
        private readonly Boolean m_state;
        private readonly String m_info;

        public ExcelEventArgs(Boolean state, String info)
        {
            m_state = state;
            m_info = info;
        }

        public Boolean State
        {
            get { return m_state; }
        }
        public String Info
        {
            get { return m_info; }
        }
    }

    /// <summary>
    /// 数据库事件
    /// </summary>
    internal class DatabaseEvents
    {
        public event EventHandler<DatabaseEventArgs> EventCallback;

        protected virtual void OnNewEvent(DatabaseEventArgs e)
        {
            EventHandler<DatabaseEventArgs> temp = Volatile.Read(ref EventCallback);
            if (temp != null)
                temp(this, e);
        }

        public void GetNewEvent(Boolean state, String info)
        {
            DatabaseEventArgs e = new DatabaseEventArgs(state, info);
            OnNewEvent(e);
        }
    }

    /// <summary>
    /// 回调函数
    /// </summary>
    internal class Callbacks
    {
        //设定主界面回调函数
        Action<string> m_changeInfo = Program.m_mainWindow.changeInfo;

        internal void eventDatabase_Info(object sender, DatabaseEventArgs e)
        {
            m_changeInfo(e.Info);
        }

        internal void eventDatabase_Right(object sender, DatabaseEventArgs e)
        {
            m_changeInfo(e.Info);
        }

        internal void eventDatabase_Error(object sender, DatabaseEventArgs e)
        {
            m_changeInfo(e.Info);
        }
    }
}
