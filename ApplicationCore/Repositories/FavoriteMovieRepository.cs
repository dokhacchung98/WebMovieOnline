﻿using Common.GenericRepository;
using Infrastructure.DataContext;
using Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Repositories
{
    public class FavoriteMovieRepository : GenericRepository<FavoriteMovie>, IFavoriteMovieRepository
    {
        public FavoriteMovieRepository(MovieDbContext dbContext) : base(dbContext)
        {
        }

        public bool ExistObject(Guid idMovie, string idUser)
        {

            IQueryable<FavoriteMovie> favoriteMovie = _dbContext.FavoriteMovies.Where(
                m => m.MovieId.Equals(idMovie) && m.UserId.Equals(idUser));
            if (favoriteMovie.Count() > 0)
            {
                return true;
            }
            return false;
        }

        public FavoriteMovie Find(Guid idMovie, string idUser)
        {
            return _dbContext.FavoriteMovies.Where(t => t.MovieId == idMovie && t.UserId == idUser).FirstOrDefault();
        }

        public ICollection<FavoriteMovie> GetFavoriteMoviesByUserId(string idUser)
        {
            return _dbContext.FavoriteMovies.Where(t => t.UserId.Equals(idUser)).ToList();
        }
    }
}
