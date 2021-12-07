using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Claims;
using System.Threading.Tasks;

#nullable disable

namespace CinemaProject.Data
{
    [Table("User")]
    [Index(nameof(UserEmail), IsUnique = true)]
    public class User : IdentityUser<long>
    {


        public User() 
        {
            Carts = new HashSet<Cart>();
            MovieRatings = new HashSet<MovieRating>();
           
        }
        [Required]
        [Column("userSurname")]
        [StringLength(30)]
        public string UserSurname { get; set; }
        [Required]
        [Column("userEmail")]
        [StringLength(50)]
        public string UserEmail { get; set; }
      
        [Column("userPassword")]
        [StringLength(100)]
        public string UserPhone { get; set; }

        public string PhotoPath { get; set; }

        [InverseProperty(nameof(Cart.User))]
        public virtual ICollection<Cart> Carts { get; set; }
        [InverseProperty(nameof(MovieRating.User))]
        public virtual ICollection<MovieRating> MovieRatings { get; set; }
        

        
       
    }
}
