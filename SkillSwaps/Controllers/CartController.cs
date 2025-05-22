using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Newtonsoft.Json;
using SkillSwaps.Models.Courses;

namespace SkillSwaps.Controllers
{
    public class CartController : Controller
    {
        public ActionResult Index()
        {
            var sessionCart = Session["Cart"] as string;
            var cart = sessionCart != null
                ? JsonConvert.DeserializeObject<List<CartItem>>(sessionCart)
                : new List<CartItem>();

            return View(cart);
        }

        [HttpPost]
        public ActionResult AddToCart(int courseId, string courseName, decimal price)
        {
            var sessionCart = Session["Cart"] as string;
            var cart = sessionCart != null
                ? JsonConvert.DeserializeObject<List<CartItem>>(sessionCart)
                : new List<CartItem>();

            cart.Add(new CartItem
            {
                CourseId = courseId,
                CourseName = courseName,
                Price = price
            });

            Session["Cart"] = JsonConvert.SerializeObject(cart);

            return RedirectToAction("Index", "Cart");
        }

        [HttpPost]
        public ActionResult RemoveFromCart(int courseId)
        {
            var sessionCart = Session["Cart"] as string;
            if (sessionCart != null)
            {
                var cart = JsonConvert.DeserializeObject<List<CartItem>>(sessionCart);
                var itemToRemove = cart.FirstOrDefault(c => c.CourseId == courseId);
                if (itemToRemove != null)
                {
                    cart.Remove(itemToRemove);
                    Session["Cart"] = JsonConvert.SerializeObject(cart);
                }
            }

            return RedirectToAction("Index", "Cart");
        }

    }
}
