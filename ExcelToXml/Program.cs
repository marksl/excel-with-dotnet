using System;
using System.IO;
using System.Linq;
using ExcelToXml.Excel;
using ExcelToXml.ExcelConnector;

namespace ExcelToXml
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length != 2)
            {
                Console.Out.WriteLine("Usage:");
                Console.Out.WriteLine("ExcelToXml input.xlsx output.xml");
                return;
            }

            string excelFileName = args[0];
            string xmlFile = args[1];

            var excelFile = new FileInfo(excelFileName);
            if (!excelFile.Exists)
            {
                Console.Out.WriteLine("{0} does not exist. Please enter another file.", excelFileName);
                return;
            }

            using (var p = ExcelFactory.GetExcel(excelFile))
            {
                foreach (ITable table in p.GetTables())
                {
                    if (table.Name == "Companies")
                    {
                        var c = new CompanyParser().GetAll(table).ToArray();
                        if (c != null)
                        {

                        }
                    }
                }
            }
        }
    }
}
