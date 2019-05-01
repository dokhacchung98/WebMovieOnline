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
    public class FavoriteMovieService : EntityService<FavoriteMovie>, IFavoriteMovieService
    {
        private readonly IFavoriteMovieRepository _repository;

        public FavoriteMovieService(IFavoriteMovieRepository repository) : base(repository)
        {
            _repository = repository;
        }

        public bool ExistObject(Guid idMovie, string idUser)
        {
            return _repository.ExistObject(idMovie, idUser);
        }

        public FavoriteMovie Find(Guid idMovie, string idUser)
        {
            return _repository.Find(idMovie, idUser);
        }

        public ICollection<FavoriteMovie> GetFavoriteMoviesByUserId(string idUser)
        {
            return _repository.GetFavoriteMoviesByUserId(idUser);
        }
    }
}
