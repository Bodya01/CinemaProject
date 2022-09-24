using CinemaProject.Models.Requests.Queries.Responses.Movie;
using MediatR;

namespace CinemaProject.Models.Requests.Queries.Requests.Movie
{
    public class GetMovieByIdQuery : IRequest<GetMovieByIdReponse>
    {
        public int MovieId { get; set; }
        public List<string> Includes { get; set; } = new();
    }
}
