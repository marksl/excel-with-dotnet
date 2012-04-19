using System;
using System.Collections.Generic;

namespace ExcelToXml.XmlWriter
{
    [Serializable]
    public class User
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public List<Address> Addresses { get; set; }
    }
}