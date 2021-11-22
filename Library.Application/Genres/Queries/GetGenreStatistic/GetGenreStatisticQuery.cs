﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Genres.Queries.GetGenreStatistic
{
    public class GetGenreStatisticQuery : IRequest<GenreStatisticVm>
    {
        public Guid Id { get; set; }
    }
}
