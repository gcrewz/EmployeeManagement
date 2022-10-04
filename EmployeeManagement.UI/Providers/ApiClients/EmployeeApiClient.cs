using EmployeeManagement.UI.Models;
using EmployeeManagement.UI.Models.Provider;
using EmployeeManagement.UI.Providers.Contracts;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace EmployeeManagement.UI.Providers.ApiClients
{
    public class EmployeeApiClient : IEmployeeApiClient
    {
        private readonly HttpClient _httpClient;

        public EmployeeApiClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public IEnumerable<EmployeeViewModel> GetAllEmployee()
        {
            //Consume /employee endpoint in the EmployeeManagementApi using _httpClient
            using var response = _httpClient.GetAsync("https://localhost:5001/api/employee/get-all").Result;
            {
                var listOfEmployee = JsonConvert.DeserializeObject<List<EmployeeViewModel>>(response.Content.ReadAsStringAsync().Result);
                return listOfEmployee;
            }
        }


        public EmployeeDetailedViewModel GetEmployeeById(int id)
        {
            //Consume /{employeeId} endpoint in the EmployeeManagementApi using _httpClient

            using var response = _httpClient.GetAsync("https://localhost:5001/api/employee/"+id).Result;
            {
                var employeeById = JsonConvert.DeserializeObject<EmployeeDetailedViewModel>(response.Content.ReadAsStringAsync().Result);
                return employeeById;
            }
                       
        }

        
        //Insert Employee

        public bool InsertEmployee(EmployeeDetailedViewModel employee)
        {

            var stringContent = new StringContent(JsonConvert.SerializeObject(employee),Encoding.UTF8, "application/json");
            using (var response = _httpClient.PostAsync("https://localhost:5001/api/employee/insert",stringContent ).Result)
            {
                return true;
            }
        }


        //Update Employee

        public bool UpdateEmployee(EmployeeDetailedViewModel employee)
        {

            var stringContent = new StringContent(JsonConvert.SerializeObject(employee), Encoding.UTF8, "application/json");
            using (var response = _httpClient.PutAsync("https://localhost:5001/api/employee/update", stringContent).Result)
            {
                return true;
            }
        }


        //Delete Employee
        public bool DeleteEmployee(int employeeId)
        {

            var stringContent = new StringContent(JsonConvert.SerializeObject(employeeId));
            using (var response = _httpClient.DeleteAsync("https://localhost:5001/api/employee/delete/" + employeeId).Result)
            {
                return true;
            }
        }
    }
}

