using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace CinemaProject.Data
{
    [Table("Role")]
    public partial class Role : IdentityRole<long>
    {
        public Role(string name) 
        {
            Name = name.Trim();
            RoleName = name.Trim();
            RoleDescription = name.Trim();
        }

        [Required]
        [Column("roleName")]
        [StringLength(30)]
        public string RoleName { get; set; }
        [Required]
        [Column("roleDescription")]
        [StringLength(100)]
        public string RoleDescription { get; set; }

    
        
    }
}
