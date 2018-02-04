using System;
using System.Collections.Generic;
using System.Xml.Linq;


namespace XMLtoCSV2
{
    public static class ConvertToCSV
    {
        /// <summary>
        /// Dictionary dict contains each element(tag + value) from document
        /// </summary>
        /// <param name="xml">XML document to be converted</param>
        /// <param name="separator">Separator type for CSV document</param>
        /// <returns>List is returned as each row in CSV document, first line is tags</returns>
        
        public static List<string> Convert(XDocument xml, string separator)
        {
            Dictionary<string, List<string>> dict = new Dictionary<string, List<string>>();
            List<string> list = new List<string>();

            foreach (XElement el in xml.Descendants())
            {
                if(dict.ContainsKey(el.Name.LocalName)) //if dictionary contains key adds value to list of existing key
                {
                    dict[el.Name.LocalName].Add(el.Value); 
                }
                else //if dictionary doesnt contain key creates new list with specified value
                {
                    if(!(el.HasElements)) //checks if element(tag + value) in document has any nested elements
                    {                           //removes adding values for parent elements what results in joining all values of children
                        dict.Add(el.Name.LocalName, new List<string> { el.Value });
                    }  
                }
            }
            list.Add(String.Join(separator, dict.Keys));
            string line = "";
            int i = 0;
            foreach (XElement el in xml.Descendants()) //iterates over each pair(tag + value) in xml document
            {
                foreach(string key in dict.Keys)
                {
                    if(i > dict[key].Count-1)
                    {
                        line = line + separator; //if i extends index of value list returns empty field
                    }
                    else
                    {
                        line = line + dict[key][i]+separator; //adds value to the line
                    }
                }
                i++;
                line = line + "\r\n"; //each line is separated with new line character
            }
            list.Add(line);
  
            Console.WriteLine();
            return list;
        }
    }
}