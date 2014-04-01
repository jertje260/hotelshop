using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using eindopdracht.Models;

namespace eindopdracht.Controllers
{
    public class SpecialPriceController : Controller
    {
        private DatabaseConnection db = new DatabaseConnection();


        [Authorize]
        public ActionResult Create(int id)
        {
            SpecialPriceViewModel sp = new SpecialPriceViewModel();
            sp.RoomId = id;
            return View(sp);
        }

        //
        // POST: /SpecialPrice/Create
        // TODO check waarom is de roomId 0? als dat het doet werkt dit
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SpecialPriceViewModel specialPriceModel)
        {
            if (ModelState.IsValid)
            {
                SpecialPrice sp = new SpecialPrice();
                sp.Id = specialPriceModel.Id;
                sp.Price = specialPriceModel.Price;
                sp.StartDate = specialPriceModel.StartDate;
                sp.EndDate = specialPriceModel.EndDate;
                db.Rooms.Find(specialPriceModel.RoomId).specialPrices.Add(sp);
                db.SaveChanges();
                return RedirectToAction("Detail/" + specialPriceModel.RoomId, "Room");
            }

            return View(specialPriceModel);
        }

        //
        // GET: /SpecialPrice/Edit/5
        [Authorize]
        public ActionResult Edit(int id = 0)
        {
            SpecialPrice specialprice = db.SpecialPrices.Find(id);
            if (specialprice == null)
            {
                return HttpNotFound();
            }
            return View(specialprice);
        }

        //
        // POST: /SpecialPrice/Edit/5
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(SpecialPrice specialprice)
        {
            if (ModelState.IsValid)
            {
                db.Entry(specialprice).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Details/" + specialprice.RoomId, "Room");
            }
            return View(specialprice);
        }

        //
        // GET: /SpecialPrice/Delete/5
        [Authorize]
        public ActionResult Delete(int id = 0)
        {
            SpecialPrice specialprice = db.SpecialPrices.Find(id);
            if (specialprice == null)
            {
                return HttpNotFound();
            }
            return View(specialprice);
        }

        //
        // POST: /SpecialPrice/Delete/5
        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SpecialPrice specialprice = db.SpecialPrices.Find(id);
            int roomid = specialprice.RoomId;
            db.SpecialPrices.Remove(specialprice);
            db.SaveChanges();
            return RedirectToAction("Details/" + roomid,"Room");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}