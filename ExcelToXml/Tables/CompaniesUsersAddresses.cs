using System;
using System.Linq;
using ExcelToXml.TableReader;

namespace ExcelToXml.Tables
{
    internal class CompaniesUsersAddresses
    {
        public static CompaniesUsersAddresses LoadFrom(ITableReader reader)
        {
            Company[] companies = null;
            User[] users = null;
            Address[] addresses = null;

            foreach (ITable table in reader.GetTables())
            {
                switch (table.Name)
                {
                    case "Companies":
                        companies = new CompanyParser().GetAll(table).ToArray();
                        break;
                    case "Users":
                        users = new UserParser().GetAll(table).ToArray();
                        break;
                    case "Addresses":
                        addresses = new AddressParser().GetAll(table).ToArray();
                        break;
                }
            }

            return new CompaniesUsersAddresses(companies, users, addresses);
        }

        public CompaniesUsersAddresses(Company[] companies, User[] users, Address[] addresses)
        {
            if (companies == null) throw new ArgumentNullException("companies");
            if (users == null) throw new ArgumentNullException("users");
            if (addresses == null) throw new ArgumentNullException("addresses");

            Companies = companies;
            Users = users;
            Addresses = addresses;
        }

        public Company[] Companies { get; private set; }
        public User[] Users { get; private set; }
        public Address[] Addresses { get; private set; }
    }
}