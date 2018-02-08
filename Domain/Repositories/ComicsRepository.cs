using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VueDemo.Domain.Entities;
using VueDemo.Domain.Repositories.Abstract;
using VueDemo.Domain.Repositories.Interfaces;

namespace VueDemo.Domain.Repositories
{
    public class ComicsRepository : BaseRepository<ComicBook>, IComicsRepository
    {
        public ComicsRepository(ComicsContext context) : base(context) { }
    }
}
