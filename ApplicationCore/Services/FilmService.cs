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
    public class FilmService : EntityService<Film>, IFilmService
    {
        private readonly IFilmRepository _repository;

        public FilmService(IFilmRepository repository) : base(repository)
        {
            _repository = repository;
        }

        public IList<Film> GetAllFilmInSeriesTV(Guid IdMovie)
        {
            return _repository.GetAllFilmInSeriesTV(IdMovie);
        }

        public Film GetFilmByIdMovie(Guid IdMovie)
        {
            return _repository.GetFilmByIdMovie(IdMovie);
        }

        public ICollection<Film> GetFilmsByMovieId(Guid id)
        {
            return _repository.GetFilmsByMovieId(id);
        }
    }
}
