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
                PublicationDateTime = DateTime.UtcNow,
                EnrolledUsers = 0,
            };
            
            using (var db = new ArticleContext())
            {
                db.Articles.Add(newCourse);
                db.SaveChanges();
            }

            return true;
        }

        public int GetPandingCoursescountAction()
        {
            using (var db = new ArticleContext())
            {
                return db.Articles.Count();
            }
        }


        // De implementat incremenraea nr de utilizatori a fiecarui curs pentru userii care se inscriu

    }
}
