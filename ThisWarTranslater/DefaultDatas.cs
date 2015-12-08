using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ThisWarTranslater
{
    class DefaultDatas
    {
        public static void DefaultHash(ThisWarTranslaterMain mainForm)
        {
            mainForm.hashList.BeginUpdate();

            mainForm.hashList.Items.Clear();
            ListViewItem defaultdata = null;

            defaultdata = new ListViewItem();
            defaultdata.Text = "0975B714";
            defaultdata.SubItems.Add("名词表");
            defaultdata.SubItems.Add("丢失");
            mainForm.hashList.Items.Add(defaultdata);

            defaultdata = new ListViewItem();
            defaultdata.Text = "3CA400B5";
            defaultdata.SubItems.Add("韩语");
            defaultdata.SubItems.Add("丢失");
            mainForm.hashList.Items.Add(defaultdata);

            defaultdata = new ListViewItem();
            defaultdata.Text = "AA9C54E9";
            defaultdata.SubItems.Add("日语");
            defaultdata.SubItems.Add("丢失");
            mainForm.hashList.Items.Add(defaultdata);

            defaultdata = new ListViewItem();
            defaultdata.Text = "FFFFFFFF";
            defaultdata.SubItems.Add("测试");
            defaultdata.SubItems.Add("丢失");
            mainForm.hashList.Items.Add(defaultdata);

            mainForm.hashList.EndUpdate();

        }

        public static void DefaultConnectInfo(ThisWarTranslaterMain mainForm)
        {
            mainForm.textDataAddress.Text = "localhost";
            mainForm.textDataPort.Text = "3306";
            mainForm.textDataName.Text = "root";
            mainForm.textDataPass.Text = "123456";
            mainForm.textDataBase.Text = "thiswar";
            mainForm.textDataTable.Text = "translatetable";
        }
    }
}
