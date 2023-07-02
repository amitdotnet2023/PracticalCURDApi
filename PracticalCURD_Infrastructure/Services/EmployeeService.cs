using PracticalCURD_Application;
using PracticalCURD_Application.IServices;
using PracticalCURD_Application.Responses;
using PracticalCURD_Domain.Entities;
using PracticalCURD_Infrastructure.Persistence.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticalCURD_Infrastructure.Services
{
    public class EmployeeService : IEmployeeService
    {

        public IUnitOfWork _unitOfWork;

        private readonly ApplicationDbContext _context;

        public EmployeeService(IUnitOfWork unitOfWork, ApplicationDbContext context)
        {
            _unitOfWork = unitOfWork;
            _context = context;
        }

        public async Task<bool> CreateEmployee(Employee entity)
        {
            if (entity != null)
            {
                await _unitOfWork._employeeRepository.Add(entity);

                var result = _unitOfWork.Save();

                if (result > 0)
                    return true;
                else
                    return false;
            }
            return false;
        }

        public async Task<bool> DeleteEmployee(int EmpId)
        {
            if (EmpId > 0)
            {
                var employee = await _unitOfWork._employeeRepository.GetById(EmpId);
                if (employee != null)
                {
                    _unitOfWork._employeeRepository.Delete(employee);
                    var result = _unitOfWork.Save();

                    if (result > 0)
                        return true;
                    else
                        return false;
                }
            }
            return false;
        }

        public async Task<IEnumerable<Employee>> GetAllEmployee(PaginationList pagination)
        {
            var employeelist = await _unitOfWork._employeeRepository.GetAll();
            return employeelist;

        }

        public async Task<Employee> GetEmployeeById(int EmpId)
        {
            if (EmpId > 0)
            {
                var employee = await _unitOfWork._employeeRepository.GetById(EmpId);
                if (employee != null)
                {
                    return employee;
                }
            }
            return null;
        }

        public async Task<bool> UpdateEmployee(Employee entity)
        {
            if (entity != null)
            {
                var employee = await _unitOfWork._employeeRepository.GetById(entity.EmployeeId);
                if (employee != null)
                {
                    employee.FirstName = entity.FirstName;
                    employee.LastName = entity.LastName;
                    employee.DepartmentId = entity.DepartmentId;
                    employee.Salary = entity.Salary;
                    employee.JoinDate = entity.JoinDate;
                    employee.IsActive = true;


                    _unitOfWork._employeeRepository.Update(employee);

                    var result = _unitOfWork.Save();

                    if (result > 0)
                        return true;
                    else
                        return false;
                }
            }
            return false;
        }

        public async Task<IEnumerable<Employee>> SearchEmployee(PaginationList pagination)
        {

            if (!pagination.searchParameters.Any() || string.IsNullOrWhiteSpace(pagination.searchParameters) == null)
            {
                return null;
            }

            var emplist = _context.Employees.Where(o => o.FirstName.ToLower().Contains(pagination.searchParameters.Trim().ToLower())
            || o.LastName.ToLower().Contains(pagination.searchParameters.Trim().ToLower())
            || o.Salary.ToString().ToLower().Contains(pagination.searchParameters.Trim().ToString().ToLower())
            );
            return emplist;


        }
    }
}
