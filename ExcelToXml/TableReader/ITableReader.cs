using System.Collections.Generic;

namespace ExcelToXml.TableReader
{
    internal interface ITableReader
    {
        IEnumerable<ITable> GetTables();
    }
}