using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace CinemaProject.Data.Models.Entities
{
    [Table("Product")]
    public partial class Product : IEntity
    {
        public Product()
        {
            CartProducts = new HashSet<CartProduct>();
        }

        [Key]
        [Column("productId")]
        public long ProductId { get; set; }
        [Required]
        [Column("productName")]
        [StringLength(50)]
        public string ProductName { get; set; }
        [Column("productPrice", TypeName = "decimal(18, 0)")]
        public decimal ProductPrice { get; set; }
        public string ProductPhotoPath { get; set; }

        [InverseProperty(nameof(CartProduct.Product))]
        public virtual ICollection<CartProduct> CartProducts { get; set; }
    }
}