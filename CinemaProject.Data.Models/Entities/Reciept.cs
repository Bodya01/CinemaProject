using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace CinemaProject.Data.Models.Entities
{
    [Table("Reciept")]
    public partial class Reciept
    {
        [Key]
        [Column("recieptId")]
        public long RecieptId { get; set; }
        [Required]
        [Column("totalPrice")]
        [StringLength(10)]
        public string TotalPrice { get; set; }
        [Required]
        [Column("paymentType")]
        [StringLength(20)]
        public string PaymentType { get; set; }
    }
}
