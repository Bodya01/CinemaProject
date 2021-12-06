using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace CinemaProject.Data
{
    [Table("Role")]
    public partial class Role : IdentityRole<long>
    {
        public Role()
        {


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



    }
}
