using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassManager.WinApp.UICommon
{
    public class Lang
    {
        static Dictionary<String, String> dicTranslations;

        static Lang()
        {
            dicTranslations = new Dictionary<string, string>();
            String lines = System.IO.File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + "/lang.txt");
            String[] translations = lines.Split(';');
            if(translations.Length > 0)
            {
                foreach(String str in translations)
                {
                    String[] latter = str.Split('=');
                    if (latter.Length > 1)
                    {
                        if (dicTranslations.ContainsKey(latter[0].Trim()) == false)
                        {
                            dicTranslations.Add(latter[0].Trim(), latter[1]);
                        }
                        else
                        {
                            dicTranslations[latter[0].Trim()] = latter[1];
                        }
                    }
                }
            }

        }


        public static string translate(String key)
        {
            if (dicTranslations.ContainsKey(key.Replace("&","").Trim()))
            {
                return dicTranslations[key.Replace("&", "").Trim()];
            }
            else
            {
                return key;
            }
        }
    }
}
