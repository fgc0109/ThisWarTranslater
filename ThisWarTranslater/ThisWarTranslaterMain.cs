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
            filePath.Text = Application.StartupPath + @"\localizations";
        }

        private void buttonFileHandle_Click(object sender, EventArgs e)
        {
            HandleFiles.FileLoad(this);
            HandleFiles.DataUnpacking(this);
            HandleFiles.DataUncompress(this);

            HandleFiles.InfoPrint(this);
            HandleLanguage.dataRefreshing(this);
        }

        private void buttonFolderHandle_Click(object sender, EventArgs e)
        {
            HandleFiles.FolderLoad(this);

            HandleFiles.DataPacking(this);

            HandleFiles.InfoPrint(this);
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
            HandleLanguage.dataNounTable(this);
            textDebug.Text = textDebug.Text + "\r\n[信息]数据库更新完成!";
        }

        private void buttonConnectDatabase_Click(object sender, EventArgs e)
        {
            string connectStr = HandleDatabase.OpenDatabase(textDataAddress.Text, textDataPort.Text, textDataName.Text, textDataPass.Text, textDataBase.Text);
            textDebug.Text = textDebug.Text + "\r\n[信息]" + connectStr;
        }

        private void buttonTemp_Click(object sender, EventArgs e)
        {
            HandleLanguage.dataLanguageTable(this);
        }
    }
}
