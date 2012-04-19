using System;
using System.Collections.Generic;
using ExcelToXml.TableReader;

namespace ExcelToXml.Tables
{
    internal class CompanyParser : Parser<Company>
    {
        public override Dictionary<string, Action<object, Company>> GetHeaderActions()
        {
            return new Dictionary<string, Action<object, Company>>
                       {
                           {"Id", (x, c) => { c.Id = Convert.ToInt32(x); }},
                           {"Name", (x, c) => { c.Name = (string) x; }},
                           {"Address", (x, c) => { c.Address = (string) x; }},
                           {"City", (x, c) => { c.City = (string) x; }},
                           {"Country", (x, c) => { c.Country = (string) x; }},
                       };
        }
    }
}