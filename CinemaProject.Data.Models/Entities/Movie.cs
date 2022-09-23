using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace CinemaProject.Data.Models.Entities
{
    [Table("Movie")]
    public partial class Movie : IEntity
    {
        public Movie()
        {
            MovieRatings = new HashSet<MovieRating>();
            MovieSubcategories = new HashSet<MovieSubcategory>();
            Sessions = new HashSet<Session>();
        }

        [Key]
        [Column("movieId")]
        public long MovieId { get; set; }
        [Required]
        [Column("nameMovie")]
        [StringLength(50)]
        public string NameMovie { get; set; }
        [Column("ageRestriction")]
        public int AgeRestriction { get; set; }
        [Required]
        [Column("movieDescription")]
        [StringLength(100)]
        public string MovieDescription { get; set; }
        [Column("createAt", TypeName = "date")]
        public DateTime CreateAt { get; set; }

        [Required]
        [Column("moviePhotoPath")]
        public string MoviePhotoPath { get; set; }
        [Required]
        [Column("moviePreviewPath")]
        public string MoviePreviewPath { get; set; }
        [Required]
        [Column("movieTrailerPath")]
        public string MovieTrailerPath { get; set; }

        [InverseProperty(nameof(MovieRating.Movie))]
        public virtual ICollection<MovieRating> MovieRatings { get; set; }
        [InverseProperty(nameof(MovieSubcategory.Movie))]
        public virtual ICollection<MovieSubcategory> MovieSubcategories { get; set; }
        [InverseProperty(nameof(Session.Movie))]
        public virtual ICollection<Session> Sessions { get; set; }
    }
}
