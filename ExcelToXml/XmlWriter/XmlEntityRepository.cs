using System.Collections.Generic;

namespace ExcelToXml.XmlWriter
{
    internal class XmlEntityRepository : IEntityRepository
    {
        private readonly Dictionary<int, Company> _companies = new Dictionary<int, Company>();
        private readonly Dictionary<int, User> _users = new Dictionary<int, User>();

        public void AddCompany(int id, Company company)
        {
            _companies.Add(id, company);
        }

        public void AddUser(int companyId, int id, User xmlUser)
        {
            Company company = GetCompany(companyId);

            company.Users.Add(xmlUser);

            _users.Add(id, xmlUser);
        }

        public void AddAddress(int userId, Address xmlAddress)
        {
            User user = GetUser(userId);

            user.Addresses.Add(xmlAddress);
        }

        public IEnumerable<Company> GetCompanies()
        {
            return _companies.Values;
        }

        private User GetUser(int userId)
        {
            return _users[userId];
        }

        private Company GetCompany(int companyId)
        {
            return _companies[companyId];
        }
    }
}