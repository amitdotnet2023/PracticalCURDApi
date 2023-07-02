using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticalCURD_Domain.Entities
{
    public partial class Employee
    {
        [Key]
        public int EmployeeId { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public int DepartmentId { get; set; }

        [ConcurrencyCheck]
        public decimal Salary { get; set; }
        public DateTime JoinDate { get; set; }
        public bool IsActive { get; set; }

    }
}
