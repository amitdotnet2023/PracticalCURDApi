using PracticalCURD_Application;
using PracticalCURD_Application.IRepositories;
using PracticalCURD_Infrastructure.Persistence.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticalCURD_Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public IDepartmentRepository _departmentRepository { get; }
        public IEmployeeRepository _employeeRepository { get; }

        public UnitOfWork(ApplicationDbContext context,
            IDepartmentRepository departmentRepository,
            IEmployeeRepository employeeRepository
            )
        {
            _context = context;
            _departmentRepository = departmentRepository;
            _employeeRepository = employeeRepository;

        }


        public int Save()
        {
            return _context.SaveChanges();
        }


        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
        }

    }
}
