using System;
using ExcelToXml.TableReader;
using OfficeOpenXml;

namespace ExcelToXml.ExcelReader
{
    internal class ExcelWorksheetAdapter : ITable
    {
        private readonly ExcelWorksheet _workSheet;

        public ExcelWorksheetAdapter(ExcelWorksheet workSheet)
        {
            if (workSheet == null) throw new ArgumentNullException("workSheet");
            
            _workSheet = workSheet;
        }

        public string Name
        {
            get { return _workSheet.Name; }
        }

        public int FirstColumn
        {
            get { return _workSheet.Dimension.Start.Column - 1; }
        }

        public int LastColumn
        {
            get { return _workSheet.Dimension.End.Column; }
        }

        public int FirstRow
        {
            get { return _workSheet.Dimension.Start.Column - 1; }
        }

        public int LastRow
        {
            get { return _workSheet.Dimension.End.Row; }
        }

        public object GetValue(int row, int column)
        {
            return _workSheet.Cells[row + 1, column + 1].Value;
        }
    }
}