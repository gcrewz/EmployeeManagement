using EmployeeManagement.Application.Contracts;
using EmployeeManagement.Application.Services;
using EmployeeManagement.DataAccess.Contracts;
using EmployeeManagement.DataAccess.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace EmployeeManagement.API.Configuration
{
    public static class ConfigureService
    {
        public static void RegisterDependencies(this IServiceCollection services)
        {
            #region Application

            services.AddScoped<IEmployeeService, EmployeeService>();

            #endregion

            #region DataAccess

            services.AddScoped<IEmployeeRepository, EmployeeRepository>();

            #endregion
        }
    }
}
