using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MetroChefApp.API.Models
{
    public class Salary
    {
        [Key]
        public int SalaryId { get; set; }
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }

        public DateTime Month { get; set; }
        public int TotalWorkDays { get; set; }
        public decimal TotalHours { get; set; }
        public decimal TotalAmount { get; set; }
        public DateTime GeneratedDate { get; set; } = DateTime.Now;
    }
}
