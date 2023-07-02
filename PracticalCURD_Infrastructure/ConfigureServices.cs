using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PracticalCURD_Application;
using PracticalCURD_Application.IRepositories;
using PracticalCURD_Application.IServices;
using PracticalCURD_Infrastructure.Persistence.DataContext;
using PracticalCURD_Infrastructure.Repositories;
using PracticalCURD_Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticalCURD_Infrastructure
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddDbContext<ApplicationDbContext>(options =>
                    options.UseSqlServer(configuration.GetConnectionString("DbConnectionString"),
                        builder => builder.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));
            
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<IDepartmentRepository,DepartmentRepository>();
            services.AddScoped<IDepartmentService, DepartmentService>();


            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IEmployeeService, EmployeeService>();

            return services;
        }
    }
}

