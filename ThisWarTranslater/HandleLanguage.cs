using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Data;
using MySql.Data.MySqlClient;
using MySql.Data;

namespace ThisWarTranslater
{
    class HandleLanguage
    {
        public static int m_fileCount = 0;
        public static int m_fileIndex = 0;
        public static string m_fileField = "";
        public static DataSet m_mainDataSet = null;

        public static MemoryStream[] m_uzipStream = null;

        public static MemoryStream m_nounStream = null;
        public static MemoryStream m_languageStream = null;

        public static int m_lengthNoun = 0;
        public static int m_deviatNoun = 0;
        public static int m_countsNoun = 0;

        public static int m_lengthLanguage = 0;
        public static int m_countsLanguage = 0;

        public static List<int> m_nounIndex = new List<int>();
        public static List<int> m_nounNouns = new List<int>();

        public static int[] m_lengthHash = null;

        public static int m_databaseColumn = 0;
        public static int m_databaseRows = 0;
        public static List<int> m_databaseID = new List<int>();
        public static List<string> m_databaseNoun = new List<string>();

        /// <summary>
        /// 准备数据库数据，为类成员变量提供以下数据
        ///     数据表集  提供数据库数据表集合
        ///     泛型集合  提供名词编号及对应名词的两个泛型集合
        /// </summary>
        /// <param name="mainForm"></param>
        /// <returns>查询到的记录数量</returns>
        public static string dataPreparation(ThisWarTranslaterMain mainForm)
        {
            m_mainDataSet = HandleDatabase.LoadDatabase(string.Format("select * from {0};", mainForm.textDataTable.Text));
            m_databaseColumn = m_mainDataSet.Tables[0].Columns.Count;
            m_databaseRows= m_mainDataSet.Tables[0].Rows.Count;

            for (int i = 0; i < m_mainDataSet.Tables[0].Rows.Count; i++)
            {
                m_databaseID.Add(int.Parse(m_mainDataSet.Tables[0].Rows[i]["id"].ToString()));
                m_databaseNoun.Add(m_mainDataSet.Tables[0].Rows[i]["noun"].ToString().Replace("\0", ""));
            }

            return "查询到的记录数量" + m_mainDataSet.Tables[0].Rows.Count.ToString();
        }

        /// <summary>
        /// 获取HandleFiles类中得到的文件数据，更新列表状态
        /// </summary>
        /// <param name="mainForm"></param>
        public static void dataRefreshing(ThisWarTranslaterMain mainForm)
        {
            m_uzipStream = FilesDecoding.m_uzipStream;
            m_lengthHash = FilesDecoding.m_lengthHash;
            m_fileCount = FilesDecoding.m_fileCount;

            for (int i = 0; i < m_fileCount; i++)
            {
                ListViewItem foundItem = mainForm.hashList.FindItemWithText(m_lengthHash[i].ToString("X8"), true, 0);

                if (foundItem != null)
                {
                    mainForm.hashList.TopItem = foundItem;
                    foundItem.SubItems[2].Text = "已加载";
                }
            }
        }

        /// <summary>
        /// 更新列表状态，为类成员变量提供以下数据
        ///     整型     当前选择的文件内存流编号
        ///     字符串   当前选择的文件在数据库中的字段名
        /// </summary>
        /// <param name="mainForm"></param>
        public static void dataEffective(ThisWarTranslaterMain mainForm)
        {
            if (mainForm.hashList.FocusedItem.SubItems[2].Text == "已加载")
            {
                mainForm.buttonUpdateData.Enabled = true;
            }
            else
            {
                mainForm.buttonUpdateData.Enabled = false;
            }

            m_fileIndex = int.Parse(mainForm.hashList.FocusedItem.SubItems[3].Text);
            m_fileField = mainForm.hashList.FocusedItem.SubItems[4].Text;
        }

