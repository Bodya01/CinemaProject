using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

#nullable disable

namespace CinemaProject.Data
{
    public partial class ApplicationDbContext : IdentityDbContext<User,Role, long>
    {
        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cart> Carts { get; set; }
        public virtual DbSet<CartProduct> CartProducts { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Cinema> Cinemas { get; set; }
        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<Demonstration> Demonstrations { get; set; }
        public virtual DbSet<Hall> Halls { get; set; }
        public virtual DbSet<Location> Locations { get; set; }
        public virtual DbSet<Movie> Movies { get; set; }
        public virtual DbSet<MovieRating> MovieRatings { get; set; }
        public virtual DbSet<MovieSubcategory> MovieSubcategories { get; set; }
        public virtual DbSet<Permission> Permissions { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Promocode> Promocodes { get; set; }
        public virtual DbSet<Reciept> Reciepts { get; set; }
        public virtual DbSet<ReservedTicket> ReservedTickets { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<RolePermission> RolePermissions { get; set; }
        public virtual DbSet<Seat> Seats { get; set; }
        public virtual DbSet<Session> Sessions { get; set; }
        public virtual DbSet<Subcategory> Subcategories { get; set; }
        public virtual DbSet<Ticket> Tickets { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserRole> UserRoles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

                optionsBuilder.UseSqlServer("Server= DESKTOP-MBGGAE3;Database=CinemaProject;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.HasAnnotation("Relational:Collation", "Cyrillic_General_CI_AS");

            modelBuilder.Entity<Cart>(entity =>
            {
                entity.HasKey(e => new { e.CartId, e.UserId });

                entity.Property(e => e.PaymentType).IsFixedLength(true);

                entity.HasOne(d => d.Promocode)
                    .WithMany(p => p.Carts)
                    .HasForeignKey(d => d.PromocodeId)
                    .HasConstraintName("FK_Cart_Promocode");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Carts)
                    .HasForeignKey(d => d.UserId)
                    .HasPrincipalKey(x => x.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Cart_User");

            });

            modelBuilder.Entity<CartProduct>(entity =>
            {
                entity.HasKey(e => new { e.CartProductId, e.ProductId, e.UserId, e.CartId })
                    .HasName("PK_CartProducts_1");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.CartProducts)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CartProducts_Product");

                entity.HasOne(d => d.Cart)
                    .WithMany(p => p.CartProducts)
                    .HasForeignKey(d => new { d.CartId, d.UserId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CartProducts_Cart");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.Property(e => e.CategoryId).ValueGeneratedOnAdd();

                entity.Property(e => e.CategoryDescription)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.CategoryName)
                    .IsUnicode(false)
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<Cinema>(entity =>
            {
                entity.Property(e => e.CinemaId).ValueGeneratedOnAdd();

                entity.Property(e => e.Adrees).IsFixedLength(true);

                entity.HasOne(d => d.City)
                    .WithMany(p => p.Cinemas)
                    .HasForeignKey(d => d.CityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Cinema_City");
            });

            modelBuilder.Entity<City>(entity =>
            {
                entity.Property(e => e.CityId).ValueGeneratedOnAdd();

                entity.Property(e => e.CityName).IsFixedLength(true);
            });

            modelBuilder.Entity<Demonstration>(entity =>
            {
                entity.Property(e => e.DemonstrationId).ValueGeneratedOnAdd();

                entity.Property(e => e.DemonstrationName)
                    .IsUnicode(false)
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<Hall>(entity =>
            {
                entity.HasKey(e => new { e.HallId, e.CinemaId });

                entity.Property(e => e.Format).IsFixedLength(true);

                entity.Property(e => e.HallName)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.HasOne(d => d.Cinema)
                    .WithMany(p => p.Halls)
                    .HasForeignKey(d => d.CinemaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Hall_Cinema");
            });

            modelBuilder.Entity<Location>(entity =>
            {
                entity.Property(e => e.LocationId).ValueGeneratedOnAdd();

                entity.Property(e => e.District)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.St)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.HasOne(d => d.City)
                    .WithMany(p => p.Locations)
                    .HasForeignKey(d => d.CityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Location_City");
            });

            modelBuilder.Entity<Movie>(entity =>
            {
                entity.Property(e => e.MovieId).ValueGeneratedOnAdd();

                entity.Property(e => e.MovieDescription).IsFixedLength(true);

                entity.Property(e => e.NameMovie).IsFixedLength(true);
            });

            modelBuilder.Entity<MovieRating>(entity =>
            {
                entity.HasKey(e => new { e.MovieRattingtId, e.UserId, e.MovieId });

                entity.Property(e => e.Comment)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.HasOne(d => d.Movie)
                    .WithMany(p => p.MovieRatings)
                    .HasForeignKey(d => d.MovieId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MovieRating_Movie");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.MovieRatings)
                    .HasForeignKey(d => d.UserId)
                     .HasPrincipalKey(x => x.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MovieRating_User");
            });

            modelBuilder.Entity<MovieSubcategory>(entity =>
            {
                entity.HasKey(e => new { e.MovieSubcategoriesId, e.SubcategoryId, e.MovieId });

                entity.HasOne(d => d.Movie)
                    .WithMany(p => p.MovieSubcategories)
                    .HasForeignKey(d => d.MovieId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MovieSubcategories_Movie");

                entity.HasOne(d => d.Subcategory)
                    .WithMany(p => p.MovieSubcategories)
                    .HasForeignKey(d => d.SubcategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MovieSubcategories_Subcategory");
            });

            modelBuilder.Entity<Permission>(entity =>
            {
                entity.Property(e => e.PermissionId).ValueGeneratedOnAdd();

                entity.Property(e => e.PermissionDescription).IsFixedLength(true);

                entity.Property(e => e.PermissionName).IsFixedLength(true);
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(e => e.ProductId).ValueGeneratedOnAdd();

                entity.Property(e => e.ProductName)
                    .IsUnicode(false)
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<Promocode>(entity =>
            {
                entity.Property(e => e.PromocodeId).ValueGeneratedOnAdd();

                entity.Property(e => e.PromocodeDescription).IsFixedLength(true);

                entity.Property(e => e.PromocodeName).IsFixedLength(true);
            });

            modelBuilder.Entity<Reciept>(entity =>
            {
                entity.Property(e => e.RecieptId).ValueGeneratedOnAdd();

                entity.Property(e => e.PaymentType).IsFixedLength(true);

                entity.Property(e => e.TotalPrice).IsFixedLength(true);
            });

            modelBuilder.Entity<ReservedTicket>(entity =>
            {
                entity.Property(e => e.ReservedTicketId).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.Property(e => e.RoleId).ValueGeneratedNever();

                entity.Property(e => e.RoleDescription).IsFixedLength(true);

                entity.Property(e => e.RoleName).IsFixedLength(true);
            });

            modelBuilder.Entity<RolePermission>(entity =>
            {
                entity.HasKey(e => new { e.RolePermissionsId, e.RoleId, e.PermissionId })
                    .HasName("PK_rolePermissions");

                entity.HasOne(d => d.Permission)
                    .WithMany(p => p.RolePermissions)
                    .HasForeignKey(d => d.PermissionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_rolePermissions_Permission");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.RolePermissions)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_rolePermissions_Role");
            });

            modelBuilder.Entity<Seat>(entity =>
            {
                entity.HasKey(e => new { e.SeatId, e.HallId, e.CinemaId });

                entity.HasOne(d => d.Hall)
                    .WithMany(p => p.Seats)
                    .HasForeignKey(d => new { d.HallId, d.CinemaId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Seat_Hall");
            });

            modelBuilder.Entity<Session>(entity =>
            {
                entity.HasKey(e => new { e.Sessiond, e.MovieId, e.HallId, e.DemonstrationId })
                    .HasName("PK_Session_1");

                entity.HasOne(d => d.Demonstration)
                    .WithMany(p => p.Sessions)
                    .HasForeignKey(d => d.DemonstrationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Session_Demonstration");

                entity.HasOne(d => d.Movie)
                    .WithMany(p => p.Sessions)
                    .HasForeignKey(d => d.MovieId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Session_Movie");

                entity.HasOne(d => d.Hall)
                    .WithMany(p => p.Sessions)
                    .HasForeignKey(d => new { d.HallId, d.CinamaId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Session_Hall");
            });

            modelBuilder.Entity<Subcategory>(entity =>
            {
                entity.Property(e => e.SubcategoryId).ValueGeneratedOnAdd();

                entity.Property(e => e.SubcategoryDescription)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.SubcategoryName)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Subcategories)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Subcategory_Category");
            });

            modelBuilder.Entity<Ticket>(entity =>
            {
                entity.HasKey(e => new { e.TicketId, e.SeatId, e.HallId, e.SessionId, e.MovieId, e.CinemaId, e.CartId, e.UserId, e.DemonstrationId });

                entity.HasOne(d => d.Cart)
                    .WithMany(p => p.Tickets)
                    .HasForeignKey(d => new { d.CartId, d.UserId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Ticket_Cart");

                entity.HasOne(d => d.Seat)
                    .WithMany(p => p.Tickets)
                    .HasPrincipalKey(p => new { p.SeatId, p.HallId })
                    .HasForeignKey(d => new { d.SeatId, d.HallId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Ticket_Seat1");

                entity.HasOne(d => d.Session)
                    .WithMany(p => p.Tickets)
                    .HasForeignKey(d => new { d.SessionId, d.MovieId, d.HallId, d.DemonstrationId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Ticket_Session1");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.UserId).ValueGeneratedNever();

                entity.Property(e => e.UserEmail).IsFixedLength(true);

                entity.Property(e => e.UserName).IsFixedLength(true);

              

                entity.Property(e => e.UserPhone).IsFixedLength(true);

                entity.Property(e => e.UserSurname).IsFixedLength(true);

                entity.HasIndex(e => e.UserEmail).IsUnique();


            });

            modelBuilder.Entity<UserRole>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId, e.UserRolesId });

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.UserRoles)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserRoles_Role");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserRoles)
                    .HasForeignKey(d => d.UserId)
                     .HasPrincipalKey(x => x.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserRoles_User");
            });

            OnModelCreatingPartial(modelBuilder);
            base.OnModelCreating(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
