using System.Data.Entity;
using SkillSwaps.Models.Session;

namespace Business_Logic.Core
{
    public class SessionContext : DbContext
    {
        public SessionContext() : base("name=DbSkillSwap") { }
        public virtual DbSet<USessionDbTable> Session { get; set; }
    }
}

