using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace CinemaProject.Data.Models.Entities
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
