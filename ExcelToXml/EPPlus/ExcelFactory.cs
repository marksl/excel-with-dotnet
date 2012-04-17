using System.IO;

namespace ExcelToXml.EPPlus
{
    internal class ExcelFactory
    {
        static public IExcel GetExcel(FileInfo fileInfo)
        {
            return new ExcelAdapter(fileInfo);
        }
    }
}