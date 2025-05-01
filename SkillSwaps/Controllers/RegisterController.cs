using Business_Logic;
using Business_Logic.BL_Struct;
using Business_Logic.Interfaces;
using Domain.User;
using System.Web.Mvc;

namespace SkillSwaps.Controllers
{
    public class RegisterController : Controller
    {
        private readonly IReg _reg;

        // Constructorul pentru injectarea dependenței
        public RegisterController()
        {
            _reg = new RegBL();  // Logica de business pentru înregistrare
        }

        // GET: Registration Page
        public ActionResult Index()
        {
            return View();
        }

        // POST: Register New User
        [HttpPost]
        public ActionResult Register(UserRegData data)
        {
            // Validare confirmare parolă pe server
            if (data.Password != data.ConfirmPassword)
            {
                ModelState.AddModelError("ConfirmPassword", "Parolele nu se potrivesc.");
            }

            if (ModelState.IsValid)
            {
                // Apelarea logicii de înregistrare (din RegBL)
                string sessionKey = _reg.UserRegLogic(data);

                if (!string.IsNullOrEmpty(sessionKey))
                {
                    // Dacă înregistrarea este cu succes, returnezi un mesaj de succes
                    TempData["Success"] = "Utilizatorul a fost înregistrat cu succes!";
                    return RedirectToAction("Index", "Home"); // După înregistrare, redirect la pagina de login
                }
                else
                {
                    ModelState.AddModelError("", "A apărut o eroare la înregistrare. Te rugăm să încerci din nou.");
                }
            }

            // Dacă modelul nu este valid, returnezi pagina cu mesaj de eroare
            return View("Index", data);
        }
    }
}
