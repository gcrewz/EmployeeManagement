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
        public IActionResult InsertEmployee([FromBody] EmployeeDetailedViewModel insertEmployee)
        {
            try
            {
                var insertion = _employeeService.InsertEmployee(MaptoInsertEMployee(insertEmployee));
                return Ok(insertion);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }



        private EmployeeDto MaptoInsertEMployee(EmployeeDetailedViewModel insertEmployee)
        {
            var employeeInsertion = new EmployeeDto()
            {
                Name = insertEmployee.Name,
                Age = insertEmployee.Age,
                Department = insertEmployee.Department,
                Address = insertEmployee.Address
            };
            return employeeInsertion;
        }

        
        
        [HttpPut]
        [Route("update")]
        public IActionResult UpdateEmployee([FromBody] EmployeeDetailedViewModel updateEmployee)
        {
            try
            {
                var updation = _employeeService.UpdateEmployee(MapToUpdateEmployee(updateEmployee));
                return Ok(updation);
            }
            catch (Exception ex)
            {



                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }



        private EmployeeDto MapToUpdateEmployee(EmployeeDetailedViewModel updateEmployee)
        {
            var employeeUpdation = new EmployeeDto();
            {
                employeeUpdation.Id = updateEmployee.Id;
                employeeUpdation.Name = updateEmployee.Name;
                employeeUpdation.Department = updateEmployee.Department;
                employeeUpdation.Age = updateEmployee.Age;
                employeeUpdation.Address = updateEmployee.Address;
            };
            return employeeUpdation;
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
