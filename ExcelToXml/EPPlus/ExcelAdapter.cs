using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using OfficeOpenXml;

namespace ExcelToXml.EPPlus
{
    internal class ExcelAdapter : IExcel
    {
        public ExcelAdapter(FileInfo fileInfo)
        {
            if (fileInfo == null) throw new ArgumentNullException("fileInfo");

            _excelPackage = new ExcelPackage(fileInfo);
        }

        private readonly ExcelPackage _excelPackage;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _excelPackage.Dispose();
            }
        }

        public IEnumerable<ITable> GetTables()
        {
            return _excelPackage.Workbook.Worksheets.Select(sheet => (ITable) new TableAdapter(sheet));
        }
    }
}