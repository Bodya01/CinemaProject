using CinemaProject.Modlels.Requests.Queries.Requests;
using CinemaProject.Modlels.Requests.Queries.Responses;
using MediatR;

namespace CinemaProject.Handlers.Query.Handlers
{
    public class GetAllItemsInCartQueryHandler : IRequestHandler<GetAllItemsInCartQuery, GetAllItemsInCartResponse>
    {
        public Task<GetAllItemsInCartResponse> Handle(GetAllItemsInCartQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
