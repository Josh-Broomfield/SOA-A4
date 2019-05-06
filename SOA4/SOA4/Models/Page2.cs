using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SOA4.MyWebService;

namespace SOA4.Models
{
    public class Page2
    {
        public Customer cust { get; set; }
        public Product p { get; set; }
        public Order o { get; set; }
        public Cart cart { get; set; }
    }
}