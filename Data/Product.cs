using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace CinemaProject.Data
{
    [Table("Product")]
    public partial class Product
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

        [InverseProperty(nameof(CartProduct.Product))]
        public virtual ICollection<CartProduct> CartProducts { get; set; }
    }
}
