using SkillSwaps.Domain.Comments;
using System.Web.Mvc;
using Business_Logic.Interfaces;
using Business_Logic;

namespace SkillSwaps.Controllers
{
    public class BlogController : Controller
    {
        private readonly IBlog _blog;

        public BlogController()
        {
            var bl = new BusinessLogic();
            _blog = bl.GetBlogBl();
        }
        public ActionResult Index()
        {
            return View();
        }

        // GET: Blog
        public ActionResult EvNotabil1() => View();
        public ActionResult EvNotabil2() => View();
        public ActionResult EvNotabil3() => View();
        public ActionResult EvNotabil4() => View();

        public ActionResult Ev1() => View();
        public ActionResult Ev2() => View();
        public ActionResult Ev3() => View();
        public ActionResult Ev4() => View();
        public ActionResult Ev5() => View();
        public ActionResult Ev6() => View();
        public ActionResult Ev7() => View();
        public ActionResult Ev8() => View();
        public ActionResult Ev9() => View();
        public ActionResult Ev10() => View();
        public ActionResult Ev11() => View();
        public ActionResult Ev12() => View();
        public ActionResult Ev13() => View();
        public ActionResult Ev14() => View();
        public ActionResult Ev15() => View();
        public ActionResult Evpag2() => View();
        public ActionResult Evpag3() => View();


        [HttpPost]
        public ActionResult PostBlogComment(CTable comment)
        {
            bool result = _blog.SaveComment(comment);

            if (result)
                return Json(new { success = true, message = "Comentariu postat cu succes!" });
            else
                return new HttpStatusCodeResult(400, "Eroare la postarea comentariului.");
        }
    }
}
