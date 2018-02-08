using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VueDemo.Domain.Entities
{
    public class ComicBook : BaseEntity
    {
        public string Title { get; set; }

        public string IssueDate { get; set; }

        public string Characters { get; set; }

        public string Publisher { get; set; }

        public int IssueNumber { get; set; }

        public string ImgUrl { get; set; }
    }
}
