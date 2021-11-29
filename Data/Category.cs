using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace CinemaProject.Data
{
    [Table("Category")]
    public partial class Category
    {
        public Category()
        {
            Subcategories = new HashSet<Subcategory>();
        }

        [Key]
        [Column("categoryId")]
        public long CategoryId { get; set; }
        [Required]
        [Column("categoryName")]
        [StringLength(20)]
        public string CategoryName { get; set; }
        [Required]
        [Column("categoryDescription")]
        [StringLength(100)]
        public string CategoryDescription { get; set; }
        [Column("createAt", TypeName = "date")]
        public DateTime? CreateAt { get; set; }

        [InverseProperty(nameof(Subcategory.Category))]
        public virtual ICollection<Subcategory> Subcategories { get; set; }
    }
}
