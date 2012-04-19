namespace ExcelToXml.Excel
{
    internal interface ITable
    {
        string Name { get; }

        int FirstColumn { get; }
        int LastColumn { get; }

        int FirstRow { get; }
        int LastRow { get; }

        object GetValue(int row, int column);
    }
}