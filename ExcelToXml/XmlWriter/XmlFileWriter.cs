using System;
using System.IO;
using ExcelToXml.Tables;

namespace ExcelToXml.XmlWriter
{
    internal class XmlFileWriter
    {
        private readonly string _fileName;
        private readonly XmlEntityMapper _xmlEntityMapper;

        public XmlFileWriter(string fileName, XmlEntityMapper xmlEntityMapper)
        {
            if (fileName == null) throw new ArgumentNullException("fileName");
            if (xmlEntityMapper == null) throw new ArgumentNullException("xmlEntityMapper");

            _fileName = fileName;
            _xmlEntityMapper = xmlEntityMapper;
        }

        public void WriteToFile(CompaniesUsersAddresses tables)
        {
            using (FileStream file = File.Create(_fileName))
            {
                _xmlEntityMapper.WriteToStream(file, tables);
            }
        }
    }
}