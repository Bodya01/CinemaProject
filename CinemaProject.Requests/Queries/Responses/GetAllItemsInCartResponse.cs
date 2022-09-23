using CinemaProject.Data.Models.Entities;
using System.Collections.Generic;

namespace CinemaProject.Modlels.Requests.Queries.Responses
{
    public class GetAllItemsInCartResponse
    {
        public List<Product>? CartProducts { get; set; }
    }
}
