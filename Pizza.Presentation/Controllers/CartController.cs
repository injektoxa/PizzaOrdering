using System;
using System.Web.Mvc;
using Pizza.DataAccess;
using Pizza.Model;
using Pizza.Model.Interfaces;
using Pizza.Presentation.Models;

namespace Pizza.Presentation.Controllers
{
    public class CartController : Controller
    {
       private Cart cart = new Cart();
        public ActionResult Index()
        {        
             return View(cart.GetProducts());
        }

        public ActionResult Delete(Guid id)
        {
            cart.Delete(id);
            return RedirectToAction("Index");
        }
        
        public ActionResult Buy(Guid id)
        {
            var idCategory = (Guid)Session["idCategory"];
            IRepository<Category> repo = new SqlRepository<Category>(AppManager.Context);
            var cat = repo.FindOne(r => r.Id == idCategory);

            cart = new Cart();
            cart.AddProduct(id);
         
            return Redirect("/Categories/Show?name="+cat.Name);
        }
    }
}