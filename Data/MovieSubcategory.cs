using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace CinemaProject.Data
{
    public partial class MovieSubcategory
    {
        [Key]
        [Column("movieSubcategoriesId")]
        public long MovieSubcategoriesId { get; set; }
        [Key]
        [Column("subcategoryId")]
        public long SubcategoryId { get; set; }
        [Key]
        [Column("movieId")]
        public long MovieId { get; set; }

        [ForeignKey(nameof(MovieId))]
        [InverseProperty("MovieSubcategories")]
        public virtual Movie Movie { get; set; }
        [ForeignKey(nameof(SubcategoryId))]
        [InverseProperty("MovieSubcategories")]
        public virtual Subcategory Subcategory { get; set; }
    }
}
