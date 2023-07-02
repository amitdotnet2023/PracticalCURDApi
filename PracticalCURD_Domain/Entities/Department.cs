using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticalCURD_Domain.Entities
{
    public partial class Department
    {
        
        [Key]
        public int DepartmentId { get; set; }
        public string Name { get; set; } = null!;
        public bool IsActive { get; set; }

    }
}
