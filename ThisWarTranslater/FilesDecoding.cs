using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.IO.Compression;
using System.Windows.Forms;

namespace ThisWarTranslater
{
    class FilesDecoding
    {
        public static MemoryStream m_idxStream = null;
        public static MemoryStream m_datStream = null;
        public static MemoryStream[] m_zipStream = null;
        public static MemoryStream[] m_uzipStream = null;

        public static DeflateStream[] m_defStream = null;
        public static GZipStream[] m_gzipStream = null;

        public static byte[] m_idxHeader = new byte[3];
        public static byte[] m_idxCounts = new byte[4];
        public static byte[] m_idxUnknow = new byte[4];

        public static int m_fileCount = 0;
        public static int[] m_lengthHash = null;
        public static int[] m_lengthBefore = null;
        public static int[] m_lengthAfters = null;
        public static int[] m_lengthDeviat = null;

        public static List<byte[]> m_idxHash = new List<byte[]>();
        public static List<byte[]> m_idxBefore = new List<byte[]>();
        public static List<byte[]> m_idxAfters = new List<byte[]>();
        public static List<byte[]> m_idxDeviat = new List<byte[]>();
        public static List<byte[]> m_idxEnding = new List<byte[]>();

        public static void FileLoad(ThisWarTranslaterMain mainForm)
        {
            try
            {
                byte[] idxData = File.ReadAllBytes(mainForm.filePath.Text + ".idx");
                m_idxStream = new MemoryStream(idxData);
            }
            catch (Exception e)
            {
                mainForm.textDebug.Text = mainForm.textDebug.Text + "\r\n" + e.ToString();
            }

            try
            {
                byte[] datData = File.ReadAllBytes(mainForm.filePath.Text + ".dat");
                m_datStream = new MemoryStream(datData);
            }
            catch (Exception e)
            {
                mainForm.textDebug.Text = mainForm.textDebug.Text + "\r\n" + e.ToString();
            }
        }

        public static void DataUnpacking(ThisWarTranslaterMain mainForm)
        {
            try
            {
                BinaryReader idxReader = new BinaryReader(m_idxStream);

                m_idxHeader = idxReader.ReadBytes(3);
                m_idxCounts = idxReader.ReadBytes(4);
                m_idxUnknow = idxReader.ReadBytes(4);

                m_fileCount = (m_idxCounts[0]) + (m_idxCounts[1] << 8) + (m_idxCounts[2] << 16) + (m_idxCounts[3] << 24);

                m_lengthHash = new int[m_fileCount];
                m_lengthBefore = new int[m_fileCount];
                m_lengthAfters = new int[m_fileCount];
                m_lengthDeviat = new int[m_fileCount];

                for (int i = 0; i < m_fileCount; i++)
                {
                    m_idxHash.Add(idxReader.ReadBytes(4));
                    m_idxBefore.Add(idxReader.ReadBytes(4));
                    m_idxAfters.Add(idxReader.ReadBytes(4));
                    m_idxDeviat.Add(idxReader.ReadBytes(4));
                    m_idxEnding.Add(idxReader.ReadBytes(1));
                }
            }
            catch (Exception e)
            {
                mainForm.textDebug.Text = mainForm.textDebug.Text + "\r\n" + e.ToString();
            }

            //尝试读取DAT文件
            try
            {
                BinaryReader datReader = new BinaryReader(m_datStream);
                m_zipStream = new MemoryStream[m_fileCount];

                for (int i = 0; i < m_fileCount; i++)
                {
                    byte[] datBefore = m_idxBefore[i];
                    m_lengthBefore[i] = (datBefore[0]) + (datBefore[1] << 8) + (datBefore[2] << 16) + (datBefore[3] << 24);

                    byte[] datDeviat = m_idxDeviat[i];
                    m_lengthDeviat[i] = (datDeviat[0]) + (datDeviat[1] << 8) + (datDeviat[2] << 16) + (datDeviat[3] << 24);

                    m_datStream.Seek(0, SeekOrigin.Begin);
                    m_datStream.Position = m_lengthDeviat[i];

                    m_zipStream[i] = new MemoryStream(datReader.ReadBytes(m_lengthBefore[i]));
                }
            }
            catch (Exception e)
            {
                mainForm.textDebug.Text = mainForm.textDebug.Text + "\r\n" + e.ToString();
            }
        }

        /// <summary>
        /// 文件解压缩并读取至相应的内存流
        /// </summary>
        /// <param name="mainForm"></param>
        public static void DataUncompress(ThisWarTranslaterMain mainForm)
        {
            m_defStream = new DeflateStream[m_fileCount];
            m_uzipStream = new MemoryStream[m_fileCount];

            BinaryReader[] zipReader = new BinaryReader[m_fileCount];

            mainForm.progressBar.Minimum = 0;
            mainForm.progressBar.Maximum = m_fileCount;

            mainForm.progressBar.Value = 0;
            for (int i = 0; i < m_fileCount; i++)
            {
                byte[] datHash = m_idxHash[i];
                m_lengthHash[i] = (datHash[0]) + (datHash[1] << 8) + (datHash[2] << 16) + (datHash[3] << 24);

                byte[] datAfter = m_idxAfters[i];
                m_lengthAfters[i] = (datAfter[0]) + (datAfter[1] << 8) + (datAfter[2] << 16) + (datAfter[3] << 24);

                //准备处理内存流数据
                zipReader[i] = new BinaryReader(m_zipStream[i]);
                //移动至压缩文件内容部分
                zipReader[i].ReadBytes(10);
                //去除压缩文件结尾
                m_zipStream[i].SetLength(m_zipStream[i].Length - 4);

                m_defStream[i] = new DeflateStream(m_zipStream[i], CompressionMode.Decompress,true);

                m_uzipStream[i] = new MemoryStream();
                m_defStream[i].CopyTo(m_uzipStream[i]);

                mainForm.progressBar.Value = i;
            }
            mainForm.progressBar.Value = 0;
        }

        /// <summary>
        /// 信息显示和更新
        /// </summary>
        /// <param name="mainForm"></param>
        public static void InfoPrint(ThisWarTranslaterMain mainForm)
        {
            mainForm.textDebug.Text = mainForm.textDebug.Text + "\r\n[信息]获取到的文件数量为：" + m_fileCount;

            //数据更新UI暂时挂起
            mainForm.infoList.BeginUpdate();

            mainForm.infoList.Items.Clear();
            for (int i = 0; i < m_fileCount; i++)
            {
                ListViewItem infoListItem = new ListViewItem();

                infoListItem.Text = m_lengthHash[i].ToString("X8");
                infoListItem.SubItems.Add(m_lengthDeviat[i].ToString());
                infoListItem.SubItems.Add(m_lengthBefore[i].ToString());
                infoListItem.SubItems.Add(m_lengthAfters[i].ToString());

                mainForm.infoList.Items.Add(infoListItem);
            }
            mainForm.infoList.EndUpdate();
        }

        public static string exportFolder(ThisWarTranslaterMain mainForm)
        {
            string path = Application.StartupPath + @"\_UncompressFiles\";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            for (int i = 0; i < m_fileCount; i++)
            {
                FileStream outputFile = new FileStream(path + m_lengthHash[i].ToString("X8"), FileMode.Create);

                m_uzipStream[i].Seek(0, SeekOrigin.Begin);
                outputFile.Write(m_uzipStream[i].ToArray(), 0, (int)m_uzipStream[i].Length);

                m_uzipStream[i].Seek(0, SeekOrigin.Begin);
                outputFile.Close();
            }
                return "文件已经保存";
        }
    }
}
