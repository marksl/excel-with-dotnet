using System;
using System.Collections.Generic;

namespace ExcelToXml.Excel
{
    internal class AddressParser : Parser<Address>
    {
        public override Dictionary<string, Action<object, Address>> GetHeaderActions()
        {
            return new Dictionary<string, Action<object, Address>>
                       {
                           {"Id", (x, c) => { c.Id = Convert.ToInt32(x); }},
                           {"UserId", (x, c) => { c.UserId = Convert.ToInt32(x); }},
                           {"Email", (x, c) => { c.Email = (string) x; }}
                       };
        }
    }
}