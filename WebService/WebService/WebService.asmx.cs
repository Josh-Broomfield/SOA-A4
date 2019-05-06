using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using WebService.Models;

namespace WebService
{
    /// <summary>
    /// Summary description for WebService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WebService : System.Web.Services.WebService
    {
        private Database db = new Database();
        private QueryHelper qh = new QueryHelper();

        [WebMethod]
        [System.Xml.Serialization.XmlInclude(typeof(Customer))]
        public List<Customer> SearchCustomer(Customer c)
        {
            ArrayList list = new ArrayList();
            var q = qh.SearchCustomer(c);

            foreach (Customer cu in q)
            {
                list.Add(cu);
            }

            return q.ToList();
        }

        [WebMethod]
        public List<Product> SearchProduct(Product p)
        {
            return qh.SearchProduct(p).ToList();
        }

        [WebMethod]
        public List<Order> SearchOrder(Order o)
        {
            return qh.SearchOrder(o).ToList();
        }

        [WebMethod]
        public List<Cart> SearchCart(Cart c)
        {
            return qh.SearchCart(c).ToList();
        }

        [WebMethod]
        public int CheckEverythingFilledIn(Everything e)
        {
            return qh.CheckHowManyFilledIn(e);
        }

        [WebMethod]
        public bool CheckCustomerFilledIn(Customer e)
        {
            return qh.CheckFilledIn(e);
        }

        [WebMethod]
        public bool CheckProductFilledIn(Product e)
        {
            return qh.CheckFilledIn(e);
        }

        [WebMethod]
        public bool CheckOrderFilledIn(Order e)
        {
            return qh.CheckFilledIn(e);
        }

        [WebMethod]
        public bool CheckCartFilledIn(Cart e)
        {
            return qh.CheckFilledIn(e);
        }

        [WebMethod]
        public String AddCustomer(Customer x)
        {
            db.Insert(x);
            
            return "Hello World";
        }

        [WebMethod]
        public String UpdateCustomer(Customer x)
        {
            db.Update(x);

            return "Hello World";
        }

        [WebMethod]
        public String DeleteCustomer(Customer x)
        {
            db.Delete(x);

            return "Hello World";
        }

        [WebMethod]
        public String AddProduct(Product x)
        {
            db.Insert(x);

            return "Hello World";
        }

        [WebMethod]
        public String UpdateProduct(Product x)
        {
            db.Update(x);

            return "Hello World";
        }

        [WebMethod]
        public String DeleteProduct(Product x)
        {
            db.Delete(x);

            return "Hello World";
        }

        [WebMethod]
        public String AddOrder(Order x)
        {
            db.Insert(x);

            return "Hello World";
        }

        [WebMethod]
        public String UpdateOrder(Order x)
        {
            db.Update(x);

            return "Hello World";
        }

        [WebMethod]
        public String DeleteOrder(Order x)
        {
            db.Delete(x);

            return "Hello World";
        }

        [WebMethod]
        public String AddCart(Cart x)
        {
            db.Insert(x);

            return "Hello World";
        }

        [WebMethod]
        public String UpdateCart(Cart x)
        {
            db.Update(x);

            return "Hello World";
        }

        [WebMethod]
        public String DeleteCart(Cart x)
        {
            db.Delete(x);

            return "Hello World";
        }
    }
}
