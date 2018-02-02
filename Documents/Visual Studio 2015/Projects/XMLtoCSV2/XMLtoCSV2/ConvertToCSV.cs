using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.IO;


namespace XMLtoCSV2
{
    public static class ConvertToCSV
    {
         public static List<string> Convert(XDocument xml, string separator)
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();
            List<string> list = new List<string>();
            List<string> tags = new List<string>();
            List<string> values = new List<string>();

            foreach (XElement el in xml.Descendants())
            {
                if(dict.ContainsKey(el.Name.LocalName))
                {
                    values.Add(el.Value + separator);
                }
                else
                {
                    if(!(el.HasElements))
                    {
                        dict.Add(el.Name.LocalName, el.Value);
                        values.Add(el.Value+ separator);
                    }  
                }
            }
            for(int i = dict.Keys.Count; i < values.Count; i+= dict.Keys.Count)
            {
                values.Insert(i, "\r\n");
                i += 1;
            }

            foreach (KeyValuePair<string, string> pair in dict)
            {
                tags.Add(pair.Key);
            }

            list.Add(String.Join(separator, tags));
            list.Add(String.Join("", values));
            foreach(KeyValuePair<string,string> k in dict)
            {
                Console.WriteLine(k.Value);
            }
            return list;
        }
    }
}