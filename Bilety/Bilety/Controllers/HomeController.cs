using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bilety.Controllers
{
    public class HomeController : Controller
    {
        private BiletyEntities databaseManager = new BiletyEntities();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Skontaktuj się z nami!";

            return View();
        }

        public ActionResult Tickets()
        {
            ViewBag.Message = "Kup bilet na mecz Świtu!";

            ViewBag.Title = "Kup bilet!";

            using (var ctx = new BiletyEntities())
            {
                var cena = ctx.PokazCeny().ToList();
                ViewBag.Cena0 = cena[0];
                ViewBag.Cena1 = cena[1];
                ViewBag.Cena2 = cena[2];
                ViewBag.Cena3 = cena[3];
                ViewBag.Cena4 = cena[4];
                ViewBag.Cena5 = cena[5];

                int idwyd = 0;
                var przeciwnik = ctx.WyswietlPrzeciwnika(idwyd);
                ViewBag.Przeciwnik = przeciwnik;



            }





            return View();
        }
    }
}