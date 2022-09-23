using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace CinemaProject.Data.Models.Entities
{
    [Table("City")]
    public partial class City
    {
        public City()
        {
            Cinemas = new HashSet<Cinema>();
            Locations = new HashSet<Location>();
        }

        [Key]
        [Column("cityId")]
        public long CityId { get; set; }
        [Required]
        [Column("cityName")]
        [StringLength(20)]
        public string CityName { get; set; }

        [InverseProperty(nameof(Cinema.City))]
        public virtual ICollection<Cinema> Cinemas { get; set; }
        [InverseProperty(nameof(Location.City))]
        public virtual ICollection<Location> Locations { get; set; }
    }
}
