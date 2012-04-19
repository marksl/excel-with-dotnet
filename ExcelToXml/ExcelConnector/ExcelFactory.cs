using System.IO;
using ExcelToXml.Excel;

namespace ExcelToXml.ExcelConnector
{
    internal class ExcelFactory
    {
        static public IExcel GetExcel(FileInfo fileInfo)
        {
            return new ExcelAdapter(fileInfo);
        }
    }
}