using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MetroChefApp.API.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }
        public string FullName { get; set; }
        public string Role { get; set; } // Staff role
        public string SalaryType { get; set; } // DAILY / MONTHLY / HOURLY
        public decimal BaseSalary { get; set; }
        public bool IsActive { get; set; } = true;

        public ICollection<WorkRoster> WorkRosters { get; set; }
        public ICollection<Salary> Salaries { get; set; }
        public ICollection<Delivery> Deliveries { get; set; }
    }
}
