using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebService.Models;

namespace WebService
{
    public class QueryHelper
    {
        public SOA4Entities db = new SOA4Entities();

        public bool CheckFilledIn(Customer c)
        {
            bool cb = false;

            if (c.custId != 0 || c.firstName != null || c.lastName != null || c.phoneNumber != null)
            {
                cb = true;
            }

            return cb;
        }

        public bool CheckFilledIn(Product p)
        {
            bool pb = false;

            if (p.prodId != 0 || p.inStock || p.price != 0 || p.prodName != null || p.prodWeight != 0)
            {
                pb = true;
            }

            return pb;
        }

        public bool CheckFilledIn(Order p)
        {
            bool pb = false;

            if (p.custId != 0 || p.orderDate.HasValue || p.orderId != 0 || p.poNumber != null)
            {
                pb = true;
            }

            return pb;
        }

        public bool CheckFilledIn(Cart p)
        {
            bool pb = false;

            if (p.orderId != 0 || p.prodId != 0 || p.quantity != null)
            {
                pb = true;
            }

            return pb;
        }

        public int CheckHowManyFilledIn(Everything e)
        {
            int count = 0;

            if (CheckFilledIn(e.Customer))
            {
                ++count;
            }
            if (CheckFilledIn(e.Product))
            {
                ++count;
            }
            if (CheckFilledIn(e.Order))
            {
                ++count;
            }
            if (CheckFilledIn(e.Cart))
            {
                ++count;
            }

            return count;
        }

        public IQueryable<Customer> SearchCustomer(Customer c)
        {
            IQueryable<Customer> q = db.Set<Customer>();

            if (c.custId != 0)
            {
                q = q.Where(x => x.custId == c.custId);
            }
            if(c.firstName != null)
            {
                q = q.Where(x => x.firstName == c.firstName);
            }
            if(c.lastName != null)
            {
                q = q.Where(x => x.lastName == c.lastName);
            }
            if(c.phoneNumber != null)
            {
                q = q.Where(x => x.phoneNumber == c.phoneNumber);
            }

            return q;
        }

        public IQueryable<Product> SearchProduct(Product p)
        {
            IQueryable<Product> q = db.Set<Product>();
            bool somethingSearched = false;

            if (p.prodId != 0)
            {
                somethingSearched = true;
                q = q.Where(x => x.prodId == p.prodId);
            }
            if (p.prodName != null)
            {
                somethingSearched = true;
                q = q.Where(x => x.prodName == p.prodName);
            }
            if (p.prodWeight != 0)
            {
                somethingSearched = true;
                q = q.Where(x => x.prodWeight == p.prodWeight);
            }
            if (p.price != 0)
            {
                somethingSearched = true;
                q = q.Where(x => x.price == p.price);
            }
            if(somethingSearched)
            {
                q = q.Where(x => x.inStock == p.inStock);
            }

            return q;
        }

        public IQueryable<Order> SearchOrder(Order p)
        {
            IQueryable<Order> q = db.Set<Order>();

            if (p.custId != 0)
            {
                q = q.Where(x => x.custId == p.custId);
            }
            if (p.orderDate.HasValue)
            {
                q = q.Where(x => x.orderDate == p.orderDate);
            }
            if (p.orderId != 0)
            {
                q = q.Where(x => x.orderId == p.orderId);
            }
            if (p.poNumber != null)
            {
                q = q.Where(x => x.poNumber == p.poNumber);
            }

            return q;
        }

        public IQueryable<Cart> SearchCart(Cart p)
        {
            IQueryable<Cart> q = db.Set<Cart>();

            if (p.orderId != 0)
            {
                q = q.Where(x => x.orderId == p.orderId);
            }
            if (p.prodId != 0)
            {
                q = q.Where(x => x.prodId == p.prodId);
            }
            if (p.quantity != null)
            {
                q = q.Where(x => x.quantity == p.quantity);
            }

            return q;
        }
    }
}