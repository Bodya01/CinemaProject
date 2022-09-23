using CinemaProject.Modlels.Requests.Queries.Responses;
using MediatR;

namespace CinemaProject.Modlels.Requests.Queries.Requests
{
    public class GetAllItemsInCartQuery : IRequest<GetAllItemsInCartResponse>
    {
        public int CartId { get; set; }
    }
}
