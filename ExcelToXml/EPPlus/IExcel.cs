using System;
using System.Collections.Generic;

namespace ExcelToXml.EPPlus
{
    internal interface IExcel : IDisposable
    {
        IEnumerable<ITable> GetTables();
    }
}