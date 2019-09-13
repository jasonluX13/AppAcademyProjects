using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CommunityShedMVC.Models
{
    public class Borrowed
    {
        public int Id { get; set; }
        public int ItemId { get; set; }
        public int BorrowerId { get; set; }
        public DateTimeOffset DateBorrowed { get; set;}
        public DateTimeOffset DateDue { get; set; }
        public DateTimeOffset? DateReturned { get; set; }
    }
}