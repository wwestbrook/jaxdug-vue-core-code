using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VueDemo.Domain.Entities;

namespace VueDemo.Domain
{
    public static class DbInitializer
    {
        public static void Initialize(ComicsContext context)
        {
            //context.Database.Migrate();
            //context.Database.EnsureDeleted();
            //context.Database.EnsureCreated();

            if (!context.Comics.Any())
            {
                var comics = new List<ComicBook>();

                comics.Add(new ComicBook { Title = "The Uncanny X-Men", Publisher="Marvel", Characters = "Wolverine, Cyclops, Storm, Jean Grey", IssueNumber=86, IssueDate="Oct 1984", ImgUrl = "" });
                comics.Add(new ComicBook { Title = "Detective Comics", Publisher = "DC", Characters = "Batman, Bruce Wayne, Alfred Pannyworth", IssueNumber = 300, IssueDate = "Dec 1997", ImgUrl = "" });
                comics.Add(new ComicBook { Title = "Action Comics", Publisher = "DC", Characters = "Superman, Clark Kent, Lois Lane", IssueNumber = 14, IssueDate = "Aug 1953", ImgUrl = "" });
                comics.Add(new ComicBook { Title = "Batman", Publisher = "DC", Characters = "Bruce Wayne, Alfred Pannyworth, Damian Wayne", IssueNumber = 500, IssueDate = "May 2017", ImgUrl = "" });
                comics.Add(new ComicBook { Title = "The Justice League", Publisher = "DC", Characters = "Batman, Superman, Wonder Woman, The Flash", IssueNumber = 211, IssueDate = "Jun 2000", ImgUrl = "" });
                comics.Add(new ComicBook { Title = "Iron Man", Publisher = "Marvel", Characters = "Tony Stark, Pepper Potts", IssueNumber = 18, IssueDate = "March 2015", ImgUrl = "" });
                comics.Add(new ComicBook { Title = "The Mighty Thor", Publisher = "Marvel", Characters = "Jane, Donald Blake, Odin, Loki", IssueNumber = 62, IssueDate = "Nov 1974", ImgUrl = "" });
                comics.Add(new ComicBook { Title = "Captain America", Publisher = "Marvel", Characters = "Steve Rogers, Bucky Barnes", IssueNumber = 211, IssueDate = "July 1776", ImgUrl = "" });
                comics.Add(new ComicBook { Title = "The Green Lantern", Publisher = "DC", Characters = "Hal Jordan, Guy Garnder, Jon Stewart", IssueNumber = 101, IssueDate = "Feb 1993", ImgUrl = "" });

                foreach (var comic in comics)
                {
                    context.Add(comic);
                }
                context.SaveChanges();
            }

            
        }
    }
}
