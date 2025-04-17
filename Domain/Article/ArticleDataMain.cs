using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Article
{
    public class ArticleDataMain
    {
        public string Title { get; set; }
        public string Teacher { get; set; }
        public EACategory Category { get; set; }
        public string Description { get; set; }
        public string ArticleImage { get; set; }
        public DateTime PublicationDateTime { get; set; }
        public int EnrolledUsers { get; set; }
        public int? ArticleId { get; set; }



    }
}
