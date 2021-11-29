using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace CinemaProject.Data
{
    [Table("Demonstration")]
    public partial class Demonstration
    {
        public Demonstration()
        {
            Sessions = new HashSet<Session>();
        }

        [Key]
        [Column("demonstrationId")]
        public long DemonstrationId { get; set; }
        [Required]
        [Column("demonstrationName")]
        [StringLength(30)]
        public string DemonstrationName { get; set; }
        [Column("cof")]
        public double Cof { get; set; }

        [InverseProperty(nameof(Session.Demonstration))]
        public virtual ICollection<Session> Sessions { get; set; }
    }
}
