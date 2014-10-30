using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pizza.DataAccess;
using Pizza.Model;
using Pizza.Model.Interfaces;

namespace Pizza.Test
{
    /// <summary>
    /// Test for SqlRepository class
    /// </summary>
    [TestClass]
    public class SqlRepositoryTest
    {
        [ClassInitialize]
        public static void MyClassInitialize(TestContext testContext)
        {
            AppManager.CreateContext();
        }

        [ClassCleanup]
        public static void MyClassCleanup()
        {
            AppManager.CloseContext();
        }

        [TestMethod]
        public void AddTest()
        {
            //create new category
            var cat = new Category();
            Guid expId = cat.Id;
            IRepository<Category> repo = new SqlRepository<Category>(AppManager.Context);

            //add newly created category 
            repo.Add(cat);
            repo.SaveAll();

            Category savedCategory = repo.FindOne(c => c.Id == expId);
            Assert.IsNotNull(savedCategory);
            repo.Delete(cat);
            repo.SaveAll();
        }

        [TestMethod]
        public void DeleteTest()
        {
            //create new category
            var cat = new Category();
            Guid expId = cat.Id;
            IRepository<Category> repo = new SqlRepository<Category>(AppManager.Context);

            //add newly created category 
            repo.Add(cat);
            repo.SaveAll();

            Category savedCategory = repo.FindOne(c => c.Id == expId);
            Assert.IsNotNull(savedCategory);

            repo.Delete(cat);
            repo.SaveAll();
            Category delCategory = repo.FindOne(c => c.Id == expId);

            //verify it was deleted
            Assert.IsNull(delCategory);
        }

        [TestMethod]
        public void FindAllTest()
        {
            var u1 = new User
                         {
                             FirstName = "User",
                             LastName = "Test",
                             Email = "test@test.com",
                             Phone = "123456789"
                         };
            var u2 = new User
                             {
                                 FirstName = "User",
                                 LastName = "Test",
                                 Email = "test@test.com",
                                 Phone = "123456789"
                             };


            IRepository<User> repo = new SqlRepository<User>(AppManager.Context);

            repo.Add(u1);
            repo.Add(u2);

            repo.SaveAll();
            IQueryable<User> users = repo.FindAll(user => (user.Id == u1.Id || user.Id == u2.Id));
            Assert.AreEqual(users.Count(), 2);

            repo.Delete(u1);
            repo.Delete(u2);
            repo.SaveAll();

            users = repo.FindAll(user => (user.Id == u1.Id || user.Id == u2.Id));
            Assert.AreEqual(users.Count(), 0);
        }

        [TestMethod]
        public void FindOneTest()
        {
            //create new User
            var user = new User();
            IRepository<User> repo = new SqlRepository<User>(AppManager.Context);
            user.FirstName = "User";
            user.LastName = "Test";
            user.Email = "test@test.com";
            user.Phone = "123456789";


            //add and save curent user
            repo.Add(user);
            repo.SaveAll();

            //test
            User savedUser = repo.FindOne(c => c.FirstName == "User" && c.LastName == "Test");
            Assert.IsNotNull(savedUser);

            //delete from DB
            repo.Delete(savedUser);
            repo.SaveAll();
        }


        [TestMethod]
        public void SaveAllTest()
        {
            //create new Product
            var product = new Product();
            var expCat = new Category();

            product.Category = expCat;
            Guid expId = product.Id;
            IRepository<Product> repo = new SqlRepository<Product>(AppManager.Context);

            repo.Add(product);
            //save newly created product
            repo.SaveAll();

            Product savedproduct = repo.FindOne(c => c.Id == expId);


            Assert.IsNotNull(savedproduct);
            Assert.AreEqual(savedproduct.Category.Id, expCat.Id);

            //Delete this junk
            repo.Delete(savedproduct);
            repo.SaveAll();

            IRepository<Category> repoCategories = new SqlRepository<Category>(AppManager.Context);
            repoCategories.Delete(expCat);
            repoCategories.SaveAll();
        }
    }
}