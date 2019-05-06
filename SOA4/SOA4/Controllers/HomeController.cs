using SOA4.MyWebService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SOA4.Models;
using System.Collections;

namespace SOA4.Controllers
{
    public class HomeController : Controller
    {
        private WebService w = new WebService();

        public ActionResult Index()
        {
            return View();
        }

        private Everything Blank()
        {
            return new Everything()
            {
                Customer = new Customer(),
                Product = new Product(),
                Order = new Order(),
                Cart = new Cart()
            };
        }

        private void SetVB(String postMethod, String error = "")
        {
            ViewBag.PostMethod = postMethod;
            ViewBag.Error = error;
        }

        [HttpPost]
        public ActionResult Index(String btnSubmit)
        {
            if(btnSubmit == "Search")
            {
                SetVB("Search");
            }
            else if (btnSubmit == "Insert some Stuff")
            {
                SetVB("Insert");
            }
            else if (btnSubmit == "Update some Stuff")
            {
                SetVB("Update");
            }
            else if (btnSubmit == "Delete some Stuff")
            {
                SetVB("Delete");
            }
            else
            {
                return Redirect("http://google.ca");
            }

            return View("~/Views/Home/Page2.cshtml", Blank());
        }

        public ActionResult Search(Everything e)
        {
            ActionResult ret = null;
            int everything = w.CheckEverythingFilledIn(e);

            bool order = w.CheckOrderFilledIn(e.Order);
            bool product = w.CheckProductFilledIn(e.Product);
            bool customer = w.CheckCustomerFilledIn(e.Customer);
            bool cart = w.CheckCartFilledIn(e.Cart);

            if(everything != 1)
            {
                SetVB("Not Needed", "Only one item can be selected at a time");
                ret = View("~/Views/Home/Index.cshtml", Blank());
            }

            if (customer)
            {
                //Can't use List for some reason
                Customer[] list = w.SearchCustomer(e.Customer);

                ret = View("~/Views/Customer/List.cshtml");
            }
            else if (product)
            {
                //Can't use List for some reason
                Product[] list = w.SearchProduct(e.Product);

                ret = View("~/Views/Product/List.cshtml");
            }
            else if (order)
            {
                //Can't use List for some reason
                Order[] list = w.SearchOrder(e.Order);

                ret = View("~/Views/Order/List.cshtml");
            }
            else if (cart)
            {
                //Can't use List for some reason
                Cart[] list = w.SearchCart(e.Cart);

                ret = View("~/Views/Cart/List.cshtml");
            }

            return ret;
        }

        public ActionResult Insert(Everything e)
        {
            int everything = w.CheckEverythingFilledIn(e);
            bool custFilledIn = w.CheckCustomerFilledIn(e.Customer);
            bool prodFilledIn = w.CheckProductFilledIn(e.Product);

            if(custFilledIn && prodFilledIn)
            {
                SetVB("Not Needed", "Product and Customer cannot be added at the same time");
                return View("Index");
            }

            if (custFilledIn)
            {
                w.AddCustomer(e.Customer);
            }

            if(prodFilledIn)
            {
                w.AddProduct(e.Product);
            }

            if(w.CheckOrderFilledIn(e.Order))
            {
                w.AddOrder(e.Order);
            }

            if(w.CheckCartFilledIn(e.Cart))
            {
                w.AddCart(e.Cart);
            }

            SetVB("Not Needed", "Insert(s) successful");
            return View("Index");
        }
    }
}