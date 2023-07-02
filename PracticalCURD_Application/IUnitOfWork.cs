using PracticalCURD_Application.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticalCURD_Application
{
    public interface IUnitOfWork : IDisposable
    {

        IDepartmentRepository _departmentRepository { get; }
        IEmployeeRepository _employeeRepository { get; }


        int Save();
    }   
}
