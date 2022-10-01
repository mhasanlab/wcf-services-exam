using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using WcfService.Models;

namespace WcfService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class ServiceProduct : IServiceProduct
    {
        public bool Create(Product product)
        {
            using(AzDbContext db=new AzDbContext())
            {
                try
                {
                    Product pe = new Product();
                    pe.id = product.id;
                    pe.name = product.name;
                    pe.price = product.price;
                    pe.quantity = product.quantity;
                    db.Products.Add(pe);
                    db.SaveChanges();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }

        public bool Delete(Product product)
        {
            using (AzDbContext db = new AzDbContext())
            {
                try
                {
                    Product pr = db.Products.Single(p => p.id == product.id);
                    db.Products.Remove(pr);
                    db.SaveChanges();
                    return true;

                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        public bool Edit(Product product)
        {
            using(AzDbContext db=new AzDbContext())
            {
                try
                {
                    Product pr = db.Products.Single(p => p.id == product.id);
                    pr.name = product.name;
                    pr.price = product.price;
                    pr.quantity = product.quantity;
                    db.Products.Add(pr);
                    db.SaveChanges();
                    return true;

                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        public List<Product> FindAll()
        {
            using(AzDbContext db=new AzDbContext())
            {
                return db.Products.Select(p => new Product
                {
                    id=p.id,
                    name=p.name,
                    price=p.price,
                    quantity=p.quantity
                }).ToList();
            }
        }
    }
}
