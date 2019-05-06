using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebService.Models;

namespace WebService
{
    public class Database
    {
        public SOA4Entities db = new SOA4Entities();

        public void Insert(Customer c)
        {
            db.Customers.Add(c);
            db.SaveChanges();
        }

        public void Update(Customer c)
        {
            db.Customers.Attach(c);
            db.Entry(c).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void Delete(Customer c)
        {
            db.Customers.Attach(c);
            db.Customers.Remove(c);
            db.SaveChanges();
        }

        public void Insert(Product p)
        {
            db.Products.Add(p);
            db.SaveChanges();
        }

        public void Update(Product p)
        {
            db.Products.Attach(p);
            db.Entry(p).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void Delete(Product p)
        {
            db.Products.Attach(p);
            db.Products.Remove(p);
            db.SaveChanges();
        }

        public void Insert(Order o)
        {
            db.Orders.Add(o);
            db.SaveChanges();
        }

        public void Update(Order o)
        {
            db.Orders.Attach(o);
            db.Entry(o).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void Delete(Order o)
        {
            db.Orders.Attach(o);
            db.Orders.Remove(o);
            db.SaveChanges();
        }

        public void Insert(Cart c)
        {
            db.Carts.Add(c);
            db.SaveChanges();
        }

        public void Update(Cart c)
        {
            db.Carts.Attach(c);
            db.Entry(c).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void Delete(Cart c)
        {
            db.Carts.Attach(c);
            db.Carts.Remove(c);
            db.SaveChanges();
        }
    }
}