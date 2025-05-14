using System;
using System.Web.Mvc;
using SkillSwaps.Domain.Comments;
using SkillSwaps.DbDataContext;

namespace SkillSwaps.Controllers
{
    public class CommentsController : Controller
    {
        private readonly CommentsContext _context;

        public CommentsController()
        {
            _context = new CommentsContext();
        }

        [HttpPost]
        public ActionResult PostComment(string userName, string content)
        {
            if (string.IsNullOrWhiteSpace(userName) || string.IsNullOrWhiteSpace(content))
            {
                return RedirectToAction("Ev10", "Blog");
            }

            var comment = new CTable
            {
                UserName = userName,
                Content = content,
                PostedAt = DateTime.Now
            };

            _context.Comments.Add(comment);
            _context.SaveChanges();

            return RedirectToAction("Ev10", "Blog");
        }
    }
}