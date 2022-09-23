using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace CinemaProject.Data.Models.Entities
{
    [Table("Seat")]
    [Microsoft.EntityFrameworkCore.Index(nameof(SeatId), nameof(HallId), Name = "FK_Seat", IsUnique = true)]
    public partial class Seat
    {
        public Seat()
        {
            Tickets = new HashSet<Ticket>();
        }

        [Key]
        [Column("seatId")]
        public long SeatId { get; set; }
        [Column("seatRow")]
        public int SeatRow { get; set; }
        [Column("seatNumber")]
        public int SeatNumber { get; set; }
        [Key]
        [Column("hallId")]
        public long HallId { get; set; }
        [Column("class")]
        public bool Class { get; set; }
        [Key]
        [Column("cinemaId")]
        public long CinemaId { get; set; }

        [ForeignKey("HallId,CinemaId")]
        [InverseProperty("Seats")]
        public virtual Hall Hall { get; set; }
        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}
