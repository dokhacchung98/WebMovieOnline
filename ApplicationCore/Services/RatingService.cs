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
    public class RatingService : EntityService<Rating>, IRatingService
    {
        private readonly IRatingRepository _ratingRepository;
        public RatingService(IRatingRepository repository) : base(repository)
        {
            _ratingRepository = repository;
        }

        public Rating Find(Guid IdMovie, string IdUse)
        {
            return _ratingRepository.Find(IdMovie, IdUse);
        }

        public ICollection<Rating> GetAllRatingByIdMovie(Guid IdMovie)
        {
            return _ratingRepository.GetAllRatingByIdMovie(IdMovie);
        }
    }
}