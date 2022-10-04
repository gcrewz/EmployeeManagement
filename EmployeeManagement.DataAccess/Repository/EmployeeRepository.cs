using EmployeeManagement.DataAccess.Contracts;
using EmployeeManagement.DataAccess.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
namespace EmployeeManagement.DataAccess.Repository
{
    /// <summary>
    /// Connect To Database and Perforum CRUD operations
    /// </summary>
    public class EmployeeRepository : IEmployeeRepository
    {
        private SqlConnection _sqlConnection;

        public EmployeeRepository()

        {
            _sqlConnection = new SqlConnection("data source= (localdb)\\mssqllocaldb; database= Employeedb;");
        }

        //GET ALL EMPLOYEES

        public IEnumerable<EmployeeData> GetEmployees()       
        {
            //Take data from Table
            try
            {
                _sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand(cmdText: "Select * from Employee", _sqlConnection);
                SqlDataReader sqlDataReader = (SqlDataReader)sqlCommand.ExecuteReader();



                var listOfEmployees = new List<EmployeeData>();
                while (sqlDataReader.Read())
                {

                    listOfEmployees.Add(new EmployeeData()
                    {
                        Id = (int)sqlDataReader["ID"],
                        Name = (string)sqlDataReader["NAME"],
                        Department = (string)sqlDataReader["DEPARTMENT"],
                        Age = (int)sqlDataReader["AGE"],
                        Address = (string)sqlDataReader["ADDRESS"]
                    });

                }
                return listOfEmployees;

            }
            catch (Exception exception)
            {
                throw;
            }
            finally
            {
                _sqlConnection.Close();
            }


        }


        //GET EMPLOYEE BY ID

        public EmployeeData GetEmployeeById(int id)
        {
            try
            {
                _sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand("Select * from Employee where ID = @id", _sqlConnection);      
                sqlCommand.Parameters.AddWithValue("id", id);
                SqlDataReader sqlDataReader = (SqlDataReader)sqlCommand.ExecuteReader();



                var employee = new EmployeeData();
                while (sqlDataReader.Read())
                {
                    employee.Id = (int)sqlDataReader["ID"];
                    employee.Name = (string)sqlDataReader["NAME"];
                    employee.Department = (string)sqlDataReader["DEPARTMENT"];
                    employee.Age = (int)sqlDataReader["AGE"];
                    employee.Address = (string)sqlDataReader["ADDRESS"];
                };

                return employee;
            }
            catch (Exception exception)
            {
                throw;
            }
            finally
            {
                _sqlConnection.Close();
            }
        }


        //Create Methods For Table insert, update and Delete Here

        //INSERT EMPLOYEE 

        public bool InsertEmployee(EmployeeData employee)
        {
            try
            {
                _sqlConnection.Open();

                SqlCommand sqlCommand = new SqlCommand(cmdText: "Insert into Employee (NAME,DEPARTMENT,AGE,ADDRESS)VALUES (@name, @department, @age, @address)", _sqlConnection);
               
                sqlCommand.Parameters.AddWithValue("name", employee.Name);
                sqlCommand.Parameters.AddWithValue("department", employee.Department);
                sqlCommand.Parameters.AddWithValue("age", employee.Age);
                sqlCommand.Parameters.AddWithValue("address", employee.Address);

                sqlCommand.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            finally
            {
                _sqlConnection.Close();
            }
        }


        //UPDATE EMPLOYEE 

        public bool UpdateEmployee(EmployeeData employee)
        {
            try
            {
                _sqlConnection.Open();

                var sqlCommand = new SqlCommand(cmdText: "Update Employee set Name = @name, DEPARTMENT = @department, AGE = @age, ADDRESS = @address  where Id = @id", _sqlConnection);
                sqlCommand.Parameters.AddWithValue("id", employee.Id);
                sqlCommand.Parameters.AddWithValue("name", employee.Name);
                sqlCommand.Parameters.AddWithValue("department", employee.Department);
                sqlCommand.Parameters.AddWithValue("age", employee.Age);
                sqlCommand.Parameters.AddWithValue("address", employee.Address);

                sqlCommand.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            finally
            {
                _sqlConnection.Close();
            }
        }

        //DELETE EMPLOYEE

        public bool DeleteEmployee(int employeeId)
        {
            try
            {
                _sqlConnection.Open();

                var sqlCommand = new SqlCommand(cmdText: "delete from Employee where Id = @id", _sqlConnection);
                sqlCommand.Parameters.AddWithValue("id", employeeId);

                sqlCommand.ExecuteNonQuery();
                return true ;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            finally
            {
                _sqlConnection.Close();
            }
        }
    }
}
