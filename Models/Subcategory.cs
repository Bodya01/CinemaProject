using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace CinemaProject.Data
{
    [Table("Subcategory")]
    public partial class Subcategory
    {
        public Subcategory()
        {
            MovieSubcategories = new HashSet<MovieSubcategory>();
        }

        [Key]
        [Column("subcategoryId")]
        public long SubcategoryId { get; set; }
        [Required]
        [Column("subcategoryName")]
        [StringLength(20)]
        public string SubcategoryName { get; set; }
        [Required]
        [Column("subcategoryDescription")]
        [StringLength(100)]
        public string SubcategoryDescription { get; set; }
        [Column("categoryId")]
        public long CategoryId { get; set; }
        [Column("createAt", TypeName = "date")]
        public DateTime CreateAt { get; set; }

        [ForeignKey(nameof(CategoryId))]
        [InverseProperty("Subcategories")]
        public virtual Category Category { get; set; }
        [InverseProperty(nameof(MovieSubcategory.Subcategory))]
        public virtual ICollection<MovieSubcategory> MovieSubcategories { get; set; }
    }
}
