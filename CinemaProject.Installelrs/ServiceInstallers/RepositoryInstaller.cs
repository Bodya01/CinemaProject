using CinemaProject.Data.Infrastructure.Repository;
using CinemaProject.Data.Models.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CinemaProject.Installers.ServiceInstallers
{
    public class RepositoryInstaller : IServiceInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IRepository<Cart>, Repository<Cart>>();
            services.AddScoped<IRepository<CartProduct>, Repository<CartProduct>>();
            services.AddScoped<IRepository<Category>, Repository<Category>>();
            services.AddScoped<IRepository<Cinema>, Repository<Cinema>>();
            services.AddScoped<IRepository<City>, Repository<City>>();
            services.AddScoped<IRepository<Demonstration>, Repository<Demonstration>>();
            services.AddScoped<IRepository<Hall>, Repository<Hall>>();
            services.AddScoped<IRepository<Location>, Repository<Location>>();
            services.AddScoped<IRepository<Movie>, Repository<Movie>>();
            services.AddScoped<IRepository<MovieRating>, Repository<MovieRating>>();
            services.AddScoped<IRepository<MovieSubcategory>, Repository<MovieSubcategory>>();
            services.AddScoped<IRepository<Permission>, Repository<Permission>>();
            services.AddScoped<IRepository<Product>, Repository<Product>>();
            services.AddScoped<IRepository<Promocode>, Repository<Promocode>>();
            services.AddScoped<IRepository<Reciept>, Repository<Reciept>>();
            services.AddScoped<IRepository<ReservedTicket>, Repository<ReservedTicket>>();
            services.AddScoped<IRepository<Role>, Repository<Role>>();
            services.AddScoped<IRepository<Seat>, Repository<Seat>>();
            services.AddScoped<IRepository<Session>, Repository<Session>>();
            services.AddScoped<IRepository<Subcategory>, Repository<Subcategory>>();
            services.AddScoped<IRepository<Ticket>, Repository<Ticket>>();
            services.AddScoped<IRepository<User>, Repository<User>>();
        }
    }
}
