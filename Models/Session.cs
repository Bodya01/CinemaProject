using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace CinemaProject.Data
{
    [Table("Session")]
    public partial class Session
    {
        public Session()
        {
            Tickets = new HashSet<Ticket>();
        }

        [Key]
        [Column("sessionId")]
        public long SessionId { get; set; }
        [Column("screenStart", TypeName = "date")]
        public DateTime ScreenStart { get; set; }
        [Column("screenEnd", TypeName = "date")]
        public DateTime ScreenEnd { get; set; }
        [Key]
        [Column("movieId")]
        public long MovieId { get; set; }
        [Key]
        [Column("hallId")]
        public long HallId { get; set; }
        [Column("CinemaId")]
        public long CinemaId { get; set; }
        [Key]
        [Column("demonstrationId")]
        public long DemonstrationId { get; set; }

        [ForeignKey(nameof(DemonstrationId))]
        [InverseProperty("Sessions")]
        public virtual Demonstration Demonstration { get; set; }
        [ForeignKey("HallId, CinemaId")]
        [InverseProperty("Sessions")]
        public virtual Hall Hall { get; set; }
        [ForeignKey(nameof(MovieId))]
        [InverseProperty("Sessions")]
        public virtual Movie Movie { get; set; }
        [InverseProperty(nameof(Ticket.Session))]
        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}
