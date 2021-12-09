using CinemaProject.Data;
using CinemaProject.Models.CartModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaProject.Controllers
{
    public class CartController : Controller
    {
        private ApplicationDbContext data = new ApplicationDbContext();

        private Cart CreateNewCart(User currentUser)
        {
            Cart cart = new Cart
            {
                UserId = currentUser.Id,
                User = currentUser
                //CreateAt = System.DateTime.Now,                
            };
            data.Carts.Add(cart);
            data.SaveChanges();
            return cart;
        }

        [HttpPost]
        public async Task<IActionResult> AddProductToCart(CartModelView model)
        {
            if (model.product != null)
            {
                User currentUser = await data.Users.FirstOrDefaultAsync(x => x.UserName == User.Identity.Name);
                Cart cart;
                if (data.Carts.Where(x => x.UserId == currentUser.Id).Count() == 0)
                {
                    cart = CreateNewCart(currentUser);
                }
                else
                {
                    cart = await data.Carts.FirstOrDefaultAsync(x => x.User == currentUser);
                }
                data.CartProducts.Add(new CartProduct
                {
                    UserId = currentUser.Id,
                    CartId = cart.CartId,
                    Cart = cart,
                    ProductId = model.product.ProductId,
                    Product = data.Products.FirstOrDefault(x => x.ProductId == model.product.ProductId)
                });
                await data.SaveChangesAsync();
            }

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddTicketToCart(CartModelView model)
        {
            if (model.ticket != null)
            {
                User currentUser = await data.Users.FirstOrDefaultAsync(x => x.UserName== User.Identity.Name);
                Cart cart;
                if (data.Carts.Where(x => x.UserId == currentUser.Id).Count() == 0)
                {
                    cart = CreateNewCart(currentUser);
                }
                else
                {
                    cart = await data.Carts.FirstOrDefaultAsync(x => x.User == currentUser);
                }
                await data.Tickets.AddAsync(model.ticket);
                await data.SaveChangesAsync();
            }

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ClearCart(int? id)
        {
            if(id != null)
            {
                User currentUser = await data.Users.FirstOrDefaultAsync(x => x.UserName == User.Identity.Name);
                Cart cart = await data.Carts.FirstOrDefaultAsync(x => x.User == currentUser);
                foreach (var ticket in data.Tickets.Where(x =>  x.CartId == cart.CartId))
                {
                    data.Tickets.Remove(ticket);
                }
                foreach (var product in data.CartProducts.Where(x => x.CartId == cart.CartId))
                {
                    data.CartProducts.Remove(product);
                }
                data.Carts.Remove(cart);
                await data.SaveChangesAsync();
            }
            
            return View();
        }
    }
}
