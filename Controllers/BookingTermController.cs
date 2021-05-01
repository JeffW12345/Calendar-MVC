using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BookingCalendar.Models;

namespace BookingCalendar.Controllers
{
    public class BookingTermController : Controller
    {
        private BookingTermContext db = new BookingTermContext();

        public static List<BookingTerm> SampleBooking = new List<BookingTerm>()
        {
            new BookingTerm() { BookedDay = new DateTime(DateTime.Now.Year, 3, 30), BookedInfo = "Update clients SSL" },
            new BookingTerm() { BookedDay = new DateTime(DateTime.Now.Year, 4, 12), BookedInfo = "Go to holiday!" },
            new BookingTerm() { BookedDay = new DateTime(DateTime.Now.Year, 7, 20), BookedInfo = "Summer holidays!" },
            new BookingTerm() { BookedDay = new DateTime(DateTime.Now.Year, 9, 28), BookedInfo = "Winter, winter, winter..." }
        };

        // GET: BookingTerms
        public ActionResult Index()
        {
            db.BookingTerm.Add(new BookingTerm() { BookedDay = new DateTime(DateTime.Now.Year, 3, 28), BookedInfo = "For test purposes" });
            db.SaveChanges();
            return View(db.BookingTerm.ToList());
        }

        // GET: BookingTerms/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookingTerm bookingTerm = db.BookingTerm.Find(id);
            if (bookingTerm == null)
            {
                return HttpNotFound();
            }
            return View(bookingTerm);
        }

        // GET: BookingTerms/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BookingTerms/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BookingTermID,BookedDay,BookedInfo")] BookingTerm bookingTerm)
        {
            if (ModelState.IsValid)
            {
                db.BookingTerm.Add(bookingTerm);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bookingTerm);
        }

        // GET: BookingTerms/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookingTerm bookingTerm = db.BookingTerm.Find(id);
            if (bookingTerm == null)
            {
                return HttpNotFound();
            }
            return View(bookingTerm);
        }

        // POST: BookingTerms/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BookingTermID,BookedDay,BookedInfo")] BookingTerm bookingTerm)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bookingTerm).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bookingTerm);
        }

        // GET: BookingTerms/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookingTerm bookingTerm = db.BookingTerm.Find(id);
            if (bookingTerm == null)
            {
                return HttpNotFound();
            }
            return View(bookingTerm);
        }

        // POST: BookingTerms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BookingTerm bookingTerm = db.BookingTerm.Find(id);
            db.BookingTerm.Remove(bookingTerm);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
