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
            defaultdata.SubItems.Add("0");
            defaultdata.SubItems.Add("noun");
            mainForm.hashList.Items.Add(defaultdata);

            defaultdata = new ListViewItem();
            defaultdata.Text = "3268A4D1";
            defaultdata.SubItems.Add("德语");
            defaultdata.SubItems.Add("丢失");
            defaultdata.SubItems.Add("1");
            defaultdata.SubItems.Add("lang_de");
            mainForm.hashList.Items.Add(defaultdata);

            defaultdata = new ListViewItem();
            defaultdata.Text = "3CA400B5";
            defaultdata.SubItems.Add("韩语");
            defaultdata.SubItems.Add("丢失");
            defaultdata.SubItems.Add("2");
            defaultdata.SubItems.Add("lang_ko");
            mainForm.hashList.Items.Add(defaultdata);

            defaultdata = new ListViewItem();
            defaultdata.Text = "4C4E8293";
            defaultdata.SubItems.Add("波兰语2");
            defaultdata.SubItems.Add("丢失");
            defaultdata.SubItems.Add("3");
            defaultdata.SubItems.Add("lang_pl2");
            mainForm.hashList.Items.Add(defaultdata);

            defaultdata = new ListViewItem();
            defaultdata.Text = "781880B4";
            defaultdata.SubItems.Add("英语");
            defaultdata.SubItems.Add("丢失");
            defaultdata.SubItems.Add("5");
            defaultdata.SubItems.Add("lang_en");
            mainForm.hashList.Items.Add(defaultdata);

            defaultdata = new ListViewItem();
            defaultdata.Text = "7D919140";
            defaultdata.SubItems.Add("波兰语1");
            defaultdata.SubItems.Add("丢失");
            defaultdata.SubItems.Add("6");
            defaultdata.SubItems.Add("lang_pl1");
            mainForm.hashList.Items.Add(defaultdata);

            defaultdata = new ListViewItem();
            defaultdata.Text = "93D6426A";
            defaultdata.SubItems.Add("西班牙语");
            defaultdata.SubItems.Add("丢失");
            defaultdata.SubItems.Add("7");
            defaultdata.SubItems.Add("lang_es");
            mainForm.hashList.Items.Add(defaultdata);

            defaultdata = new ListViewItem();
            defaultdata.Text = "96C4B5A6";
            defaultdata.SubItems.Add("葡萄牙语2");
            defaultdata.SubItems.Add("丢失");
            defaultdata.SubItems.Add("8");
            defaultdata.SubItems.Add("lang_pt2");
            mainForm.hashList.Items.Add(defaultdata);

            defaultdata = new ListViewItem();
            defaultdata.Text = "9C6EC859";
            defaultdata.SubItems.Add("葡萄牙语1");
            defaultdata.SubItems.Add("丢失");
            defaultdata.SubItems.Add("9");
            defaultdata.SubItems.Add("lang_pt1");
            mainForm.hashList.Items.Add(defaultdata);

            defaultdata = new ListViewItem();
            defaultdata.Text = "AA9C54E9";
            defaultdata.SubItems.Add("日语");
            defaultdata.SubItems.Add("丢失");
            defaultdata.SubItems.Add("11");
            defaultdata.SubItems.Add("lang_ja");
            mainForm.hashList.Items.Add(defaultdata);

            defaultdata = new ListViewItem();
            defaultdata.Text = "D0870881";
            defaultdata.SubItems.Add("意大利语");
            defaultdata.SubItems.Add("丢失");
            defaultdata.SubItems.Add("13");
            defaultdata.SubItems.Add("lang_it");
            mainForm.hashList.Items.Add(defaultdata);

            defaultdata = new ListViewItem();
            defaultdata.Text = "E840AE67";
            defaultdata.SubItems.Add("土耳其语");
            defaultdata.SubItems.Add("丢失");
            defaultdata.SubItems.Add("15");
            defaultdata.SubItems.Add("lang_tr");
            mainForm.hashList.Items.Add(defaultdata);

            defaultdata = new ListViewItem();
            defaultdata.Text = "F2232BE3";
            defaultdata.SubItems.Add("俄语");
            defaultdata.SubItems.Add("丢失");
            defaultdata.SubItems.Add("16");
            defaultdata.SubItems.Add("lang_ru");
            mainForm.hashList.Items.Add(defaultdata);

            defaultdata = new ListViewItem();
            defaultdata.Text = "F8B11D94";
            defaultdata.SubItems.Add("法语");
            defaultdata.SubItems.Add("丢失");
            defaultdata.SubItems.Add("17");
            defaultdata.SubItems.Add("lang_fr");
            mainForm.hashList.Items.Add(defaultdata);

            defaultdata = new ListViewItem();
            defaultdata.Text = "FFFFFFFF";
            defaultdata.SubItems.Add("测试");
            defaultdata.SubItems.Add("丢失");
            defaultdata.SubItems.Add("255");
            defaultdata.SubItems.Add("test");
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
            mainForm.textDataRevision.Text = "142";
            mainForm.textBoxField.Text = "lang_user";
            mainForm.textBoxFile.Text = "AA9C54E9";
        }
    }
}
