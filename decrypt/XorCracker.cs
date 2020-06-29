using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace decrypt
{
    class XorCracker
    {
        private string key;
        private static List<string> keyList = new List<String>();

        public XorCracker(List<string> keyListParam)
        {
            keyList = keyListParam;
        }

        public void test(String text)
        {
            foreach (var item in keyList)
            {
                key = item;
                byte[] bytes = Encoding.ASCII.GetBytes(text);
                string[] binaryText = bytes.Select(x => Convert.ToString(x, 2).PadLeft(8, '0')).ToArray();
                byte[] bytesKey = Encoding.ASCII.GetBytes(key);
                string[] binaryKey = bytesKey.Select(x => Convert.ToString(x, 2).PadLeft(8, '0')).ToArray();
                string txtDecode = "";


                for (int i = 0; i < binaryText.Length; i++)
                {
                    txtDecode += (char)Convert.ToInt16(XOR(binaryText[i], binaryKey[i % 4]), 2);
                }
            }
        }

        public string XOR(String text, String key)
        {
            String result = "";

            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] == key[i])
                {
                    result += "0";
                }
                else
                {
                    result += "1";
                }
            }
            return result;
        }


    }
}
