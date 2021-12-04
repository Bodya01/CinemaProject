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
        public Role() : base()
        {
            RolePermissions = new HashSet<RolePermission>();
            UserRoles = new HashSet<UserRole>();
        }

        [Key]
        [Column("roleId")]
        public long RoleId { get; set; }
        [Required]
        [Column("roleName")]
        [StringLength(30)]
        public string RoleName { get; set; }
        [Required]
        [Column("roleDescription")]
        [StringLength(100)]
        public string RoleDescription { get; set; }

        [InverseProperty(nameof(RolePermission.Role))]
        public virtual ICollection<RolePermission> RolePermissions { get; set; }
        [InverseProperty(nameof(UserRole.Role))]
        public virtual ICollection<UserRole> UserRoles { get; set; }
    }
}
