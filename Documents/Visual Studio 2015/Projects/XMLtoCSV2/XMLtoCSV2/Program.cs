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
            XDocument xdoc = XDocument.Load("C:\\Moje Projekty\\Zadania z XML\\test.xml");
            File.WriteAllLines("C:\\Moje Projekty\\testCSV.csv", ConvertToCSV.Convert(xdoc, ";"));
        }
    }
}
