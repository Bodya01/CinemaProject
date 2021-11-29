using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace CinemaProject.Data
{
    public partial class UserRole
    {
        [Key]
        [Column("userId")]
        public long UserId { get; set; }
        [Key]
        [Column("roleId")]
        public long RoleId { get; set; }
        [Key]
        [Column("userRolesID")]
        public long UserRolesId { get; set; }

        [ForeignKey(nameof(RoleId))]
        [InverseProperty("UserRoles")]
        public virtual Role Role { get; set; }
        [ForeignKey(nameof(UserId))]
        [InverseProperty("UserRoles")]
        public virtual User User { get; set; }
    }
}
