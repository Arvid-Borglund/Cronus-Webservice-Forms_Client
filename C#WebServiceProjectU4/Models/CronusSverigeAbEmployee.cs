using System;
using System.Collections.Generic;

namespace WebApplicationCronus.Models
{
    public partial class CronusSverigeAbEmployee
    {
        public byte[] Timestamp { get; set; }
        public string No { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Initials { get; set; }
        public string JobTitle { get; set; }
        public string SearchName { get; set; }
        public string Address { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string PostCode { get; set; }
        public string County { get; set; }
        public string PhoneNo { get; set; }
        public string MobilePhoneNo { get; set; }
        public string EMail { get; set; }
        public string AltAddressCode { get; set; }
        public DateTime AltAddressStartDate { get; set; }
        public DateTime AltAddressEndDate { get; set; }
        public byte[] Picture { get; set; }
        public DateTime BirthDate { get; set; }
        public string SocialSecurityNo { get; set; }
        public string UnionCode { get; set; }
        public string UnionMembershipNo { get; set; }
        public int Sex { get; set; }
        public string CountryRegionCode { get; set; }
        public string ManagerNo { get; set; }
        public string EmplymtContractCode { get; set; }
        public string StatisticsGroupCode { get; set; }
        public DateTime EmploymentDate { get; set; }
        public int Status { get; set; }
        public DateTime InactiveDate { get; set; }
        public string CauseOfInactivityCode { get; set; }
        public DateTime TerminationDate { get; set; }
        public string GroundsForTermCode { get; set; }
        public string GlobalDimension1Code { get; set; }
        public string GlobalDimension2Code { get; set; }
        public string ResourceNo { get; set; }
        public DateTime LastDateModified { get; set; }
        public string Extension { get; set; }
        public string Pager { get; set; }
        public string FaxNo { get; set; }
        public string CompanyEMail { get; set; }
        public string Title { get; set; }
        public string SalespersPurchCode { get; set; }
        public string NoSeries { get; set; }
    }
}
