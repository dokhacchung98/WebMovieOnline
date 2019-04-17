using ApplicationCore.Repositories;
using Common.GenericRepository;
using Common.Service;
using Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public class ActorMovieService : EntityService<ActorMovie>, IActorMovieService
    {
        private readonly IActorMovieRepository _repository;
        public ActorMovieService(IActorMovieRepository repository) : base(repository)
        {
            _repository = repository;
        }

        public ActorMovie FindBy2Id(Guid movieId, Guid modelId)
        {
            return _repository.FindBy2Id(movieId, modelId);
        }

        public ICollection<Guid> GetIdActorByMovieId(Guid movieId)
        {
            return _repository.GetIdActorByMovieId(movieId);
        }
    }
}
