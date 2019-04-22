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
    public class DirectorMovieService : EntityService<DirectorMovie>, IDirectorMovieService
    {
        private readonly IDirectorMovieRepository _repository;
        public DirectorMovieService(IDirectorMovieRepository repository) : base(repository)
        {
            _repository = repository;
        }

        public ICollection<Guid> GetIdDirectorByMovieId(Guid movieId)
        {
            return _repository.GetIdDirectorByMovieId(movieId);
        }

        public DirectorMovie FindBy2Id(Guid movieId, Guid modelId)
        {
            return _repository.FindBy2Id(movieId, modelId);
        }
    }
}
