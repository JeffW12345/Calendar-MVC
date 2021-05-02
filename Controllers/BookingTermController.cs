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

        // These objects' data have already been added to the database.
        public static List<BookingTerm> SampleBooking = new List<BookingTerm>()
        {
            new BookingTerm() { BookedDay = new DateTime(DateTime.Now.Year, 3, 30), BookedInfo = "Update clients SSL" },
            new BookingTerm() { BookedDay = new DateTime(DateTime.Now.Year, 4, 12), BookedInfo = "Go to holiday!" },
            new BookingTerm() { BookedDay = new DateTime(DateTime.Now.Year, 7, 20), BookedInfo = "Summer holidays!" },
            new BookingTerm() { BookedDay = new DateTime(DateTime.Now.Year, 9, 28), BookedInfo = "Winter, winter, winter..." },
            new BookingTerm() { BookedDay = new DateTime(DateTime.Now.Year, 5, 16), BookedInfo = "Test - Sunday 16 May" }
        };

        // GET: BookingTerms
        public ActionResult Index()
        {
            return View(db.BookingTerm.ToList());
        }

        // Methods below are to facilitate adding and removing test cases. 
        public void AddRecords()
        {
            foreach(var record in SampleBooking)
            {
                db.BookingTerm.Add(record);
            }
            db.SaveChanges();
        }

        public void DeleteRecords()
        {
            foreach (var record in db.BookingTerm)
            {
                db.BookingTerm.Remove(record);

            }
            db.SaveChanges();
        }
    }
}
