using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ThisWarTranslater
{
    public partial class ThisWarTranslaterMain : Form
    {
        public ThisWarTranslaterMain()
        {
            InitializeComponent();
        }

        private void ThisWarTranslaterMain_Load(object sender, EventArgs e)
        {
            DefaultDatas.DefaultHash(this);
            DefaultDatas.DefaultConnectInfo(this);
            //filePath.Text = Application.StartupPath + @"\localizations";
            filePath.Text = Application.StartupPath + @"\_UncompressFiles\";
        }

        private void buttonFileHandle_Click(object sender, EventArgs e)
        {
            FilesDecoding.FileLoad(this);
            FilesDecoding.DataUnpacking(this);
            FilesDecoding.DataUncompress(this);

            FilesDecoding.InfoPrint(this);
            HandleLanguage.dataRefreshing(this);
        }

        private void buttonFolderHandle_Click(object sender, EventArgs e)
        {
            FilesCoding.FolderLoad(this);
            FilesCoding.DataCompress(this);
            FilesCoding.DataPacking(this);

            //HandleFiles.InfoPrint(this);
        }

        private void buttonRefreshing_Click(object sender, EventArgs e)
        {
            HandleLanguage.dataRefreshing(this);
        }

        private void hashList_SelectedIndexChanged(object sender, EventArgs e)
        {
            HandleLanguage.dataEffective(this);
        }

        private void buttonUpdateData_Click(object sender, EventArgs e)
        {
            if (hashList.FocusedItem.Text == "0975B714")
                HandleLanguage.dataNounTable(this);
            else
                HandleLanguage.dataLanguageTable(this);
            textDebug.Text = textDebug.Text + "\r\n[信息]数据库更新完成!";
        }

        private void buttonConnectDatabase_Click(object sender, EventArgs e)
        {
            string connectStr = HandleDatabase.OpenDatabase(textDataAddress.Text, textDataPort.Text, textDataName.Text, textDataPass.Text, textDataBase.Text);
            textDebug.Text = textDebug.Text + "\r\n[信息]" + connectStr;

            string debugStr = HandleLanguage.dataPreparation(this);
            textDebug.Text = textDebug.Text + "\r\n[信息]" + debugStr;
        }

        private void buttonTemp_Click(object sender, EventArgs e)
        {

        }

        private void buttonChooseFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "IDX - File(*.idx) | *.idx| 所有文件(*.*) | *.*";
            openFile.ShowDialog();
            filePath.Text = openFile.FileName.Replace(".idx", "");
        }

        private void buttonChooseFolder_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog openFolder = new FolderBrowserDialog();
            openFolder.ShowDialog();
            filePath.Text = openFolder.SelectedPath;
        }

        private void buttonExportFolder_Click(object sender, EventArgs e)
        {
            string debugStr = FilesDecoding.exportFolder(this);
            textDebug.Text = textDebug.Text + "\r\n[信息]" + debugStr;
        }

        private void buttonExportDataBase_Click(object sender, EventArgs e)
        {
            string debugStr = HandleLanguage.dataLanguageDatabaseExport(this).ToString();
            textDebug.Text = textDebug.Text + "\r\n[信息]" + "文件导出成功，包含词条" + debugStr;
        }
    }
}
