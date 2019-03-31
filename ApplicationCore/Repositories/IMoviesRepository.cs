﻿using Common.GenericRepository;
using Infrastructure.Entities;

namespace ApplicationCore.Repositories
{
    public interface IMoviesRepository : IGenericRepository<Movie>
    {
    }
}