using System;
using System.Collections.Generic;
using System.Linq;
using Business_Logic.Interfaces;
using Business_Logic.Core;
using SkillSwaps.Core;
using SkillSwaps.Domain.Comments;

namespace Business_Logic.BL_Struct
{
    public class BlogBL : IBlog
    {
        public bool SaveComment(CTable data)
        {
            return new BlogApi().PostBlogCommentAction(data);
        }
    }
}
