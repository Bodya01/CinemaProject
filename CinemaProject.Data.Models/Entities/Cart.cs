using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace CinemaProject.Data.Models.Entities
{
    [Table("Cart")]
    public partial class Cart  : IEntity
    {
        public Cart()
        {
            CartProducts = new HashSet<CartProduct>();
            Tickets = new HashSet<Ticket>();
        }

        [Key]
        [Column("cartId")]
        public long CartId { get; set; }
        [Key]
        [Column("userId")]
        public long UserId { get; set; }
        [Column("totalPrice")]
        public int TotalPrice { get; set; }
        [Column("createAt", TypeName = "date")]
        public DateTime CreateAt { get; set; }
        [Column("promocodeId")]
        public long? PromocodeId { get; set; }
        [Column("paymentType")]
        [StringLength(100)]
        public string PaymentType { get; set; }
        [Column("endAt", TypeName = "date")]
        public DateTime EndAt { get; set; }

        [ForeignKey(nameof(PromocodeId))]
        [InverseProperty("Carts")]
        public virtual Promocode Promocode { get; set; }
        [ForeignKey(nameof(UserId))]
        [InverseProperty("Carts")]
        public virtual User User { get; set; }
        [InverseProperty(nameof(CartProduct.Cart))]
        public virtual ICollection<CartProduct> CartProducts { get; set; }
        [InverseProperty(nameof(Ticket.Cart))]
        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}
