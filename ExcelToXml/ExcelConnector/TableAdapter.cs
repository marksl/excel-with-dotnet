using System;
using ExcelToXml.Excel;
using OfficeOpenXml;

namespace ExcelToXml.ExcelConnector
{
    internal class TableAdapter : ITable
    {
        private readonly ExcelWorksheet _workSheet;

        public TableAdapter(ExcelWorksheet workSheet)
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
            get { return _workSheet.Dimension.Start.Column; }
        }

        public int LastColumn
        {
            get { return _workSheet.Dimension.End.Column; }
        }

        public int FirstRow
        {
            get { return _workSheet.Dimension.Start.Column; }
        }

        public int LastRow
        {
            get { return _workSheet.Dimension.End.Row; }
        }

        public object GetValue(int row, int column)
        {
            return _workSheet.Cells[row, column].Value;
        }
    }
}