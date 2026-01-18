using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MetroChefApp.API.Models
{
    public class WorkRoster
    {
        [Key]
        public int RosterId { get; set; }
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }

        public DateTime WorkDate { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
    }
}
