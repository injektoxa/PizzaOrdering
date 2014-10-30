using Pizza.Model;
using Pizza.Model.Interfaces;

namespace Pizza.DataAccess
{
    /// <summary>
    /// This class fills database primary test information 
    /// </summary>
    internal class SqlRepositoryTestLoader
    {
        public static void Load()
        {
            AppManager.CreateContext();

            IRepository<Category> repo = new SqlRepository<Category>(AppManager.Context);

            var drinks = new Category
                             {
                                 Name = "Drinks",
                                 Description = "This category includes drinks"
                             };
            repo.Add(drinks);

            var pizza = new Category
                            {
                                Name = "Pizzas",
                                Description = "This category includes pizzas"
                            };
            repo.Add(pizza);

            var salad = new Category
                            {
                                Name = "Salads",
                                Description = "This category include salads"
                            };
            repo.Add(salad);

            var deserts = new Category
                              {
                                  Name = "Deserts",
                                  Description = "Sweetest",
                              };
            repo.Add(deserts);

            repo.SaveAll();

            IRepository<Product> product = new SqlRepository<Product>(AppManager.Context);

            //salads
            var simplepizza = new Product
                                  {
                                      Category = pizza,
                                      Name = "Brick oven pizza",
                                      Price = 10,
                                      Description = "A wood fired brick oven gives a special flavor" +
                                                    "to pizza. Brick ovens are for baking Neapolitan style pizzas." +
                                                    "Brick oven pizzas are only about ten inches in diameter, thin and" +
                                                    "light on toppings since they are meant to bake in just a minute or two."
                                  };
            product.Add(simplepizza);

            var pan = new Product
                          {
                              Category = pizza,
                              Name = "Pan",
                              Price = 23.3,
                              Description = "Our thinnest, lightest, crispiest pizza base" +
                                            "with recipes from the heart of Italy. Oh, and the perfect size" +
                                            "to enjoy all to yourself!"
                          };
            product.Add(pan);

            var theItalian = new Product
                                 {
                                     Category = pizza,
                                     Name = "The Italian",
                                     Price = 15.86,
                                     Description = "Our traditional style base is hand-stretched to" +
                                                   "order to create the perfect thickness."
                                 };
            product.Add(theItalian);

            var cheesyBites = new Product
                                  {
                                      Category = pizza,
                                      Name = "Cheesy Bites",
                                      Price = 16,
                                      Description = "A ring of 28 individual dough bites bursting with cheese," +
                                                    "topped with herbs. Perfect for dipping!. Large only. "
                                  };
            product.Add(cheesyBites);

            var stuffedCrust = new Product
                                   {
                                       Category = pizza,
                                       Name = "Stuffed Crust",
                                       Price = 18.54,
                                       Description = "A ring of soft melted cheese baked into the crust."
                                   };

            product.Add(stuffedCrust);

            var tropicale = new Product
                                {
                                    Category = pizza,
                                    Name = "Tropicale",
                                    Price = 12,
                                    Description = "A simple Margherita base, topped with a combination" +
                                                  "of sliced and cherry tomatoes. Finished straight from the oven with" +
                                                  "rocket and a pesto drizzle."
                                };
            product.Add(tropicale);

            //drinks
            var cocacola = new Product
                               {
                                   Category = drinks,
                                   Name = "Coca-Cola",
                                   Description = "Contains caramel coloring and caffeine.",
                                   Price = 2
                               };
            product.Add(cocacola);

            var sprite = new Product
                             {
                                 Category = drinks,
                                 Name = "Sprite",
                                 Description = "Sprite is a transparent, lemon-lime flavored, caffeine"+
                                 " free soft drink, produced by the Coca-Cola Compan",
                                 Price = 23
                             };
            product.Add(sprite);

            //salads
            var cezar = new Product
                            {
                                Category = salad,
                                Name = "Cezar",
                                Price = 10,
                                Description = "Cucumber and carrot sticks"
                            };
            product.Add(cezar);

            var thought = new Product
                              {
                                  Category = salad,
                                  Name = "Beetroot",
                                  Price = 12.00,
                                  Description = "beetroot and carrot in balsamic"
                              };
            product.Add(thought);

            var potatoes = new Product
                               {
                                   Category = salad,
                                   Name = "Baby potatoes",
                                   Price = 14.3,
                                   Description = "Baby potatoes with chives"
                               };
            product.Add(potatoes);


            var tomat = new Product
            {
                Category = salad,
                Name = "Caprese",
                Price = 12.34,
                Description = "Red ripe tomatoes with fresh mozzarella cheese and croutons served on a bed of lettuce"
            };
            product.Add(tomat);

            var antipasto = new Product
            {
                Category = salad,
                Name = "Antipasto",
                Price = 14.64,
                Description = "Imported ham, genoa salami, blend of cheeses, tomatoes, cucumbers," +
                               "red onions, black & green olives, green peppers served on a crisp bed of mixed lettuce"
            };
            product.Add(antipasto);

            var house = new Product
            {
                Category = salad,
                Name = "House",
                Price = 19.64,
                Description = "Generouse portions of mixed lettuce tomatoes, cucumbers, red onions, black & green olives, carrots & green peppers"
            };
            product.Add(house);


            var caesar = new Product
            {
                Category = salad,
                Name = "Caesar",
                Price = 10.63,
                Description = "Crisp romaine lettuce, croutons, bacon bits and parmesan cheese, tossed in our special caesar dressing"
            };
            product.Add(caesar);

            var chickenCaesar = new Product
            {
                Category = salad,
                Name = "Chicken Caesar",
                Price = 13.00,
                Description = "Cutlet of chicken breast, crisp romaine lettuce, croutons & parmesan ceese"
            };
            product.Add(chickenCaesar);


            //deserts
            var cookie = new Product
                             {
                                 Category = deserts,
                                 Name = "Hot Cookie Dough Dessert",
                                 Price = 24.32,
                                 Description = "This hot and chewy dish combines chocolate chip cookie dough," +
                                               " topped with a large dollop of ice cream and drizzled with chocolate sauce."
                             };
            product.Add(cookie);

            product.SaveAll();

            IRepository<User> users = new SqlRepository<User>(AppManager.Context);

            var user1 = new User
                            {
                                FirstName = "Alexander",
                                LastName = "Kovpenko",
                                Address = new Address {Building = "11", Flat = "50", Street = "Kosmicheskaya"},
                                Email = "injektox@mail.ru",
                                Phone = "wesfe32d"
                            };
            users.Add(user1);

            var user2 = new User
                            {
                                FirstName = "Andrey",
                                LastName = "Nikolaenko",
                                Address = new Address {Building = "21a", Flat = "123", Street = "Gagarina"},
                                Email = "develop@mail.ru",
                                Phone = "sfdfpkl3"
                            };
            users.Add(user2);

            users.SaveAll();
        }
    }
}