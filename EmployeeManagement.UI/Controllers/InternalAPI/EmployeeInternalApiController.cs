using EmployeeManagement.DataAccess.Models;
using EmployeeManagement.UI.Models;
using EmployeeManagement.UI.Providers.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.UI.Controllers.InternalAPI
{
    [Route("api/internal/employee")]
    [ApiController]
    public class EmployeeInternalApiController : ControllerBase
    {
        private readonly IEmployeeApiClient _employeeApiClient;

        public EmployeeInternalApiController(IEmployeeApiClient employeeApiClient)
        {
            _employeeApiClient = employeeApiClient;
        }

        [HttpGet]
        [Route("{employeeId}")]
        public IActionResult GetEmployeeById([FromRoute] int employeeId)
        {
            try
            {
                var employee = _employeeApiClient.GetEmployeeById(employeeId);

                return Ok(employee);
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        //INSERT EMPLOYEE

        [HttpPost]
        [Route("insert")]
        public IActionResult InsertEmployee(EmployeeDetailedViewModel insertEmployee)
        {
            try
            {
                var insertion = _employeeApiClient.InsertEmployee(insertEmployee);
                return Ok(insertion);
            }
            catch (Exception)
            {



                throw;
            }
        }

        


       //UPDATE EMPLOYEE

        [HttpPut]
        [Route("update")]
        public IActionResult UpdateEmployee([FromBody] EmployeeDetailedViewModel updateEmployee)
        {
            try
            {
                var updation = _employeeApiClient.UpdateEmployee(updateEmployee);
                return Ok(updateEmployee);
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);

            }
        }





        //DELETE EMPLOYEE

        [HttpDelete]
        [Route("{employeeId}")]
        public IActionResult DeleteEmployee([FromRoute] int employeeId)
        {
            try
            {
                var deleteEmployee = _employeeApiClient.DeleteEmployee(employeeId);
                return Ok(deleteEmployee);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
