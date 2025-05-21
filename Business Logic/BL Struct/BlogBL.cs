using System;
using System.Collections.Generic;
using System.Linq;
using Business_Logic.Interfaces;
using Domain.Blog;

namespace Business_Logic.BL_Struct
{
    public class BlogBL : IBlogLogic
    {
        public List<EvenimentBlog> GetEvenimenteFiltrate(string searchQuery)
        {
            var evenimente = GetToateEvenimentele();

            if (!string.IsNullOrWhiteSpace(searchQuery))
            {
                var q = searchQuery.ToLower();
                evenimente = evenimente
                    .Where(e => e.Titlu.ToLower().Contains(q) || e.Descriere.ToLower().Contains(q))
                    .ToList();
            }

            return evenimente;
        }

        public List<EvenimentBlog> GetToateEvenimentele()
        {
            return new List<EvenimentBlog>
            {
                new EvenimentBlog {
                    Id = 1,
                    Titlu = "Hackathon pentru Începători în IT",
                    Descriere = "Eveniment intensiv de programare pentru începători.",
                    ImagineUrl = "~/Content/assets/img/blog/Hackathon-01-1.png",
                    Data = new DateTime(2025, 3, 15),
                    Categorie = "Domenii tehnice & IT"
                },
                new EvenimentBlog {
                    Id = 2,
                    Titlu = "Matematica Distractivă – Atelier pentru Elevi",
                    Descriere = "Sesiune interactivă de jocuri logice pentru copii.",
                    ImagineUrl = "~/Content/assets/img/blog/mathc.jpg",
                    Data = new DateTime(2025, 3, 22),
                    Categorie = "Științe exacte"
                },
                new EvenimentBlog {
                    Id = 3,
                    Titlu = "Turneu de Șah pentru Începători și Avansați",
                    Descriere = "Competiție de șah pentru toate nivelele.",
                    ImagineUrl = "~/Content/assets/img/blog/Concurs-sah.jpg",
                    Data = new DateTime(2025, 4, 5),
                    Categorie = "Cursuri Practice & Hobby-uri"
                },
                new EvenimentBlog {
                    Id = 4,
                    Titlu = "Curs de Design Grafic cu Adobe Illustrator",
                    Descriere = "Workshop de design pentru începători și avansați.",
                    ImagineUrl = "~/Content/assets/img/blog/design-grafic.jpg",
                    Data = new DateTime(2025, 4, 12),
                    Categorie = "Arte & Design"
                },
                new EvenimentBlog {
                    Id = 5,
                    Titlu = "Inteligența Artificială și Viitorul Locurilor de Muncă",
                    Descriere = "Seminar despre impactul AI asupra pieței muncii.",
                    ImagineUrl = "~/Content/assets/img/blog/inteligenta artificiala.jpg",
                    Data = new DateTime(2025, 4, 20),
                    Categorie = "Domenii tehnice & IT"
                },
                new EvenimentBlog {
                    Id = 6,
                    Titlu = "Programul Municipal de Dezvoltare Personală a Tinerilor",
                    Descriere = "Inițiativă educațională pentru tinerii din Chișinău, concentrată pe autocunoaștere și dezvoltare personală.",
                    ImagineUrl = "~/Content/assets/img/blog/tineri.jpg",
                    Data = new DateTime(2025, 3, 2),
                    Categorie = "Dezvoltare personală"
                },
                new EvenimentBlog {
                    Id = 7,
                    Titlu = "Săptămâna Psi 2025",
                    Descriere = "Eveniment anual dedicat promovării sănătății mentale și înțelegerii psihologiei.",
                    ImagineUrl = "~/Content/assets/img/blog/psih-foto.jpg",
                    Data = new DateTime(2025, 3, 1),
                    Categorie = "Dezvoltare personală"
                },
                new EvenimentBlog {
                    Id = 8,
                    Titlu = "Forumul de Nutriție și Dietetică",
                    Descriere = "Promovează stilul de viață sănătos și educația nutrițională echilibrată.",
                    ImagineUrl = "~/Content/assets/img/blog/nutritie.jpg",
                    Data = new DateTime(2025, 3, 15),
                    Categorie = "Cursuri Practice & Hobby-uri"
                },
                new EvenimentBlog {
                    Id = 9,
                    Titlu = "HR Academy: Training of HR Specialists",
                    Descriere = "Program intensiv pentru dezvoltarea competențelor în resurse umane.",
                    ImagineUrl = "~/Content/assets/img/blog/resurseumane.jpg",
                    Data = new DateTime(2025, 4, 12),
                    Categorie = "Business & Marketing"
                },
                new EvenimentBlog {
                    Id = 10,
                    Titlu = "Moldova Digital Summit 2025",
                    Descriere = "Summit ce conectează lideri din guvern, educație și industrie pentru digitalizare.",
                    ImagineUrl = "~/Content/assets/img/blog/digital.jpg",
                    Data = new DateTime(2025, 6, 5),
                    Categorie = "Domenii tehnice & IT"
                },
                new EvenimentBlog {
                    Id = 11,
                    Titlu = "Startup World Cup Moldova",
                    Descriere = "Competiție regională pentru startup-uri cu premiu de 1 milion $ și acces la investitori.",
                    ImagineUrl = "~/Content/assets/img/blog/Startup-World-Cup-Moldova-.jpg",
                    Data = new DateTime(2025, 8, 7),
                    Categorie = "Business & Marketing"
                },
                new EvenimentBlog {
                    Id = 12,
                    Titlu = "Startup Village",
                    Descriere = "Eveniment de 3 zile ce combină networking, afaceri și experiențe culturale.",
                    ImagineUrl = "~/Content/assets/img/blog/Startup-Village.jpg",
                    Data = new DateTime(2025, 9, 11),
                    Categorie = "Business & Marketing"
                },
                new EvenimentBlog {
                    Id = 13,
                    Titlu = "DeepTech Gigahack",
                    Descriere = "Cel mai mare hackathon din Moldova, cu 300 participanți în 57 de echipe.",
                    ImagineUrl = "~/Content/assets/img/blog/DeepTech-Gigahack.jpg",
                    Data = new DateTime(2025, 9, 27),
                    Categorie = "Domenii tehnice & IT"
                },
                new EvenimentBlog {
                    Id = 14,
                    Titlu = "Moldova DevCon 2025",
                    Descriere = "Cel mai mare eveniment regional pentru dezvoltatori IT, organizat de Fusion Works.",
                    ImagineUrl = "~/Content/assets/img/blog/Moldova-DevCon-2025.jpg",
                    Data = new DateTime(2025, 10, 10),
                    Categorie = "Domenii tehnice & IT"
                },
                new EvenimentBlog {
                    Id = 15,
                    Titlu = "Moldova Business Forum III 2025",
                    Descriere = "Cu Steve Wozniak ca invitat special. Focus pe inovație și leadership.",
                    ImagineUrl = "~/Content/assets/img/blog/Moldova-Business-Forum-III-2025.jpg",
                    Data = new DateTime(2025, 10, 18),
                    Categorie = "Business & Marketing"
                }

            };
        }
    }
}
