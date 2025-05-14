using System.Data.Entity;
using SkillSwaps.Domain.Comments;

namespace SkillSwaps.DbDataContext
{
    public class CommentsContext : DbContext
    {
        public CommentsContext() : base("name=DbSkillSwap")
        {
        }

        public DbSet<CTable> Comments { get; set; }

    }
}