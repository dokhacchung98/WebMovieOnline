﻿using Common.GenericRepository;
using Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Repositories
{
    public interface IRatingRepository : IGenericRepository<Rating>
    {
        Rating Find(Guid IdMovie, string IdUse);

        ICollection<Rating> GetAllRatingByIdMovie(Guid IdMovie);
    }
}
