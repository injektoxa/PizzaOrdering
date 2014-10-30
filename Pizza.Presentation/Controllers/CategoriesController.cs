using System.Linq;
using System.Web.Mvc;
using Pizza.DataAccess;
using Pizza.Model;
using Pizza.Model.Interfaces;

namespace Pizza.Presentation.Controllers
{
    public class CategoriesController : Controller
    {
        public ActionResult Index()
        {
            IRepository<Category> repo = new SqlRepository<Category>(AppManager.Context);
            return View(repo.FindAll().OrderBy(c => c.Name));
        }

        public ActionResult Show(string name)
        {
            IRepository<Category> repo = new SqlRepository<Category>(AppManager.Context);
            var selectedCategory = repo.FindOne(cat => cat.Name.ToLower() == name.ToLower());
           
            Session["idCategory"] = selectedCategory.Id;
           
            IRepository<Product> products = new SqlRepository<Product>(AppManager.Context);
            var productsInCategory = products.FindAll(p => p.Category == selectedCategory);

            return View(productsInCategory);
        }
    }
}