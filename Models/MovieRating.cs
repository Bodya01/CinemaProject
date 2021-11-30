using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace CinemaProject.Data
{
    [Table("MovieRating")]
    public partial class MovieRating
    {
        [Key]
        [Column("movieRattingtId")]
        public long MovieRattingtId { get; set; }
        [Key]
        [Column("userId")]
        public long UserId { get; set; }
        [Key]
        [Column("movieId")]
        public long MovieId { get; set; }
        [Column("comment")]
        [StringLength(1000)]
        public string Comment { get; set; }
        [Column("mark")]
        public double Mark { get; set; }

        [ForeignKey(nameof(MovieId))]
        [InverseProperty("MovieRatings")]
        public virtual Movie Movie { get; set; }
        [ForeignKey(nameof(UserId))]
        [InverseProperty("MovieRatings")]
        public virtual User User { get; set; }
    }
}
