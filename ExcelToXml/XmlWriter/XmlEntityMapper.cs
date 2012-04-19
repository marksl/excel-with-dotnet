using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using ExcelToXml.Tables;

namespace ExcelToXml.XmlWriter
{
    internal class XmlEntityMapper
    {
        private readonly IEntityRepository _repository;

        public XmlEntityMapper(IEntityRepository repository)
        {
            if (repository == null) throw new ArgumentNullException("repository");

            _repository = repository;
        }

        public void WriteToStream(Stream stream, CompaniesUsersAddresses tables)
        {
            List<Company> companies = GetCompanies(tables);

            var companySerializer = new XmlSerializer(companies.GetType());

            companySerializer.Serialize(stream, companies);
        }

        private List<Company> GetCompanies(CompaniesUsersAddresses tables)
        {
            foreach (Tables.Company company in tables.Companies)
            {
                _repository.AddCompany(company.Id, company.ToXml());
            }

            foreach (Tables.User user in tables.Users)
            {
                _repository.AddUser(user.CompanyId, user.Id, user.ToXml());
            }

            foreach (Tables.Address address in tables.Addresses)
            {
                _repository.AddAddress(address.UserId, address.ToXml());
            }

            return _repository.GetCompanies().ToList();
        }
    }
}