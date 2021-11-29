using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace CinemaProject.Data
{
    [Table("Cinema")]
    public partial class Cinema
    {
        public Cinema()
        {
            Halls = new HashSet<Hall>();
        }

        [Key]
        [Column("cinemaId")]
        public long CinemaId { get; set; }
        [Required]
        [StringLength(10)]
        public string Adrees { get; set; }
        [Column("cityId")]
        public long CityId { get; set; }

        [ForeignKey(nameof(CityId))]
        [InverseProperty("Cinemas")]
        public virtual City City { get; set; }
        [InverseProperty(nameof(Hall.Cinema))]
        public virtual ICollection<Hall> Halls { get; set; }
    }
}
