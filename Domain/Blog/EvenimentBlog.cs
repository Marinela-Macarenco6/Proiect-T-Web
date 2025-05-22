using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Domain.Blog
{
    public class EvenimentBlog
    {
        public int Id { get; set; }
        public string Titlu { get; set; }
        public string Descriere { get; set; }
        public string ImagineUrl { get; set; }
        public DateTime Data { get; set; }
        public string Slug { get; set; }
        public string Categorie { get; set; }
    }
}