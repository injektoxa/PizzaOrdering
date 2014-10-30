using System.Web.Mvc;
using Pizza.DataAccess;
using Pizza.Model;
using Pizza.Model.Interfaces;

namespace Pizza.Presentation.Controllers
{
    public class UserController : Controller
    {
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(User user)
        {
            if (ModelState.IsValid)
            {
                IRepository<User> users = new SqlRepository<User>(AppManager.Context);
                users.Add(user);
                users.SaveAll();

                return RedirectToAction("OrderConfirmed", "User");
            }
             return View();
        }

        public ActionResult OrderConfirmed()
        {
            return View();
        }
    }
}
