﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace CinemaProject.Data
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
        [StringLength(10)]
        public string PromocodeName { get; set; }
        [Required]
        [Column("promocodeDescription")]
        [StringLength(10)]
        public string PromocodeDescription { get; set; }
        [Column("countUse")]
        public int CountUse { get; set; }

        [InverseProperty(nameof(Cart.Promocode))]
        public virtual ICollection<Cart> Carts { get; set; }
    }
}
