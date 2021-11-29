using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace CinemaProject.Data
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
