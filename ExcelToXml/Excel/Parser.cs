using System;
using System.Collections.Generic;
using ExcelToXml.EPPlus;

namespace ExcelToXml.Excel
{
    internal abstract class Parser<T> where T : class, new()
    {
        public abstract Dictionary<string, Action<object, T>> GetHeaderActions();

        public IEnumerable<T> GetAll(ITable table)
        {
            Dictionary<string, Action<object, T>> functions = GetHeaderActions();
            Dictionary<string, int> headers = GetHeaders(table);

            int firstRow = table.FirstRow + 1;
            int lastRow = table.LastRow;

            for (int row = firstRow; row <= lastRow; row++)
            {
                T entity = CreateEntity();

                foreach (string header in headers.Keys)
                {
                    int column = headers[header];

                    object cellValue = table.GetValue(row, column);

                    ApplyCellValue(functions, entity, header, cellValue);
                }

                yield return entity;
            }
        }

        private static T CreateEntity()
        {
            // ReSharper disable PossibleNullReferenceException
            return (T) typeof (T).GetConstructor(Type.EmptyTypes).Invoke(null);
            // ReSharper restore PossibleNullReferenceException
        }

        private static Dictionary<string, int> GetHeaders(ITable table)
        {
            var headers = new Dictionary<string, int>();

            const int row = 1;

            int firstColumn = table.FirstColumn;
            int lastColumn = table.LastColumn;

            for (int column = firstColumn; column <= lastColumn; column++)
            {
                // This assumes the first row is all string values
                var headerName = (string) table.GetValue(row, column);

                headers.Add(headerName, column);
            }

            return headers;
        }

        private void ApplyCellValue(Dictionary<string, Action<object, T>> functions, T entity, string headerName,
                                    object value)
        {
            if (functions.ContainsKey(headerName))
            {
                functions[headerName](value, entity);
            }
        }
    }
}