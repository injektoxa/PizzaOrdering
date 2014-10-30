using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pizza.Presentation.Models;

namespace Pizza.Test
{
    [TestClass]
    public class CartTest
    {
        [TestMethod]
        public void TestGuidSelect()
        {
            var list = new List<Guid>();
            Guid g1 = Guid.NewGuid();
            Guid g2 = Guid.NewGuid();
            Guid g3 = Guid.NewGuid();

            list.AddRange(new[] { g1, g1, g2, g2, g2, g3, g3, g3, g3 });


            var megaQuery = (from item in list
                            group item by item
                                into groups
                                let count = groups.Count()
                                select new { ProductId = groups.Key, Count = count })
                                .ToList();

            foreach (var q in megaQuery)
            {
               if(q.ProductId == g1)
               {
                   Assert.AreEqual(g1, q.ProductId);
                   Assert.AreEqual(2, q.Count);
                   continue;
               }
               if (q.ProductId == g2)
               {
                   Assert.AreEqual(g2, q.ProductId);
                   Assert.AreEqual(3, q.Count);
                   continue;
               }
               if (q.ProductId == g3)
               {
                   Assert.AreEqual(g3, q.ProductId);
                   Assert.AreEqual(4, q.Count);
                   continue;
               }

            }
        }
    }
}
