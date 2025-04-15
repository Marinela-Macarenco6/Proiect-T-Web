using Domain.Article;
using System.Data.Entity;

namespace Business_Logic.DbDataContext
{
    public class ArticleContext : DbContext
    {
        public ArticleContext() : base("name=DbSkillSwap") {}
        public DbSet<ADBTable> Articles { get; set; }
    }
}
