using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace CinemaProject.Data.Models.Entities
{
    [Table("Promocode")]
    public partial class Promocode
    {
        public Promocode()
        {
            Carts = new HashSet<Cart>();
        }

        [Key]
        [Column("promocodeId")]
        public long PromocodeId { get; set; }
        [Required]
        [Column("promocodeName")]
        [StringLength(20)]
        public string PromocodeName { get; set; }
        [Required]
        [Column("promocodeDescription")]
        [StringLength(50)]
        public string PromocodeDescription { get; set; }
        [Column("countUse")]
        public int CountUse { get; set; }

        [InverseProperty(nameof(Cart.Promocode))]
        public virtual ICollection<Cart> Carts { get; set; }
    }
}
