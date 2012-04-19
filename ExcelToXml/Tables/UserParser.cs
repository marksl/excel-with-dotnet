using System;
using System.Collections.Generic;
using ExcelToXml.TableReader;

namespace ExcelToXml.Tables
{
    internal class UserParser : Parser<User>
    {
        public override Dictionary<string, Action<object, User>> GetHeaderActions()
        {
            return new Dictionary<string, Action<object, User>>
                       {
                           {"CompanyId", (x, c) => { c.CompanyId = Convert.ToInt32(x); }},
                           {"Id", (x, c) => { c.Id = Convert.ToInt32(x); }},
                           {"FirstName", (x, c) => { c.FirstName = (string) x; }},
                           {"LastName", (x, c) => { c.LastName = (string) x; }}
                       };
        }
    }
}