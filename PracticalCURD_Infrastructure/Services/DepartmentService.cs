using PracticalCURD_Application;
using PracticalCURD_Application.IServices;
using PracticalCURD_Domain.Entities;
using PracticalCURD_Infrastructure.Persistence.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticalCURD_Infrastructure.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly ApplicationDbContext _context;
        public IUnitOfWork _unitOfWork;
        public DepartmentService(IUnitOfWork unitOfWork,ApplicationDbContext context)
        {
            _unitOfWork = unitOfWork;
            _context = context;
        }

        public async Task<bool> CreateDepartment(Department entity)
        {
            var isExist = _context.Departments.Where(x => x.Name.ToLower() == entity.Name.ToLower()).FirstOrDefault();

            if(isExist == null)
            {
                if (entity != null)
                {
                    await _unitOfWork._departmentRepository.Add(entity);

                    var result = _unitOfWork.Save();

                    if (result > 0)
                        return true;
                    else
                        return false;
                }
                return false;
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> DeleteDepartment(int DepId)
        {
            if (DepId > 0)
            {
                var department = await _unitOfWork._departmentRepository.GetById(DepId);
                if (department != null)
                {
                    _unitOfWork._departmentRepository.Delete(department);
                    var result = _unitOfWork.Save();

                    if (result > 0)
                        return true;
                    else
                        return false;
                }
            }
            return false;
        }

        public async Task<IEnumerable<Department>> GetAllDepartment()
        {
            var departmentlist = await _unitOfWork._departmentRepository.GetAll();
            return departmentlist;
        }

        public async Task<Department> GetDepartmentById(int DepId)
        {
            if (DepId > 0)
            {
                var department = await _unitOfWork._departmentRepository.GetById(DepId);
                if (department != null)
                {
                    return department;
                }
            }
            return null;
        }

        public async Task<bool> UpdateDepartment(Department entity)
        {
            var isExist = _context.Departments.Where(x => x.Name.ToLower() == entity.Name.ToLower()).FirstOrDefault();

            if (isExist == null)
            {

                if (entity != null)
                {
                    var departmentResp = await _unitOfWork._departmentRepository.GetById(entity.DepartmentId);
                    if (departmentResp != null)
                    {
                        departmentResp.Name = entity.Name;


                        _unitOfWork._departmentRepository.Update(departmentResp);

                        var result = _unitOfWork.Save();

                        if (result > 0)
                            return true;
                        else
                            return false;
                    }
                }
                return false;
            }
            else
            {
                return false;
            }
        }
    }
}
