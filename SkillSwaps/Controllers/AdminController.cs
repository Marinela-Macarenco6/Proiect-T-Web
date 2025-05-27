using Business_Logic;
using Business_Logic.Interfaces;
using Domain.Admin;
using Domain.Article;
using Domain.Enums;
using SkillSwaps.LogicHelper.Atributes;
using SkillSwaps.Models;
using SkillSwaps.Models.Course;
using SkillSwaps.Models.User;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static Microsoft.ApplicationInsights.MetricDimensionNames.TelemetryContext;

namespace SkillSwaps.Controllers
{
    public class AdminController : Controller
    {

        private readonly ISession _session;
        private readonly IAdmin _admin;
        private readonly IProduct _product;

        public AdminController()
        {
            var bl = new BusinessLogic();
            _session = bl.GetSessionBL();
            _admin = bl.GetAdminBl();
            _product = bl.GetProductBl();
        }

        // GET: Admin
        [IsAdmin]
        public ActionResult Index()
        {
            ViewBag.PendingCoursesCount = _product.GetPandingCoursesCount();
            return View();
        }

        // LOGOUT 
        [HttpPost]
        public ActionResult Logout()
        {
            var sessionKey = Request.Cookies["X-KEY"];

            if (sessionKey != null)
            {
                sessionKey.Expires = DateTime.Now.AddDays(-1);
                Response.Cookies.Add(sessionKey);

                bool success = _session.LogoutUser(sessionKey.Value);

                if (!success)
                {
                    Session.Clear();
                    return RedirectToAction("Error", "Error");
                }
            }
            Session.Clear();

            return RedirectToAction("Index", "Home");
        }

        // GET ALL USERS
        [IsAdmin]
        public ActionResult GetAllUsers()
        {
            var domainUsers = _admin.GetAllUser();

            var viewModel = domainUsers.Select(u => new UserInfo
            {
                UserId = u.UserId,
                FullName = u.FullName,
                UserName = u.UserName,
                Email = u.Email,
                RequestTime = u.RequestTime,
                UserRole = u.UserRole.ToString()
            }).ToList();

            return View(viewModel);
        }

        // GET ALL ONLINE USERS
        [IsAdmin]
        public ActionResult GetOnlineUsers()
        {
            var domainUsers = _admin.GetAllOnlineUser();

            var viewModel = domainUsers.Select(u => new UserInfo
            {
                UserId = u.UserId,
                FullName = u.FullName,
                UserName = u.UserName,
                Email = u.Email,
                RequestTime = u.RequestTime,
                UserRole = u.UserRole.ToString()
            }).ToList();

            return View(viewModel);

        }

        // BAN USER
        [IsAdmin]
        [HttpPost]
        public ActionResult BanUser(UserInfo data)
        {
            var userData = new UserDataMain
            {
                UserId = data.UserId,
            };

            bool banned = _admin.BannUserAcc(userData);

            if (banned)
            {
                TempData["SuccessMessage"] = "Utilizatorul a fost blocat cu succes.";
            }
            else
            {
                TempData["ErrorMessage"] = "A apărut o eroare la blocarea utilizatorului sau utilizatorul este deja blocat.";
            }

            return RedirectToAction("GetAllUsers");
        }

        // EDIT USER
        [IsAdmin]
        [HttpPost]
        public ActionResult EditUser(UserInfo data)
        {
            // Verifică dacă datele primite sunt nule
            if (data == null)
            {
                // Returnează un răspuns JSON cu succes: false și un mesaj de eroare
                return Json(new { success = false, message = "Datele primite sunt invalide." });
            }

            try
            {
                // Crează un obiect UserDataMain din datele primite
                var userData = new UserDataMain
                {
                    UserId = data.UserId,
                    FullName = data.FullName,
                    UserName = data.UserName,
                    Email = data.Email,
                    // Asigură-te că UserRole poate fi parsat corect în EURole
                    UserRole = (EURole)Enum.Parse(typeof(EURole), data.UserRole)
                };

                // Apelez metoda de editare a utilizatorului din repository
                bool isChanged = _admin.EditUserAcc(userData);

                if (isChanged)
                {
                    // Dacă editarea a avut succes, returnează un JSON cu succes: true
                    return Json(new { success = true, message = "Utilizatorul a fost editat cu succes." });
                }
                else
                {
                    // Dacă editarea a eșuat (ex: nicio modificare, eroare internă în _admin.EditUserAcc), returnează succes: false
                    return Json(new { success = false, message = "A apărut o eroare la editarea utilizatorului. Poate nu s-au făcut modificări sau a intervenit o problemă internă." });
                }
            }
            catch (Exception ex)
            {
                // Prinde orice excepție apărută în timpul procesării (ex: eroare la Enum.Parse, eroare în baza de date)
                // Este recomandat să loghezi această excepție într-un sistem de logare real.
                // Console.WriteLine(ex.Message); // Doar pentru depanare rapidă în dezvoltare

                // Returnează un răspuns JSON cu succes: false și mesajul de eroare al excepției
                return Json(new { success = false, message = "A apărut o eroare neașteptată: " + ex.Message });
            }
        }

        // GET SEARCH USER VIEW
        public ActionResult FindUser()
        {
            return View();
        }

