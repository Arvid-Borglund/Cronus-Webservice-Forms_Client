using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using WebApplicationCronus.Models;

namespace WebApplicationCronus.DAL
{
    public class CronusEmployee
    {
        private readonly Demo_Database_NAV__5_0_Context _context;

        public CronusEmployee(Demo_Database_NAV__5_0_Context context)
        {
            _context = context;
        }

        // Get all employees
        public List<CronusSverigeAbEmployee> GetAllEmployees()
        {
            return _context.CronusSverigeAbEmployee.ToList();
        }

        // Get employee by ID
        public CronusSverigeAbEmployee GetEmployeeById(string id)
        {
            return _context.CronusSverigeAbEmployee.Find(id);
        }

        // Add new employee
        public void AddEmployee(CronusSverigeAbEmployee employee)
        {
            _context.CronusSverigeAbEmployee.Add(employee);
            _context.SaveChanges();
        }

        public void UpdateEmployee(string empId, string firstName, string lastName, string jobTitle, string city, string phoneNo)
        {
            CronusSverigeAbEmployee employee = GetEmployeeById(empId);
            employee.FirstName = firstName;                 
            employee.LastName = lastName;                     
            employee.JobTitle = jobTitle;         
            employee.City = city;                       
            employee.PhoneNo = phoneNo;                        
            _context.SaveChanges();
        }
        
        // Delete employee
        public void DeleteEmployee(string id)
        {
            var employee = _context.CronusSverigeAbEmployee.Find(id);
            _context.CronusSverigeAbEmployee.Remove(employee);
            _context.SaveChanges();
        }
    }
}
