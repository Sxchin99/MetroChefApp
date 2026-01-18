namespace MetroChefApp.API.DTOs
{
    public class EmployeeDto
    {
        public int EmployeeId { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
        public string SalaryType { get; set; } = string.Empty; // DAILY / MONTHLY / HOURLY
        public decimal BaseSalary { get; set; }
        public bool IsActive { get; set; }

        // Optional: Include Roster and Salary info
        public List<WorkRosterDto>? WorkRosters { get; set; }
        public List<SalaryDto>? Salaries { get; set; }
    }

    public class WorkRosterDto
    {
        public DateTime WorkDate { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
    }

    public class SalaryDto
    {
        public string Month { get; set; } = string.Empty;
        public int TotalWorkDays { get; set; }
        public decimal TotalHours { get; set; }
        public decimal TotalAmount { get; set; }
        public DateTime GeneratedDate { get; set; }
    }
}
