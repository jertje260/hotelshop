using eindopdracht.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eindopdracht.Controllers
{
    public class RoomController : Controller
    {
        DatabaseConnection db = new DatabaseConnection();

        //
        // GET: /Room/
        [Authorize]
        public ActionResult Index()
        {
            
            var model = from r in db.Rooms
                        orderby r.AmountOfPeople ascending
                        select r;
            return View(model);
        }

        //
        // GET: /Room/Details/5
        [Authorize]
        public ActionResult Details(int id)
        {
            var r = db.Rooms.Find(id);
            var model = from s in db.SpecialPrices
                        where s.RoomId == id
                        select s;
            foreach (SpecialPrice a in model)
            {
                r.specialPrices.Add(a);
            }
            return View(r);
        }

        //
        // GET: /Room/Create
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }
        
        //
        // POST: /Room/Create
        [Authorize]
        [HttpPost]
        public ActionResult Create(Room r)
        {
            if (ModelState.IsValid && r.AmountOfPeople!=0)
            {  
                db.Rooms.Add(r);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.message = "A room can only have 2,3 or 5 people.";
            return View();
        }

        //
        // GET: /Room/Edit/5
        [Authorize]
        public ActionResult Edit(int id)
        {
            var room = db.Rooms.Single(r => r.Id == id);
            return View(room);
        }

        //
        // POST: /Room/Edit/5
        [Authorize]
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            var room = db.Rooms.Single(r => r.Id == id);
            if (TryUpdateModel(room))
            {
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(room);
        }

        //
        // GET: /Room/Delete/5
        [Authorize]
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Room/Delete/5
        [Authorize]
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        public ActionResult CreateSpecialPrice(int id)
        {
            return RedirectToAction("Create", "SpecialPrice", new { id });
        }



        protected override void Dispose(bool disposing)
        {
            if (db != null)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
