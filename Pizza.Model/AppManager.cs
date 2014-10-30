using System.Data.Entity;

namespace Pizza.Model
{
    /// <summary>
    /// Creates and works with PizzaContext
    /// </summary>
    public class AppManager
    {
        public static DbContext Context { set; get; }

        public static void CreateContext()
        {
            Context = new PizzaContext();
        }

        public static void CloseContext()
        {
            Context.Dispose();
        }
    }
}