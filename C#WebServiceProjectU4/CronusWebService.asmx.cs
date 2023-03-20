using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Services;
using WebApplicationCronus.DAL;
using WebApplicationCronus.Models;

namespace WebApplicationCronus
{
    /// <summary>
    /// Summary description for CronusWebService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/CronusWebService")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class CronusWebService : System.Web.Services.WebService
    {
        private static readonly Demo_Database_NAV__5_0_Context context = new Demo_Database_NAV__5_0_Context();
        private static readonly CronusEmployee cronusEmployee = new CronusEmployee(context);       
        private readonly DirectDbQueries directDbQuerrys = new DirectDbQueries();
        
        private static string ServerError = "";
        [WebMethod]
        public string GetServerError()
        {
            string error = ServerError;
            ServerError = "";
            return error;
        }

        [WebMethod]
        public string GetEmployeeById(string empId)
        {
            try
            {
                var employee = context.CronusSverigeAbEmployee.Find(empId);
                if (employee != null)
                {
                    return $"{employee.FirstName} || {employee.LastName} || {employee.JobTitle} || {employee.City} || {employee.PhoneNo}";
                }
                return "Employee not found.";
            }
            catch (Exception ex)
            {
                ServerError = "Error getting employee: " + ex.Message + ex.StackTrace;
                return string.Empty;
            }
        }

        [WebMethod]
        public string CreateEmployee(List<KeyValuePairCronus> employeeData)
        {
            string empId = employeeData.FirstOrDefault(x => x.Key == "EmpId")?.Value;
            string firstName = employeeData.FirstOrDefault(x => x.Key == "FirstName")?.Value;
            string lastName = employeeData.FirstOrDefault(x => x.Key == "LastName")?.Value;
            string jobTitle = employeeData.FirstOrDefault(x => x.Key == "JobTitle")?.Value;
            string city = employeeData.FirstOrDefault(x => x.Key == "City")?.Value;
            string phoneNo = employeeData.FirstOrDefault(x => x.Key == "PhoneNo")?.Value;
            

            if (string.IsNullOrWhiteSpace(firstName) || string.IsNullOrWhiteSpace(lastName) || string.IsNullOrWhiteSpace(jobTitle) || string.IsNullOrWhiteSpace(city) || string.IsNullOrWhiteSpace(phoneNo))
            {
                return "Data is not complete";
            }

            var employee = new CronusSverigeAbEmployee
            {
                FirstName = firstName,
                LastName = lastName,
                JobTitle = jobTitle,
                City = city,
                PhoneNo = phoneNo,
                Timestamp = new byte[] { 0x01, 0x02, 0x03 },
                No = empId,
                MiddleName = "",
                Initials = "",
                SearchName = "",
                Address = "",
                Address2 = "",
                PostCode = "",
                County = "",
                MobilePhoneNo = "",
                EMail = "",
                AltAddressCode = "",
                AltAddressStartDate = new DateTime(2013, 1, 1),
                AltAddressEndDate = new DateTime(2013, 12, 31),
                Picture = new byte[] { 0x04, 0x05, 0x06 },
                BirthDate = new DateTime(1990, 1, 1),
                SocialSecurityNo = "",
                UnionCode = "",
                UnionMembershipNo = "",
                Sex = 1,
                CountryRegionCode = "",
                ManagerNo = "",
                EmplymtContractCode = "",
                StatisticsGroupCode = "",
                EmploymentDate = new DateTime(2010, 1, 1),
                Status = 1,
                InactiveDate = new DateTime(2013, 3, 1),
                CauseOfInactivityCode = "",
                TerminationDate = new DateTime(2013, 4, 1),
                GroundsForTermCode = "",
                GlobalDimension1Code = "",
                GlobalDimension2Code = "",
                ResourceNo = "",
                LastDateModified = DateTime.Now,
                Extension = "",
                Pager = "",
                FaxNo = "",
                CompanyEMail = "",
                Title = "",
                SalespersPurchCode = "",
                NoSeries = "",

            };
            try
            {
                cronusEmployee.AddEmployee(employee);
                return "Employee Created";
            }
            catch (Exception ex)
            {
                ServerError = ("An error occurred while creating the employee: " + ex.Message + ex.StackTrace);
                return string.Empty;
            }
        }

        [WebMethod]
        public string UpdateEmployee(List<KeyValuePairCronus> employeeData)
        {
            var empId = employeeData.FirstOrDefault(x => x.Key == "EmpId")?.Value;
            var firstName = employeeData.FirstOrDefault(x => x.Key == "FirstName")?.Value;
            var lastName = employeeData.FirstOrDefault(x => x.Key == "LastName")?.Value;
            var jobTitle = employeeData.FirstOrDefault(x => x.Key == "JobTitle")?.Value;
            var city = employeeData.FirstOrDefault(x => x.Key == "City")?.Value;
            var phoneNo = employeeData.FirstOrDefault(x => x.Key == "PhoneNo")?.Value;

            if (string.IsNullOrWhiteSpace(firstName) || string.IsNullOrWhiteSpace(lastName) || string.IsNullOrWhiteSpace(jobTitle) || string.IsNullOrWhiteSpace(city) || string.IsNullOrWhiteSpace(phoneNo))
            {
                return "Data is not complete";
            }
            cronusEmployee.UpdateEmployee(empId, firstName, lastName, jobTitle, city, phoneNo);
            return "Employee Updated";
        }

        [WebMethod]
        public string DeleteEmployee(string empId)
        {
            var employee = cronusEmployee.GetEmployeeById(empId);
            if (employee != null)
            {
                cronusEmployee.DeleteEmployee(empId);
                return "Employee Deleted";
            }
            else return "Employee not found";
        }

        [WebMethod]
        public string[] GetPrimaryKeyConstraintNames()
        {             
            try
            {
                var constraintNames = directDbQuerrys.GetPK_ConstraintNamesFromDb();
                return constraintNames;               
            }
            catch (Exception ex)
            {
                ServerError = ("An error occurred while retrieving primary key constraint names:" + ex.Message + ex.StackTrace);
                return new string[0];
            }
        }
        [WebMethod]
        public string[] GetAllColumnNames()
        {
            try
            {
                var columnNames = directDbQuerrys.GetAllColumnNamesFromDb();
                return columnNames;
            }
            catch (Exception ex)
            {
                ServerError = ("An error occurred while retrieving column names: " + ex.Message + ex.StackTrace);
                return new string[0];
            }
        }
        [WebMethod]
        public string GetTotalTables()
        {
            try
            {
                var totalTables = directDbQuerrys.GetTotalTablesFromDb();
                return totalTables;
            }
            catch (Exception ex)
            {
                ServerError = ("An error occurred while retrieving total tables: " + ex.Message + ex.StackTrace);
                return string.Empty;
            }
        }
        [WebMethod]
        public string GetTotalColumns()
        {
            try
            {
                var totalColumns = directDbQuerrys.GetTotalColumnsFromDb();
                return totalColumns;
            }
            catch (Exception ex)
            {
                ServerError = ("An error occurred while retrieving total columns: " + ex.Message + ex.StackTrace);
                return string.Empty;
            }
        }

    }
}
