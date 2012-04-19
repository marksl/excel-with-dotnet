using System.Collections.Generic;

namespace ExcelToXml.XmlWriter
{
    internal static class XmlMappingExtensions
    {
        public static Company ToXml(this Tables.Company company)
        {
            return new Company
                       {
                           Address = company.Address,
                           City = company.City,
                           Country = company.Country,
                           Name = company.Name,
                           Users = new List<User>()
                       };
        }

        public static User ToXml(this Tables.User user)
        {
            return new User
                       {
                           FirstName = user.FirstName,
                           LastName = user.LastName,
                           Addresses = new List<Address>()
                       };
        }

        public static Address ToXml(this Tables.Address address)
        {
            return new Address {Email = address.Email};
        }
    }
}