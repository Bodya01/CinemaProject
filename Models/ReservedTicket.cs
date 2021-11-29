using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace CinemaProject.Data
{
    [Table("reservedTicket")]
    public partial class ReservedTicket
    {
        [Key]
        [Column("reservedTicketId")]
        public long ReservedTicketId { get; set; }
    }
}
