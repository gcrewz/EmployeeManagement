using EmployeeManagement.Application.Contracts;
using EmployeeManagement.Application.Services;
using EmployeeManagement.DataAccess.Contracts;
using EmployeeManagement.DataAccess.Repository;
using EmployeeManagement.UI.Providers.ApiClients;
using EmployeeManagement.UI.Providers.Contracts;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace EmployeeManagement.UI.Configuration
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

            #region Providers

            services.AddHttpClient<IEmployeeApiClient, EmployeeApiClient>(httpClient =>
            {
                httpClient.BaseAddress = new Uri("https://localhost:5001");
            });

            #endregion
        }
    }
}
