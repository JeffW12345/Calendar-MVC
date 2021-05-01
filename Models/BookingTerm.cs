using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace BookingCalendar.Models
{
    public class BookingTerm
    {
        public int BookingTermID { get; set; }
        public DateTime BookedDay { get; set; }
        public string BookedInfo { get; set; }
    }
    public class BookingTermContext : DbContext
    {
        public DbSet<BookingTerm> BookingTerm { get; set; }
    }
}