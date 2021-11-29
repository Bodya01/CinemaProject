using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace CinemaProject.Data
{
    [Table("User")]
    public partial class User
    {
        public User()
        {
            Carts = new HashSet<Cart>();
            MovieRatings = new HashSet<MovieRating>();
            UserRoles = new HashSet<UserRole>();
        }

        [Key]
        [Column("userId")]
        public long UserId { get; set; }
        [Required]
        [Column("userName")]
        [StringLength(20)]
        public string UserName { get; set; }
        [Required]
        [Column("userSurname")]
        [StringLength(30)]
        public string UserSurname { get; set; }
        [Required]
        [Column("userEmail")]
        [StringLength(50)]
        public string UserEmail { get; set; }
        [Required]
        [Column("userPassword")]
        [StringLength(1000)]
        public string UserPassword { get; set; }
        [Column("userPhone")]
        [StringLength(30)]
        public string UserPhone { get; set; }

        [InverseProperty(nameof(Cart.User))]
        public virtual ICollection<Cart> Carts { get; set; }
        [InverseProperty(nameof(MovieRating.User))]
        public virtual ICollection<MovieRating> MovieRatings { get; set; }
        [InverseProperty(nameof(UserRole.User))]
        public virtual ICollection<UserRole> UserRoles { get; set; }
    }
}
