using System.Data.Entity;
using Domain.User;

namespace Business_Logic.DbDataContext.Seed
{
    public class UserContext : DbContext
    {
        public UserContext() : base("name=DbSkillSwap") { }
        public DbSet<UserRegData> UserRegDatas { get; set; }

    }
}