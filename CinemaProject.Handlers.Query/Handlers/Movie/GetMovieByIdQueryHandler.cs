using CinemaProject.Data.Infrastructure.Repository;
using CinemaProject.Models.Requests.Queries.Requests.Movie;
using CinemaProject.Models.Requests.Queries.Responses.Movie;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CinemaProject.Handlers.Query.Handlers.Movie
{
    public class GetMovieByIdQueryHandler : IRequestHandler<GetMovieByIdQuery, GetMovieByIdReponse>
    {
        private readonly IRepository<Data.Models.Entities.Movie> _movieRepository;

        public GetMovieByIdQueryHandler(IRepository<Data.Models.Entities.Movie> movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public async Task<GetMovieByIdReponse> Handle(GetMovieByIdQuery request, CancellationToken cancellationToken)
        {
            Data.Models.Entities.Movie? movie;
            var response = new GetMovieByIdReponse();

            if (request.Includes.Any())
            {
                var movieQuery = _movieRepository.Query();

                foreach (var includedPath in request.Includes)
                {
                    movieQuery = movieQuery.Include(includedPath);
                }

                movie = await movieQuery.FirstOrDefaultAsync(m => m.MovieId == request.MovieId, cancellationToken);

                response.Movie = movie;

                return response;
            }

            movie = await _movieRepository.GetByIdAsync(request.MovieId);

            response.Movie = movie;

            return response;
        }
    }
}
