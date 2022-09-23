using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace CinemaProject.Data.Models.Entities
{
    public partial class CartProduct
    {
        [Key]
        [Column("cartProductId")]
        public long CartProductId { get; set; }
        [Key]
        [Column("productId")]
        public long ProductId { get; set; }
        [Key]
        [Column("userId")]
        public long UserId { get; set; }
        [Key]
        [Column("cartId")]
        public long CartId { get; set; }

        [ForeignKey("CartId,UserId")]
        [InverseProperty("CartProducts")]
        public virtual Cart Cart { get; set; }
        [ForeignKey(nameof(ProductId))]
        [InverseProperty("CartProducts")]
        public virtual Product Product { get; set; }
    }
}
