using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Article
{
    public class AprovedArticleDataMain
    {
        public string Title { get; set; }
        public string Teacher { get; set; }
        public EACategory Category { get; set; }
        public string Description { get; set; }
        public DateTime PublicationDateTime { get; set; }
        public int EnrolledUsers { get; set; }
        public int Id { get; set; }
        public string ImageUrl { get; set; }

        //public int TeacherId { get; set; }
        //public int TeacherPhone { get; set; }
    }
}
