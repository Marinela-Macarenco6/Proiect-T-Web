using Business_Logic.DbDataContext;
using Domain.Article;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic.Core
{
    public class CourseApi
    {

        public List<ArticleDataMain> GetAllArticleForAction()
        {
            return new List<ArticleDataMain>();
        }

        internal bool AddCourseAction(ArticleDataMain courseData)
        {

            var newCourse = new ADBTable
            {
                Title = courseData.Title,
                Teacher = courseData.Teacher,
                Category = courseData.Category,
                Description = courseData.Description,
                ArticleImage = courseData.ArticleImage,
                PublicationDateTime = DateTime.UtcNow,
                EnrolledUsers = 0,
                ArticleId = 1,
            };
            
            using (var db = new ArticleContext())
            {
                db.Articles.Add(newCourse);
                db.SaveChanges();
            }

            return true;
        }


        // De implementat incremenraea nr de utilizatori a fiecarui curs pentru userii care se inscriu

    }
}
