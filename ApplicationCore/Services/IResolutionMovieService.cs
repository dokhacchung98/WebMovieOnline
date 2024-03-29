﻿using Common.Service;
using Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public interface IResolutionMovieService : IEntityService<MovieResolution>
    {
        ICollection<Guid> GetIdResolutionByMovieId(Guid movieId);

        MovieResolution FindBy2Id(Guid movieId, Guid modelId);
    }
}
