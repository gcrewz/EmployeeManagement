using EmployeeManagement.API.Models;
using EmployeeManagement.Application.Contracts;
using EmployeeManagement.Application.Models;
using EmployeeManagement.DataAccess.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EmployeeManagement.API.Controllers
{
    [Route("api/employee")]
    [ApiController]
    public class EmployeeApiController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeApiController(IEmployeeService employeeService)
        {
            this._employeeService = employeeService;
        }       

        [HttpGet]
        [Route("get-all")]
        public IActionResult GetEmployees()
        {
            /// get employees by calling GetEmployees() in IEmployeeService and store it in a variable and Map that variable to EmployeeDetailedViewModel.            
            
            try
            {
                var listOfEmployees = _employeeService.GetEmployees();
                return Ok(listOfEmployees);
            }
            catch (Exception exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, exception.Message);

            }
        }

        [HttpGet]
        [Route("{employeeId}")]
        public IActionResult GetEmployeeById([FromRoute] int employeeId)
        {
            try
            {
                var employee = _employeeService.GetEmployeeById(employeeId);
                return Ok(employee);
            }
            catch (Exception exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, exception.Message);

            }
        }


       /* private EmployeeDetailedViewModel MapToGetById(EmployeeDto employeeDto)
        {
            var employee = new EmployeeDetailedViewModel()

            {
                Id = employeeDto.Id,
                Name = employeeDto.Name,
                Age = employeeDto.Age,
                Department = employeeDto.Department,
                Address = employeeDto.Address,
            };
            return employee;
        }*/


        //Create Employee Insert, Update and Delete Endpoint 

        [HttpPost]
        [Route("insert")]
        public IActionResult InsertEmployee([FromBody] EmployeeData newEmployee)
        {
            try
            {
                var employee = _employeeService.InsertEmployee(newEmployee);
                return Ok(MapToInsertEmployee(employee));
            }
            catch (Exception ex)
            {
             
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            
            }
        }



        private EmployeeDetailedViewModel MapToInsertEmployee(EmployeeDto employeeDto)
        {
            var employee = new EmployeeDetailedViewModel()

            {
                Name = employeeDto.Name,
                Age = employeeDto.Age,
                Department = employeeDto.Department,
                Address = employeeDto.Address,                
            };
                return employee;
        }



        [HttpPut]
        [Route("update")]
        public IActionResult UpdateEmployee([FromBody] EmployeeData updatedEmployee)
        {
            try
            {
                var modifiedEmployee = _employeeService.UpdateEmployee(updatedEmployee);
                return Ok(MapToUpdateEmployee(modifiedEmployee));
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);

            }
        }



        private EmployeeDetailedViewModel MapToUpdateEmployee(EmployeeDto modifiedEmployee)
        {
            var employee = new EmployeeDetailedViewModel()
            {
                Name = modifiedEmployee.Name,
                Age = modifiedEmployee.Age,
                Department = modifiedEmployee.Department,
                Address = modifiedEmployee.Address,
            };
                 return employee;
        }

        [HttpDelete]
        [Route("delete/{employeeId}")]

        public IActionResult DeleteEmploye([FromRoute] int employeeId)
        {
            try
            {
                var deletedEmployee = _employeeService.DeleteEmployee(employeeId);
                return Ok(deletedEmployee);
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);

            }
        }

    }
}
