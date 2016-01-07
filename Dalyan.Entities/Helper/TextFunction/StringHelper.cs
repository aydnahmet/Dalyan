using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dalyan.Entities.Helper.TextFunction
{
    public class StringHelper
    {
        public static string GetEncodedUrlForTurkishCharacters(string textToEncode)
        {
            string temp = textToEncode;

            for (int i = 0; i < temp.Length; i++)
            {
                if (temp[i] == 'ç')
                {
                    temp = temp.Replace("ç", "%C3%A7");
                }
                else if (temp[i] == 'Ç')
                {
                    temp = temp.Replace("Ç", "%C3%87");
                }
                else if (temp[i] == 'ğ')
                {
                    temp = temp.Replace("ğ", "%C4%9F");
                }
                else if (temp[i] == 'Ğ')
                {
                    temp = temp.Replace("Ğ", "%C4%9E");
                }
                else if (temp[i] == 'ı')
                {
                    temp = temp.Replace("ı", "%C4%B1");
                }
                else if (temp[i] == 'İ')
                {
                    temp = temp.Replace("İ", "%C4%B0");
                }
                else if (temp[i] == 'ö')
                {
                    temp = temp.Replace("ö", "%C3%B6");
                }
                else if (temp[i] == 'Ö')
                {
                    temp = temp.Replace("Ö", "%C3%96");
                }
                else if (temp[i] == 'ş')
                {
                    temp = temp.Replace("ş", "%C5%9F");
                }
                else if (temp[i] == 'Ş')
                {
                    temp = temp.Replace("Ş", "%C5%9E");
                }
                else if (temp[i] == 'ü')
                {
                    temp = temp.Replace("ü", "%C3%BC");
                }
                else if (temp[i] == 'Ü')
                {
                    temp = temp.Replace("Ü", "%C3%9C");
                }
            }

            return temp;
        }

        public static string ConvertTurkishChars(string text)
        {
            String[] olds = { "Ğ", "ğ", "Ü", "ü", "Ş", "ş", "İ", "ı", "Ö", "ö", "Ç", "ç" };
            String[] news = { "G", "g", "U", "u", "S", "s", "I", "i", "O", "o", "C", "c" };

            for (int i = 0; i < olds.Length; i++)
            {
                text = text.Replace(olds[i], news[i]);
            }

            text = text.ToUpper();

            return text;
        }

        public static string GeneratePassword(int length)
        {
            const string valid = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            StringBuilder res = new StringBuilder();
            Random rnd = new Random();
            while (0 < length--)
            {
                res.Append(valid[rnd.Next(valid.Length)]);
            }
            return res.ToString();
        }
    }
}
