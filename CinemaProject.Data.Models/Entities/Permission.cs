using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace CinemaProject.Data.Models.Entities
{
    [Table("Permission")]
    public partial class Permission : IEntity
    {
        public Permission()
        {

        }

        [Key]
        [Column("permissionId")]
        public long PermissionId { get; set; }
        [Required]
        [Column("permissionName")]
        [StringLength(30)]
        public string PermissionName { get; set; }
        [Required]
        [Column("permissionDescription")]
        [StringLength(40)]
        public string PermissionDescription { get; set; }


    }
}
