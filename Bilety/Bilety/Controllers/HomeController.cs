using Microsoft.AspNet.Identity;
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
            using (var ctx3 = new BiletyEntities())
            {
                var transakcja = ctx3.PokazOstatnie().ToList();
                ViewBag.Transakcje = transakcja;
            }


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

        public ActionResult Tickets(int id)
        {
            ViewBag.Message = "Kup bilet na mecz Świtu!";

            ViewBag.Title = "Kup bilet!";

            using (var ctx = new BiletyEntities())
            {
                var cena = ctx.PokazCeny(id).ToList();
                ViewBag.Cena = cena;

                var przeciwnik = ctx.WyswietlPrzeciwnika(id).ToList();
                ViewBag.Przeciwnik = przeciwnik[0];
            }

            return View();
        }

        public ActionResult Events()
        {
            ViewBag.Message = "Kup bilet na mecz Świtu!";
            ViewBag.Title = "Kup bilet!";
            using (var ctx1 = new BiletyEntities())
            {
                var przeciwnicy = ctx1.WyswietlWydarzenia().ToList();
                ViewBag.przec = przeciwnicy;


            }
                return View();
        }

        public ActionResult Success(int id)
            {

            using (var ctx2 = new BiletyEntities())
            {
                var userID = User.Identity.GetUserId();
                ctx2.Transakcja(userID.ToString(), id);
                ctx2.OdejmijMiejsce(id);



            }



                return View();

            }

    }
}