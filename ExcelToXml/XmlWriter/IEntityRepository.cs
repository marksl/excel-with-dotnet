using System.Collections.Generic;

namespace ExcelToXml.XmlWriter
{
    internal interface IEntityRepository
    {
        void AddCompany(int id, Company company);
        void AddUser(int companyId, int id, User xmlUser);
        void AddAddress(int userId, Address xmlAddress);
        IEnumerable<Company> GetCompanies();
    }
}