        /// <summary>
        /// 解析名词表文件，为类成员变量提供以下数据
        ///     [4字节]   指针位置0开始，存储名词表文件长度
        ///     [4字节]   指针位置4开始，词条编号长度信息存储区偏移值
        ///     [4字节]   指针位置<偏移值>开始，存储词条数量信息
        ///     泛型集合  提供名词编号及对应名词的两个泛型集合
        /// </summary>
        /// <param name="memStreamIndex">需要分析的内存流编号</param>
        /// <returns>内存流当前位置</returns>
        public static long dataNounAnalysis(int memStreamIndex)
        {
            m_nounStream = m_uzipStream[0];
            BinaryReader nounReader = new BinaryReader(m_nounStream);

            m_nounStream.Seek(0, SeekOrigin.Begin);

            byte[] nounLength = new byte[4];
            byte[] nounDeviat = new byte[4];
            byte[] nounCounts = new byte[4];

            nounLength = nounReader.ReadBytes(4);
            m_lengthNoun = (nounLength[0]) + (nounLength[1] << 8) + (nounLength[2] << 16) + (nounLength[3] << 24);

            nounDeviat = nounReader.ReadBytes(4);
            m_deviatNoun = (nounDeviat[0]) + (nounDeviat[1] << 8) + (nounDeviat[2] << 16) + (nounDeviat[3] << 24);

            m_nounStream.Position = m_deviatNoun + 8;

            nounCounts = nounReader.ReadBytes(4);
            m_countsNoun = (nounCounts[0]) + (nounCounts[1] << 8) + (nounCounts[2] << 16) + (nounCounts[3] << 24);

            byte[] nounIndex = new byte[4];
            byte[] nounNouns = new byte[4];

            for (int i = 0; i < m_countsNoun; i++)
            {
                nounIndex = nounReader.ReadBytes(4);
                m_nounIndex.Add((nounIndex[0]) + (nounIndex[1] << 8) + (nounIndex[2] << 16) + (nounIndex[3] << 24));

                nounNouns = nounReader.ReadBytes(4);
                m_nounNouns.Add((nounNouns[0]) + (nounNouns[1] << 8) + (nounNouns[2] << 16) + (nounNouns[3] << 24));
            }
            return m_nounStream.Position + 2;
        }


        public static void dataNounTable(ThisWarTranslaterMain mainForm)
        {
            long tempPosition = dataNounAnalysis(0);
            BinaryReader nounReader = new BinaryReader(m_nounStream);

            mainForm.progressBar.Minimum = 0;
            mainForm.progressBar.Maximum = m_countsNoun * 2;

            mainForm.progressBar.Value = 0;

            //更新名词表字段
            for (int i = 0; i < m_countsNoun; i++)
            {
                m_nounStream.Seek(m_nounNouns[i] + 8, SeekOrigin.Begin);

                byte tempNoun = 0;
                string strNoun = "";
                string strUpdate = "";
                string strTemp = "";

                do
                {
                    tempNoun = nounReader.ReadByte();
                    strNoun = strNoun + (char)tempNoun;
                } while (tempNoun != 0);

                for (int j = 2; j < m_databaseColumn; j++)
                {
                    strTemp = strTemp + @",''";
                }

                if (m_databaseID.Contains(m_nounIndex[i]))
                    strUpdate = string.Format("UPDATE {0} SET noun='{1}' WHERE id='{2}';", mainForm.textDataTable.Text, strNoun, m_nounIndex[i]);
                else
                    strUpdate = string.Format("INSERT INTO {0} VALUES ({1},'{2}'{3});", mainForm.textDataTable.Text, m_nounIndex[i], strNoun, strTemp);

                HandleDatabase.SaveDatabase(strUpdate);

                mainForm.progressBar.Value = i;
            }

            //更新名词表标记位字段
            m_nounStream.Seek(tempPosition, SeekOrigin.Begin);
            for (int i = 0; i < m_countsNoun; i++)
            {
                byte tempSign = 0;
                string strNoun = "";

                do
                {
                    tempSign = nounReader.ReadByte();
                } while (tempSign == 0);

                strNoun = strNoun + (char)tempSign;

                do
                {
                    tempSign = nounReader.ReadByte();
                    strNoun = strNoun + (char)tempSign;
                } while (tempSign != 0);

                strNoun = strNoun.Replace("'", "''");
                string strUpdate = string.Format("UPDATE {0} SET sign='{1}' WHERE id='{2}';", mainForm.textDataTable.Text, strNoun, i);
                HandleDatabase.SaveDatabase(strUpdate);

                mainForm.progressBar.Value = m_countsNoun + i;
            }
            mainForm.progressBar.Value = 0;
        }

