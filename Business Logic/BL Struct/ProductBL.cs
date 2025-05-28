using Domain.Article;
using Business_Logic.Core;
using Business_Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic.BL_Struct
{
    public class ProductBL : CourseApi, IProduct
    {
        public bool AddCourse(ArticleDataMain courseData)
        {
            return AddCourseAction(courseData);
        }

        public int GetPandingCoursesCount()
        {
            return GetPandingCoursescountAction();
        }
    }
}
