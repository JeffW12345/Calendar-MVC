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
            new BookingTerm() { BookedDay = new DateTime(DateTime.Now.Year, 9, 28), BookedInfo = "Winter, winter, winter..." },
            new BookingTerm() { BookedDay = new DateTime(2020, 10, 28), BookedInfo = "Wrong year test 1" },
            new BookingTerm() { BookedDay = new DateTime(2024, 9, 29), BookedInfo = "Wrong year test 2" },
            // new BookingTerm() { BookedDay = new DateTime(DateTime.Now.Year, 5, 16), BookedInfo = "Test - Sunday 16 May" }
        };

        // GET: BookingTerms
        public ActionResult Index()
        {
            // To remove any unwanted entries relating to previously used test objects. 
            DeleteRecords();
            AddRecords();
            return View(db.BookingTerm.ToList());
        }

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
