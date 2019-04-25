using ApplicationCore.Repositories;
using Common.GenericRepository;
using Common.Service;
using Infrastructure.Entities;

namespace ApplicationCore.Services
{
    public class TrailerService : EntityService<Trailer>, ITrailerService
    {
        public readonly ITrailerRepository _repository;
        public TrailerService(ITrailerRepository repository) : base(repository)
        {
            _repository = repository;
        }

        public object SearchTrailerByName(string name)
        {
            return _repository.SearchTrailerByName(name);
        }
    }
}