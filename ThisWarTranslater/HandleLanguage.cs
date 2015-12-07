using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace ThisWarTranslater
{
    class HandleLanguage
    {
        public static int m_fileCount = 0;

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

        /// <summary>
        /// 解析名词表并载入数据库
        /// </summary>
        /// <param name="mainForm"></param>
        public static void dataNounTable(ThisWarTranslaterMain mainForm)
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

            long tempPosition = m_nounStream.Position + 2;

            mainForm.progressBar.Minimum = 0;
            mainForm.progressBar.Maximum = m_countsNoun * 2;

            mainForm.progressBar.Value = 0;

            //更新名词表字段
            for (int i = 0; i < m_countsNoun; i++)
            {
                m_nounStream.Seek(m_nounNouns[i] + 8, SeekOrigin.Begin);
                byte tempNoun = 0;
                string strNoun = "";
                do
                {
                    tempNoun = nounReader.ReadByte();
                    strNoun = strNoun + (char)tempNoun;

                } while (tempNoun != 0);

                string strUpdate = string.Format("UPDATE {0} SET noun='{1}' WHERE id='{2}';", mainForm.textDataTable.Text, strNoun, m_nounIndex[i]);
                //string strUpdate = string.Format("INSERT INTO {0} VALUES ({1},'{2}');", mainForm.textDataTable.Text, m_nounIndex[i], strNoun);
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
        /// 解析语言文件并载入数据库
        /// </summary>
        /// <param name="mainForm"></param>
        public static void dataLanguageTable(ThisWarTranslaterMain mainForm)
        {
            m_languageStream = m_uzipStream[11];
            BinaryReader languageReader = new BinaryReader(m_languageStream);

            m_languageStream.Seek(0, SeekOrigin.Begin);

            byte[] languageLength = new byte[4];
            byte[] languageCounts = new byte[4];

            languageLength = languageReader.ReadBytes(4);
            m_lengthLanguage = (languageLength[0]) + (languageLength[1] << 8) + (languageLength[2] << 16) + (languageLength[3] << 24);

            languageCounts = languageReader.ReadBytes(4);
            m_countsLanguage = (languageCounts[0]) + (languageCounts[1] << 8) + (languageCounts[2] << 16) + (languageCounts[3] << 24);

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
                string strLanguage = "";

                lengthA = languageReader.ReadBytes(2);
                lengthStrA = (lengthA[0]) + (lengthA[1] << 8);

                for (int j = 0; j < lengthStrA; j++)
                {
                    tempSign = languageReader.ReadByte();
                    //strLanguage = strLanguage + (char)tempSign;   
                }

                lengthB = languageReader.ReadBytes(2);
                lengthStrB = (lengthB[0]) + (lengthB[1] << 8);

                byte[] languageUnicode = languageReader.ReadBytes(lengthStrB * 2);
                strLanguage = new string(Encoding.Unicode.GetChars(languageUnicode));
                strLanguage = strLanguage.Replace("'", "''");

                string strUpdate = string.Format("UPDATE {0} SET lang_jap='{1}' WHERE id='{2}';", mainForm.textDataTable.Text, strLanguage, i);
                HandleDatabase.SaveDatabase(strUpdate);
                
                mainForm.progressBar.Value = i;
            }

            mainForm.progressBar.Value = 0;
        }

        public static void dataRefreshing(ThisWarTranslaterMain mainForm)
        {
            m_uzipStream = HandleFiles.m_uzipStream;
            m_lengthHash = HandleFiles.m_lengthHash;
            m_fileCount = HandleFiles.m_fileCount;

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
        }
    }
}
