using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace CinemaProject.Data.Models.Entities
{
    [Table("Ticket")]
    public partial class Ticket : IEntity
    {
        [Key]
        [Column("ticketId")]
        public long TicketId { get; set; }
        [Key]
        [Column("seatId")]
        public long SeatId { get; set; }
        [Column("createdAt", TypeName = "date")]
        public DateTime CreatedAt { get; set; }
        [Key]
        [Column("hallId")]
        public long HallId { get; set; }
        [Key]
        [Column("sessionId")]
        public long SessionId { get; set; }
        [Key]
        [Column("movieId")]
        public long MovieId { get; set; }
        [Key]
        [Column("cinemaId")]
        public long CinemaId { get; set; }
        [Key]
        [Column("cartId")]
        public long CartId { get; set; }
        [Key]
        [Column("userId")]
        public long UserId { get; set; }
        [Key]
        [Column("demonstrationId")]
        public long DemonstrationId { get; set; }
        [Column("ticketPrice")]
        public double TicketPrice { get; set; }

        [ForeignKey("CartId,UserId")]
        [InverseProperty("Tickets")]
        public virtual Cart Cart { get; set; }
        public virtual Seat Seat { get; set; }
        [ForeignKey("SessionId,MovieId,HallId,DemonstrationId")]
        [InverseProperty("Tickets")]
        public virtual Session Session { get; set; }
    }
}
