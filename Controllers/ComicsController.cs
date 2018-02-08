using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VueDemo.Domain.Entities;
using VueDemo.Domain.Repositories.Interfaces;

namespace VueDemo.Web.Controllers
{
    public class ComicsController : Controller
    {
        private IComicsRepository repo;

        public ComicsController(IComicsRepository repoParam)
        {
            this.repo = repoParam;
        }

        [HttpGet]
        [Route("api/[controller]")]
        public async Task<List<ComicBook>> Get()
        {
            return await repo.Get().Where(x => x.IsDeleted == false).OrderBy(x => x.Title).ToListAsync();
        }
    }
}
