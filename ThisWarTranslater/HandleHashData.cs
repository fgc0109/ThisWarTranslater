using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace ThisWarTranslater
{
    class HandleHashData
    {

        public static ulong[] m_hashtable = new ulong[256];

        public static void HashCoding(ThisWarTranslaterMain mainForm)
        {
            SHA1Managed a = new SHA1Managed();



            SHA1CryptoServiceProvider sha = new SHA1CryptoServiceProvider();
            //MD5CryptoServiceProvider sha = new MD5CryptoServiceProvider();


            byte[] byValue = Encoding.UTF8.GetBytes("fonts.config");
            byte[] byHash = sha.ComputeHash(byValue);

            string strHash = "";
            string strTemp = "";

            for (int i = 0; i < byHash.Length; i++)
            {
                int ascii = byHash[i] / 16;
                if (ascii > 9)
                {
                    strTemp = ((char)(ascii - 10 + 0x41)).ToString();
                }
                else
                {
                    strTemp = ((char)(ascii + 0x30)).ToString();
                }

                ascii = byHash[i] % 16;
                if (ascii > 9)
                {
                    strTemp += ((char)(ascii - 10 + 0x41)).ToString();
                }
                else
                {
                    strTemp += ((char)(ascii + 0x30)).ToString();
                }

                strHash += strTemp;
            }

            mainForm.textDebug.Text = strHash;
        }


        public static void CRCMakeTable()
        {
            ulong crc = 0;

            for (int i = 0; i < 256; i++)
            {
                crc = (ulong)i;
                for (int j = 0; j < 8; j++)
                {
                    if ((crc & 0x01) != 0)
                        crc = (crc >> 1) ^ 0xEDB88320;
                    else
                        crc >>= 1;
                }
                m_hashtable[i] = crc;
            }
        }


        public static void MakeCRCTable()
        {

        }
    }
}
