using System;
using ExcelToXml.ExcelReader;
using ExcelToXml.Tables;
using ExcelToXml.XmlWriter;

namespace ExcelToXml
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            if (args.Length != 2)
            {
                Console.Out.WriteLine("Usage:");
                Console.Out.WriteLine("ExcelToXml input.xlsx output.xml");
                return;
            }

            string excelFileName = args[0];
            string xmlFileName = args[1];

            using (var reader = new ExcelFileReader(excelFileName))
            {
                var tables = CompaniesUsersAddresses.LoadFrom(reader);

                var xmlEntityRepository = new XmlEntityRepository();
                var xmlEntityMapper = new XmlEntityMapper(xmlEntityRepository);
                var writer = new XmlFileWriter(xmlFileName, xmlEntityMapper);

                writer.WriteToFile(tables);
            }
        }
    }
}