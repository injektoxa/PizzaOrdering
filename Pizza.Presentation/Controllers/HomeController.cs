using System.Web.Mvc;
using Pizza.DataAccess;
using Pizza.Model;
using Pizza.Model.Interfaces;

namespace Pizza.Presentation.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRepository<Category> categories = new SqlRepository<Category>(AppManager.Context);

        public ActionResult Index()
        {
            ViewBag.Message = "Pizza ordering web site";
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Pizza()
        {
            Category category = GetCategoryByName("Pizzas");
            return RedirectToAction(FormatCategoryLink(category), "categories");
        }

        public ActionResult Drink()
        {
            Category category = GetCategoryByName("Drinks");
            return RedirectToAction(FormatCategoryLink(category), "categories");
        }

        public ActionResult Salad()
        {
            Category category = GetCategoryByName("Salads");
            return RedirectToAction(FormatCategoryLink(category), "categories");
        }

        public ActionResult Desert()
        {
            Category category = GetCategoryByName("Deserts");
            return RedirectToAction(FormatCategoryLink(category), "categories");
        }

        private string FormatCategoryLink(Category category)
        {
            return string.Format("Show?name={0}", category.Name);
        }

        private Category GetCategoryByName(string name)
        {
            return categories.FindOne(k => k.Name == name);
        }
    }
}