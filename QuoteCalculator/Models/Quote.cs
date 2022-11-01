using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Web;

namespace QuoteCalculator.Models
{
    public class Quote
    {
        public string AmountRequired { get; set; }
        public string Term { get; set; }
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DateOfBirth { get; set; }
        public string Mobile { get; set; }
        public string  Email { get; set; }
        public string QID { get; set; }
        public string Product { get; set; }
        public string Weekly { get; set; }
    }
    public class Quotelist
    {
        public string QL { get; set; }
    }
}