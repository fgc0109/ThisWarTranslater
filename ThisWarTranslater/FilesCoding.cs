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
    class FilesCoding
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="intData"></param>
        /// <param name="countData"></param>
        /// <returns></returns>
        public static byte[] StringConverter(int intData, int countData)
        {
            byte[] resultByte = new byte[countData];
            for (int i = 0; i < countData; i++)
            {
                resultByte[i] = (byte)((intData >> (8 * i)) & 0xFF);
            }
            return resultByte;
        }

        public static void FolderLoad(ThisWarTranslaterMain mainForm)
        {
            try
            {
                DirectoryInfo TheFolder = new DirectoryInfo(mainForm.filePath.Text);

                m_fileCount = TheFolder.GetFiles().Length;

                FileInfo[] uzipFileInfo = TheFolder.GetFiles();

                m_uzipStream = new MemoryStream[m_fileCount];

                m_lengthHash = new int[m_fileCount];
                m_lengthAfters = new int[m_fileCount];

                for (int i = 0; i < m_fileCount; i++)
                {
                    byte[] fileData = File.ReadAllBytes(mainForm.filePath.Text + uzipFileInfo[i].Name);
                    m_uzipStream[i] = new MemoryStream(fileData);

                    m_lengthHash[i] = Convert.ToInt32(uzipFileInfo[i].Name, 16);
                    m_idxHash.Add(StringConverter(m_lengthHash[i], 4));

                    m_lengthAfters[i] = (int)uzipFileInfo[i].Length;
                    m_idxAfters.Add(StringConverter(m_lengthAfters[i], 4));
                }
            }
            catch (Exception e)
            {
                mainForm.textDebug.Text = mainForm.textDebug.Text + "\r\n" + e.ToString();
            }
        }

        public static void DataPacking(ThisWarTranslaterMain mainForm)
        {
            m_idxStream = new MemoryStream(17 * m_fileCount + 11);


            m_idxHeader = new byte[] { 0x00, 0x06, 0x01 };
            m_idxCounts = StringConverter(m_fileCount, 4);
            m_idxUnknow = new byte[] { 0x00, 0x00, 0x00, 0x00, };

            string path = Application.StartupPath + @"\_PackagedFiles\";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            FileStream idxOutputFile = new FileStream(path + "localizations.idx", FileMode.Create);
            FileStream datOutputFile = new FileStream(path + "localizations.dat", FileMode.Create);

            idxOutputFile.Write(m_idxHeader, 0, 3);
            idxOutputFile.Write(m_idxCounts, 0, 4);
            idxOutputFile.Write(m_idxUnknow, 0, 4);

            for (int i = 0; i < m_fileCount; i++)
            {
                idxOutputFile.Write(m_idxHash[i], 0, 4);
                idxOutputFile.Write(m_idxBefore[i], 0, 4);
                idxOutputFile.Write(m_idxAfters[i], 0, 4);
                //idxOutputFile.Write(m_idxDeviat[i], 0, 4);
                idxOutputFile.Write(StringConverter((int)datOutputFile.Length, 4), 0, 4);
                idxOutputFile.WriteByte(0x01);

                datOutputFile.Write(m_zipStream[i].ToArray(), 0, m_lengthBefore[i]);
            }
            idxOutputFile.Close();
            datOutputFile.Close();
        }

        public static void DataCompress(ThisWarTranslaterMain mainForm)
        {
            m_zipStream = new MemoryStream[m_fileCount];
            m_gzipStream = new GZipStream[m_fileCount];
            m_defStream = new DeflateStream[m_fileCount];

            MemoryStream[] tempStream = new MemoryStream[m_fileCount];

            m_lengthDeviat = new int[m_fileCount];
            m_lengthBefore = new int[m_fileCount];

            m_lengthDeviat[0] = 0;

            mainForm.progressBar.Minimum = 0;
            mainForm.progressBar.Maximum = m_fileCount;

            mainForm.progressBar.Value = 0;
            for (int i = 0; i < m_fileCount; i++)
            {
                tempStream[i] = new MemoryStream();

                m_defStream[i] = new DeflateStream(tempStream[i], CompressionMode.Compress, true);
                m_defStream[i].Write(m_uzipStream[i].ToArray(), 0, m_lengthAfters[i]);
                m_defStream[i].Close();

                m_zipStream[i] = new MemoryStream((int)tempStream[i].Length + 14);
                m_zipStream[i].Write(new byte[] { 0x1F, 0x8B, 0x08, 0x00 }, 0, 4);
                m_zipStream[i].Write(new byte[] { 0x00, 0x00, 0x00 }, 0, 3);
                m_zipStream[i].Write(new byte[] { 0x00, 0x00, 0x00 }, 0, 3);
                m_zipStream[i].Write(tempStream[i].ToArray(), 0, (int)tempStream[i].Length);
                m_zipStream[i].Write(new byte[] { 0x00, 0x00, 0xFF, 0xFF }, 0, 4);

                m_lengthBefore[i] = (int)m_zipStream[i].Length;
                m_idxBefore.Add(StringConverter(m_lengthBefore[i], 4));

                if (i > 0)
                    m_lengthDeviat[i] = m_lengthDeviat[i] + (int)m_zipStream[i - 1].Length;
                m_idxDeviat.Add(StringConverter(m_lengthDeviat[i], 4));

                mainForm.progressBar.Value = i;
            }

            mainForm.progressBar.Value = 0;
        }
    }
}
