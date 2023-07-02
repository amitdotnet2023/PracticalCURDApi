using PracticalCURD_Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticalCURD_Application.IServices
{
    public interface IDepartmentService
    {
        Task<bool> CreateDepartment(Department entity);

        Task<IEnumerable<Department>> GetAllDepartment();

        Task<Department> GetDepartmentById(int DepId);

        Task<bool> UpdateDepartment(Department entity);

        Task<bool> DeleteDepartment(int DepId);
    }
}
