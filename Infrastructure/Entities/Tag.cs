﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entities
{
    public class Tag : BaseEntity
    {
        public string NameTag { get; set; }
        public int CountTag { get; set; }

        #region Relation
        public ICollection<Movie> Movies { get; set; }
        #endregion
    }
}