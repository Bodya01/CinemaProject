using CinemaProject.Models.Requests.Queries.Responses.Movie;
using MediatR;

namespace CinemaProject.Models.Requests.Queries.Requests.Movie
{
    public class GetAllMoviesQuery : IRequest<GetAllMoviesResponse>
    {
        public List<string> Includes { get; set; } = new List<string>();
    }
}
