using MediatR;

namespace CinemaProject.Queries
{
    public class GetAllItemsInCartQueryHandler
    {
        public int CartId { get; set; }
    }
}