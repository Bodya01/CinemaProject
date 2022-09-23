using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace CinemaProject.Data.Models.Entities
{
    [Table("Role")]
    public partial class Role : IdentityRole<long>
    {
        public Role(string name)
        {
            Name = name;
            RoleDescription = name;
            RoleName = name;
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