        /// <summary>
        /// 解析语言文件，为类成员变量提供以下数据
        ///     [4字节]   指针位置0开始，存储语言文件长度
        ///     [4字节]   指针位置4开始，存储词条数量信息
        /// <summary>
        /// <param name="memStreamIndex">需要分析的内存流编号</param>
        /// <returns>内存流当前位置</returns>
        public static long dataLanguageAnalysis(int memStreamIndex)
        {
            m_languageStream = m_uzipStream[memStreamIndex];
            BinaryReader languageReader = new BinaryReader(m_languageStream);

            m_languageStream.Seek(0, SeekOrigin.Begin);

            byte[] languageLength = new byte[4];
            byte[] languageCounts = new byte[4];

            languageLength = languageReader.ReadBytes(4);
            m_lengthLanguage = (languageLength[0]) + (languageLength[1] << 8) + (languageLength[2] << 16) + (languageLength[3] << 24);

            languageCounts = languageReader.ReadBytes(4);
            m_countsLanguage = (languageCounts[0]) + (languageCounts[1] << 8) + (languageCounts[2] << 16) + (languageCounts[3] << 24);

            return m_languageStream.Position;
        }


        public static void dataLanguageTable(ThisWarTranslaterMain mainForm)
        {
            long tempPosition = dataLanguageAnalysis(m_fileIndex);
            BinaryReader languageReader = new BinaryReader(m_languageStream);

            string strUpdate = "";
            strUpdate = string.Format("ALTER TABLE {0} ADD COLUMN {1} text;",
                mainForm.textDataTable.Text, m_fileField);
            HandleDatabase.SaveDatabase(strUpdate);

            mainForm.progressBar.Minimum = 0;
            mainForm.progressBar.Maximum = m_countsLanguage;

            mainForm.progressBar.Value = 0;

            byte[] lengthA = new byte[2];
            byte[] lengthB = new byte[2];

            int lengthStrA = 0;
            int lengthStrB = 0;

            for (int i = 0; i < m_countsLanguage; i++)
            {
                byte tempSign = 0;
                int indexLanguage = m_databaseRows;
                string strLanguage = "";
                string strTemp = "";

                lengthA = languageReader.ReadBytes(2);
                lengthStrA = (lengthA[0]) + (lengthA[1] << 8);

                for (int j = 0; j < lengthStrA; j++)
                {
                    tempSign = languageReader.ReadByte();
                    strTemp = strTemp + (char)tempSign;
                }

                for (int j = 0; j < m_databaseRows; j++)
                {
                    if (m_databaseNoun[j] == strTemp)
                    {
                        indexLanguage = j;
                        break;
                    }
                }

                lengthB = languageReader.ReadBytes(2);
                lengthStrB = (lengthB[0]) + (lengthB[1] << 8);

                byte[] languageUnicode = languageReader.ReadBytes(lengthStrB * 2);
                strLanguage = new string(Encoding.Unicode.GetChars(languageUnicode));
                strLanguage = strLanguage.Replace("'", "''");

                strUpdate = string.Format("UPDATE {0} SET {1}='{2}' WHERE id='{3}';",
                    mainForm.textDataTable.Text, m_fileField, strLanguage, indexLanguage);
                HandleDatabase.SaveDatabase(strUpdate);

                mainForm.progressBar.Value = i;
            }

            mainForm.progressBar.Value = 0;
        }
    }
}
