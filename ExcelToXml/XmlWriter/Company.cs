using System;
using System.Collections.Generic;

namespace ExcelToXml.XmlWriter
{
    [Serializable]
    public class Company
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Country { get; set; }

        public List<User> Users { get; set; }
    }
}