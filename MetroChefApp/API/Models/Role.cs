using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MetroChefApp.API.Models
{
    public class Role
    {
        [Key]
        public int RoleId { get; set; }
        public string RoleName { get; set; } // Admin, Customer, Staff

        public ICollection<UserRole> UserRoles { get; set; }
    }
}
