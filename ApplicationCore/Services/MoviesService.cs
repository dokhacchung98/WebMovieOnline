using ApplicationCore.Repositories;
using Common.Service;
using Infrastructure.Entities;

namespace ApplicationCore.Services
{
    public class MoviesService : EntityService<Movie>, IMoviesService
    {
        private readonly IMoviesRepository _repository;

        public MoviesService(IMoviesRepository repository) : base(repository)
        {
            _repository = repository;
        }
    }
}