using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace CinemaProject.Data.Models.Entities
{
    [Table("reservedTicket")]
    public partial class ReservedTicket : IEntity
    {
        [Key]
        [Column("reservedTicketId")]
        public long ReservedTicketId { get; set; }
    }
}
