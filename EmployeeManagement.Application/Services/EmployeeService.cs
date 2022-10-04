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


        //Insert Employee with mapping
      

        public bool InsertEmployee(EmployeeDto employees)
        {
            var insertEmployee = _employeeRepository.InsertEmployee(MappingInsertEmployee(employees));
            return (insertEmployee);
            
        }

        private EmployeeData MappingInsertEmployee(EmployeeDto insertEmployee)
        {
            var employee = new EmployeeData()
            {
               
                Name = insertEmployee.Name,
                Department = insertEmployee.Department,
                Age = insertEmployee.Age,
                Address = insertEmployee.Address

            };
            return employee;
        }


        //Update Employee with mapping

      
        public bool UpdateEmployee(EmployeeDto employees)
        {
            var updateEmployee = _employeeRepository.UpdateEmployee(MappingUpdateEmployee(employees));

            return (updateEmployee);
        }

        private EmployeeData MappingUpdateEmployee(EmployeeDto updateEmployee)
        {
            var employee = new EmployeeData()
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