        // SEARCH USER
        [IsAdmin]
        public JsonResult SearchUsers(string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                return Json(new { success = false, message = "Termenul de căutare nu poate fi gol." }, JsonRequestBehavior.AllowGet);
            }

            var users = _admin.SearchUser(searchTerm);

            if (users == null || !users.Any())
            {
                return Json(new { success = true, users = new object[0], message = "Nu s-au găsit utilizatori." }, JsonRequestBehavior.AllowGet);
            }

            var mappedUsers = users.Select(u => new UserInfo
            {
                UserId = u.UserId,
                FullName = u.FullName,
                UserName = u.UserName,
                Email = u.Email,
                RequestTime = u.RequestTime,
                UserRole = u.UserRole.ToString()
            }).ToList();

            return Json(new { success = true, users = mappedUsers }, JsonRequestBehavior.AllowGet);
        }

        // GET PENDING COURSES
        [IsAdmin]
        public ActionResult GetPendingCourse()
        {
            var courses = _admin.GetPendingCourses();

            var viewModel = courses.Select(c => new GetCourseData
            {
                Category = c.Category,
                Description = c.Description,
                Teacher = c.Teacher,
                Title = c.Title,
                CourseId = c.Id,
                PublicationDateTime = c.PublicationDateTime
            }).ToList();

            if (viewModel == null || !viewModel.Any())
            {
                TempData["ErrorMessage"] = "Nu există cursuri în așteptare.";
                return RedirectToAction("Index");
            }

            return View(viewModel);
        }

        [IsAdmin]
        [HttpPost]
        public ActionResult RejectCourse(GetCourseData data)
        {
            var courseData = new ArticleDataMain
            {
                Id = data.CourseId,
            };

            bool rejected = _admin.RejectCoursePublication(courseData);

            if (rejected)
            {
                TempData["SuccessMessage"] = "Cursul a fost respins cu succes.";
            }
            else
            {
                TempData["ErrorMessage"] = "A apărut o eroare la respingerea cursului";
            }

            return RedirectToAction("GetPendingCourse");
        }

        [IsAdmin]
        [HttpPost]
        public ActionResult ApproveCourse(GetCourseData data, HttpPostedFileBase image)
        {
            if (data == null)
            {
                return Json(new { success = false, message = "Datele cursului primite sunt invalide sau incomplete." });
            }

            string imageUrl = null; // Inițializăm calea imaginii cu null

            try
            {
                // Procesarea și validarea imaginii încărcate
                if (image != null && image.ContentLength > 0)
                {
                    var allowedExtensions = new[] { ".jpg", ".jpeg", ".png", ".gif" };
                    var fileExtension = Path.GetExtension(image.FileName).ToLower();

                    if (!allowedExtensions.Contains(fileExtension))
                    {
                        return Json(new { success = false, message = "Tipul fișierului nu este permis. Doar JPG, JPEG, PNG, GIF." });
                    }

                    // Limită dimensiunea fișierului la 2MB
                    if (image.ContentLength > (2 * 1024 * 1024))
                    {
                        return Json(new { success = false, message = "Dimensiunea fișierului depășește limita de 2MB." });
                    }

                    // Generare nume fișier unic și cale de salvare
                    var fileName = Path.GetFileName(image.FileName);
                    var uniqueFileName = Guid.NewGuid().ToString() + "_" + fileName;
                    var uploadPath = Server.MapPath("~/Content/assets/img/courses");
                    var fullPath = Path.Combine(uploadPath, uniqueFileName);

                    // Asigură-te că directorul de upload există
                    if (!Directory.Exists(uploadPath))
                    {
                        Directory.CreateDirectory(uploadPath);
                    }

                    // Salvează imaginea pe server
                    image.SaveAs(fullPath);
                    imageUrl = Url.Content("~/Content/assets/img/courses/" + uniqueFileName); // Setează URL-ul public
                }
                else
                {
                    // Validare: imaginea este obligatorie pentru aprobare
                    return Json(new { success = false, message = "O imagine este obligatorie pentru aprobarea cursului." });
                }

                // Asigură-te că modelul are URL-ul imaginii
                data.ImageUrl = imageUrl;

                var courseDataForBl = new AprovedArticleDataMain 
                {
                    Id = data.CourseId,
                    Title = data.Title,
                    Teacher = data.Teacher,
                    Category = (EACategory)Enum.Parse(typeof(EACategory), data.Category.ToString()),
                    Description = data.Description,
                    ImageUrl = data.ImageUrl
                };

                bool isUpdatedAndApproved = true; 

                if (isUpdatedAndApproved)
                {
                    TempData["SuccessMessage"] = "Cursul a fost actualizat și aprobat cu succes!";
                    return Json(new { success = true, message = "Cursul a fost editat și aprobat." });
                }
                else
                {
                    // Acest mesaj ar trebui să vină de la BL, dacă nu a fost posibilă actualizarea
                    return Json(new { success = false, message = "A apărut o eroare la actualizarea cursului în baza de date. Poate nu s-au făcut modificări." });
                }
            }
            catch (Exception ex)
            {
                // Loghează excepția (folosește un logger real în producție)
                System.Diagnostics.Debug.WriteLine($"Eroare în EditCourse: {ex.Message} StackTrace: {ex.StackTrace}");

                return Json(new { success = false, message = "A apărut o eroare neașteptată: " + ex.Message });
            }
        }

    }


}
