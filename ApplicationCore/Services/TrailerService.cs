using ApplicationCore.Repositories;
using Common.GenericRepository;
using Common.Service;
using Infrastructure.Entities;
using System.Collections.Generic;

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

        public ICollection<Trailer> GetNewTrailerByNumber(int countTrailer)
        {
            return _repository.GetNewTrailerByNumber(countTrailer);
        }
    }
}