using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace CinemaProject.Data.Models.Entities
{
    [Table("Cinema")]
    public partial class Cinema : IEntity
    {
        public Cinema()
        {
            Halls = new HashSet<Hall>();
        }

        [Key]
        [Column("cinemaId")]
        public long CinemaId { get; set; }
        [Required]
        [StringLength(100)]
        public string Adress { get; set; }
        [Column("cityId")]
        public long CityId { get; set; }

        [ForeignKey(nameof(CityId))]
        [InverseProperty("Cinemas")]
        public virtual City City { get; set; }
        [InverseProperty(nameof(Hall.Cinema))]
        public virtual ICollection<Hall> Halls { get; set; }
    }
}
