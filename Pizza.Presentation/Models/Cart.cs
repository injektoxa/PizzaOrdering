using System;
using System.Collections.Generic;
using System.Web;
using Pizza.DataAccess;
using Pizza.Model;
using Pizza.Model.Interfaces;
using System.Linq;
namespace Pizza.Presentation.Models
{
    public class Cart
    {
        public List<Guid> ListProducts { get; set; }

        public Cart()
        {
            ListProducts = new List<Guid>();
        }

        public void AddProduct(Guid id)
        {
            if (HttpContext.Current.Session["ListProducts"] == null)
            {
                ListProducts.Add(id);
            }
            else
            {
                ListProducts = HttpContext.Current.Session["ListProducts"] as List<Guid>;
                if (ListProducts == null)
                {
                    return;
                }
                ListProducts.Add(id);
            }

            HttpContext.Current.Session["ListProducts"] = ListProducts;
        }

        public Dictionary<Product, int> GetProducts()
        {
            var result = new Dictionary<Product, int>();

            //nothing in here - return
            if (HttpContext.Current.Session["ListProducts"] == null)
            {
                return result;
            }
            var productsInSession = HttpContext.Current.Session["ListProducts"] as List<Guid>;
            if (productsInSession == null)
            {
                return result;
            }

            //select distinct products with count
            var distinctProductsAndCount = (from item in productsInSession
                             group item by item
                                 into groups
                                 let count = groups.Count()
                                 select new { ProductId = groups.Key, Count = count })
                                .ToList();

            //get repository
            IRepository<Product> repository = new SqlRepository<Product>(AppManager.Context);

            //each distinct product
            foreach (var item in distinctProductsAndCount)
            {
                //find product in repository

                var product = repository.FindOne(p => p.Id == item.ProductId);

                //add product and its count to the dictionary
                result.Add(product, item.Count);
            }
            return result;
        }

        public void Delete(Guid id)
        {
            var cart = HttpContext.Current.Session["ListProducts"] as List<Guid>;
            if (cart != null) cart.Remove(id);
        }
    }
}