using System;
using System.Collections.Generic;

namespace ExcelToXml.Excel
{
    internal interface IExcel : IDisposable
    {
        IEnumerable<ITable> GetTables();
    }
}