using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using ExcelToXml.TableReader;
using OfficeOpenXml;

namespace ExcelToXml.ExcelReader
{
    internal class ExcelFileReader : ITableReader, IDisposable
    {
        public ExcelFileReader(string excelFileName)
        {
            if (excelFileName == null) throw new ArgumentNullException("excelFileName");

            var excelFile = new FileInfo(excelFileName);
            if (!excelFile.Exists)
            {
                throw new FileNotFoundException("Excel File not found", excelFileName);
            }

            _excelPackage = new ExcelPackage(excelFile);
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
            return _excelPackage.Workbook.Worksheets.Select(sheet => (ITable) new ExcelWorksheetAdapter(sheet));
        }
    }
}