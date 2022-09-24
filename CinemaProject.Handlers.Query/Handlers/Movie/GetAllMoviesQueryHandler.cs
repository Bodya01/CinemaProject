using CinemaProject.Data.Infrastructure.Repository;
using CinemaProject.Models.Requests.Queries.Requests.Movie;
using CinemaProject.Models.Requests.Queries.Responses.Movie;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CinemaProject.Handlers.Query.Handlers.Movie
{
    public class GetAllMoviesQueryHandler : IRequestHandler<GetAllMoviesQuery, GetAllMoviesResponse>
    {
        private readonly IRepository<Data.Models.Entities.Movie> _movieRepository;

        public GetAllMoviesQueryHandler(IRepository<Data.Models.Entities.Movie> movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public  async Task<GetAllMoviesResponse> Handle(GetAllMoviesQuery request, CancellationToken cancellationToken)
        {
            var movieQuery = _movieRepository.Query();

            foreach (var include in request.Includes)
            {
                movieQuery = movieQuery.Include(include);
            }

            var movies = await movieQuery.ToListAsync();

            var response = new GetAllMoviesResponse
            {
                Movies = movies,
            };

            return response;
        }
    }
}
