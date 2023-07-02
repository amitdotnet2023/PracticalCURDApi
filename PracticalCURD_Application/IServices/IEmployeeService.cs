using PracticalCURD_Application.Responses;
using PracticalCURD_Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticalCURD_Application.IServices
{
    public interface IEmployeeService
    {
        Task<bool> CreateEmployee(Employee entity);

        Task<IEnumerable<Employee>> GetAllEmployee(PaginationList pagination);

        Task<Employee> GetEmployeeById(int EmpId);

        Task<bool> UpdateEmployee(Employee entity);

        Task<bool> DeleteEmployee(int EmpId);

        Task<IEnumerable<Employee>> SearchEmployee(PaginationList pagination);
    }
}
