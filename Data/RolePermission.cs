using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace CinemaProject.Data
{
    public partial class RolePermission
    {
        [Key]
        [Column("rolePermissionsId")]
        public long RolePermissionsId { get; set; }
        [Key]
        [Column("roleId")]
        public long RoleId { get; set; }
        [Key]
        [Column("permissionId")]
        public long PermissionId { get; set; }

        [ForeignKey(nameof(PermissionId))]
        [InverseProperty("RolePermissions")]
        public virtual Permission Permission { get; set; }
        [ForeignKey(nameof(RoleId))]
        [InverseProperty("RolePermissions")]
        public virtual Role Role { get; set; }
    }
}
