using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace CinemaProject.Data
{
    [Table("Location")]
    public partial class Location
    {
        [Key]
        public long LocationId { get; set; }
        [Required]
        [Column("district")]
        [StringLength(30)]
        public string District { get; set; }
        [Required]
        [Column("st")]
        [StringLength(30)]
        public string St { get; set; }
        [Column("cityId")]
        public long CityId { get; set; }

        [ForeignKey(nameof(CityId))]
        [InverseProperty("Locations")]
        public virtual City City { get; set; }
    }
}
