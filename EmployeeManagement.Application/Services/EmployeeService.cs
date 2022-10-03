using EmployeeManagement.Application.Contracts;
using EmployeeManagement.Application.Models;
using EmployeeManagement.DataAccess.Contracts;
using EmployeeManagement.DataAccess.Models;
using System.Collections.Generic;
using System.Linq;

namespace EmployeeManagement.Application.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;



        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }




        public IEnumerable<EmployeeDto> GetEmployees()
        {
            var employeeList = _employeeRepository.GetEmployees();
              
            return ToEmployeeDto(employeeList);
        }



        private IEnumerable<EmployeeDto> ToEmployeeDto(IEnumerable<EmployeeData> employees)
        {
            var employeeDtoList = new List<EmployeeDto>();
            foreach (var item in employees)
            {
                employeeDtoList.Add(new EmployeeDto()
                {
                    Id = item.Id,
                    Name = item.Name,
                    Department = item.Department,
                    Age = item.Age,
                    Address = item.Address
                });
            }
            return employeeDtoList;

        }


        public EmployeeDto GetEmployeeById(int id)
        {
            var getById = _employeeRepository.GetEmployeeById(id);

            return ToEmployeeDto(getById);
        }


        private EmployeeDto ToEmployeeDto(EmployeeData employee)
        {
            var employeeDto = new EmployeeDto()
            {
                Id = employee.Id,
                Name = employee.Name,
                Department = employee.Department,
                Age = employee.Age,
                Address = employee.Address

            };
            return employeeDto;
        }


        //Insert Employee without and with mapping

        /*public bool  InsertEmployee(EmployeeData employees)
        {
            var insetEmployee= _employeeRepository.InsertEmployee(employees);
            return insetEmployee;
        }*/


        public EmployeeDto InsertEmployee(EmployeeData employees)
        {
            var insertEmployee = _employeeRepository.InsertEmployee(employees);
            var employee = MappingInsertEmployee(insertEmployee);
            return employee;
        }

        private EmployeeDto MappingInsertEmployee(EmployeeData insertEmployee)
        {
            var employee = new EmployeeDto()
            {
               
                Name = insertEmployee.Name,
                Department = insertEmployee.Department,
                Age = insertEmployee.Age,
                Address = insertEmployee.Address

            };
            return employee;
        }


        //Update Employee without and with mapping


        /*public bool UpdateEmployee(EmployeeData employees)
        {
            var updateEmployee = _employeeRepository.UpdateEmployee(employees);
            return updateEmployee;
        }
         */

        public EmployeeDto UpdateEmployee(EmployeeData employees)
        {
            var updateEmployee = _employeeRepository.UpdateEmployee(employees);
            var employee = MappingUpdateEmployee(updateEmployee);
            return employee;
        }

        private EmployeeDto MappingUpdateEmployee(EmployeeData updateEmployee)
        {
            var employee = new EmployeeDto()
            {
                Id = updateEmployee.Id,
                Name = updateEmployee.Name,
                Department = updateEmployee.Department,
                Age = updateEmployee.Age,
                Address = updateEmployee.Address

            };
            return employee;
        }

        //Delete Employee 

        public bool DeleteEmployee( int Id)
        {
            var deleteEmployee = _employeeRepository.DeleteEmployee(Id);
            return deleteEmployee;
        }      
    }
}
