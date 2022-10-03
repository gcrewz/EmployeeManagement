using EmployeeManagement.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManagement.DataAccess.Contracts
{
    public interface IEmployeeRepository
    {
        IEnumerable<EmployeeData> GetEmployees();
        EmployeeData GetEmployeeById(int id);
        EmployeeData InsertEmployee(EmployeeData employee);
        EmployeeData UpdateEmployee(EmployeeData employee);
        bool DeleteEmployee(int employeeId);
    }
}
