using Domain.Article;
using Domain.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic.Interfaces
{
    public interface IProduct
    {
        List<ArticleDataMain> GetAllArticleFor();
    }
}
