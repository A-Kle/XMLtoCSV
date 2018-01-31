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
        private static List<string> ValueLineCreator(string[,] values, string
             separator)
        {
            int row = values.GetLength(0);
            int column = values.GetLength(1);
            List<string> line = new List<string>();

            string[,] transposed = new string[values.GetLength(1), values.GetLength(0)];


            for (int c = 0; c < column; c++)
            {
                for (int r = 0; r < row; r++)
                {
                    transposed[c, r] = values[r, c];
                }
            }
            foreach (string s in transposed)
            {
                line.Add(s + separator);
            }
            return line;
        }


         public static List<string> Convert(XDocument xml, string separator)
        {
            List<string> list = new List<string>();
            List<string> line = new List<string>();

            int elNumbers = xml.Descendants().Select(el => el.Name).Distinct().Count(); //returns tags amount 
            int allElNumbers = xml.Descendants().Select(el => el.Name).Count();
            string[] names = new string[elNumbers];
            string[,] value = new string[elNumbers, allElNumbers];

            foreach (var name in xml.Descendants().Select(el => el.Name).Distinct())
            {
                int x = 0;
                names[x] = name.LocalName;
                line.Add(names[x]); //separator removed inside
                x++;
            }
            string previous = "";

            int i = 0;

            int r = 1;
            int z = 0;

            int m = 1;
            foreach (XElement el in xml.Descendants())
            {
                string start = " ";
                if (el.Name.LocalName != start)
                {

                }
                else
                {
                    line.Add("\r\n");
                }
                /*value[0, i] = el.Name.LocalName;
                if (el != el.Parent)
                {
                    if (el.Name.LocalName == previous) //repetitive tag
                    {
                        m++;
                        value[m, i] = el.Value;
                    }
                    else    //non repetitive tag
                    {
                        m = 1;
                        value[r, i] = el.Value;

                    }
                    i++;
                    previous = el.Name.LocalName;
                }
                else
                {
                    value[r, z] = "";

                }
                          break;*/
                start = el.Name.LocalName;
            }

            Console.WriteLine(names.Length);
            Console.WriteLine(value.Length);
            Console.WriteLine(value[3, 1]);
            list.Add(string.Join(separator, line));
            return list;
        }
    }
}
  

