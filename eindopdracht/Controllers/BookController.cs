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
    public class BookController : Controller
    {
        private DatabaseConnection db = new DatabaseConnection();

        //
        // GET: /Book/
        [Authorize]
        public ActionResult Index()
        {
            return View(db.Entries.ToList());
        }

        //
        // GET: /Book/Details/5
        public ActionResult Details(int id)
        {
            Entry entry = db.Entries.Find(id);
            if (entry == null)
            {
                return HttpNotFound();
            }
            return View(entry);
        }

        //
        // GET: /Book/Create
        
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Book/Create

        [HttpPost]
        public ActionResult Create(BookViewModel bvm)
        {
            if (ModelState.IsValid)
            {

                Entry entry = new Entry();
                Contact c = new Contact();
                entry.Id = bvm.EntryID;
                entry.Room = bvm.room;
                entry.StartDate = bvm.StartDate;
                entry.EndDate = bvm.EndDate;
                entry.AmountOfPeople = bvm.AmountOfPeople;
                c.Adress = bvm.Adress;
                c.Email = bvm.Email;
                c.Id = bvm.ContactID;
                c.Town = bvm.Town;
                c.ZipCode = bvm.ZipCode;
                entry.Contact = c;

                db.Entries.Add(entry);
                db.Contacts.Add(c);
                db.SaveChanges();
                //TODO send email to adress.
                return RedirectToAction("Detail/" + entry.Id);
            }

            return View(bvm);
        }

        //
        // GET: /Book/Edit/5
        [Authorize]
        public ActionResult Edit(int id = 0)
        {
            Entry entry = db.Entries.Find(id);
            if (entry == null)
            {
                return HttpNotFound();
            }
            return View(entry);
        }

        //
        // POST: /Book/Edit/5

        [HttpPost, Authorize]
        public ActionResult Edit(Entry entry)
        {
            if (ModelState.IsValid)
            {
                db.Entry(entry).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(entry);
        }

        //
        // GET: /Book/Delete/5
        [Authorize]
        public ActionResult Delete(int id = 0)
        {
            Entry entry = db.Entries.Find(id);
            if (entry == null)
            {
                return HttpNotFound();
            }
            return View(entry);
        }

        //
        // POST: /Book/Delete/5

        [HttpPost, ActionName("Delete"),Authorize]
        public ActionResult DeleteConfirmed(int id)
        {
            Entry entry = db.Entries.Find(id);
            db.Entries.Remove(entry);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        
        public ActionResult ContinueBook(int id)//add view
        {
            Entry entry = db.Entries.Find(id);
            return View(entry);
        }

        [HttpPost]
        public ActionResult ContinueBookConfirm(int id)
        {
            Entry entry = db.Entries.Find(id);
            
            string body = "";
            body += "Hello, \n\r";
            body += "Thanks for booking a hotelroom for " + entry.AmountOfPeople + " people\n\r";
            body += "Yours sincerely, /n/r The hotel personnel";
            MailHelper.SendMailMessage(entry.Contact.Email, "New booking", body);

            return RedirectToAction("Confirmed", id);
        }

        [ChildActionOnly]
        public ActionResult Confirmed(int id)//add view
        {

            return View();
        }

        public ActionResult CreatePerson(int bookid)
        {
            return RedirectToAction("Create", "Person", bookid);
        }

        public ActionResult EmailSend()
        {
            Entry entry = db.Entries.First();
            string body = "";
            body += "Hello, \n\r";
            body += "Thanks for booking a hotelroom for " + entry.AmountOfPeople + " people\n\r";
            body += "Yours sincerely, /n/r The hotel personnel";
            MailHelper.SendMailMessage(entry.Contact.Email, "New booking", body);
            return RedirectToAction("Index", "Home");
        }


        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}