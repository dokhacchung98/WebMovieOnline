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
    public class ResolutionMovieService : EntityService<MovieResolution>, IResolutionMovieService
    {
        private readonly IResolutionMovieRepository _repository;
        public ResolutionMovieService(IResolutionMovieRepository repository) : base(repository)
        {
            _repository = repository;
        }

        public ICollection<Guid> GetIdResolutionByMovieId(Guid movieId)
        {
            return _repository.GetIdResolutionByMovieId(movieId);
        }

        public MovieResolution FindBy2Id(Guid movieId, Guid modelId)
        {
            return _repository.FindBy2Id(movieId, modelId);
        }
    }
}
