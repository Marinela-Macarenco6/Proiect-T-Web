using System.Collections.Generic;
using Domain.Blog;

namespace Business_Logic.Interfaces
{
    public interface IBlogLogic
    {
        List<EvenimentBlog> GetEvenimenteFiltrate(string searchQuery);
        List<EvenimentBlog> GetToateEvenimentele();
    }
}
