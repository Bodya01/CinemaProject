using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace CinemaProject.Data
{
    [Table("Hall")]
    public partial class Hall
    {
        public Hall()
        {
            Seats = new HashSet<Seat>();
            Sessions = new HashSet<Session>();
        }

        [Key]
        [Column("hallId")]
        public long HallId { get; set; }
        [Required]
        [Column("hallName")]
        [StringLength(20)]
        public string HallName { get; set; }
        [Column("hallSeatsNumber")]
        public long HallSeatsNumber { get; set; }
        [Required]
        [Column("format")]
        [StringLength(20)]
        public string Format { get; set; }
        [Key]
        [Column("cinemaId")]
        public long CinemaId { get; set; }

        [ForeignKey(nameof(CinemaId))]
        [InverseProperty("Halls")]
        public virtual Cinema Cinema { get; set; }
        [InverseProperty(nameof(Seat.Hall))]
        public virtual ICollection<Seat> Seats { get; set; }
        [InverseProperty(nameof(Session.Hall))]
        public virtual ICollection<Session> Sessions { get; set; }
    }
}
