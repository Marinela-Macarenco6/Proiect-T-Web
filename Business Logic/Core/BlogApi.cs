using SkillSwaps.Domain.Comments;
using SkillSwaps.DbDataContext;  // adaugă acest using
using System;

namespace SkillSwaps.Core
{
    public class BlogApi
    {
        private readonly CommentsContext _dbContext;

        public BlogApi()
        {
            _dbContext = new CommentsContext();
        }

        public bool PostBlogCommentAction(CTable data)
        {
            if (string.IsNullOrWhiteSpace(data.Content) || string.IsNullOrWhiteSpace(data.UserName))
                return false;

            try
            {
                _dbContext.Comments.Add(data);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
