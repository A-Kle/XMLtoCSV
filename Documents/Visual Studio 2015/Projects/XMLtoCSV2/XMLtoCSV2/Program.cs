using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.IO;

namespace XMLtoCSV2
{
    class Program
    {
        static void Main(string[] args)
        {        
            XDocument xdoc = XDocument.Load(@"test.xml");
            File.WriteAllLines("C:\\testCSV.csv", ConvertToCSV.Convert(xdoc, ";"));
        }
    }
}
