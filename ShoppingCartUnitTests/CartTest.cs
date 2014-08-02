using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShoppingCart;

namespace ShoppingCartUnitTests
{
    [TestClass]
    public class CartTest
    {
        [TestMethod]
        public void TestDiscountPercentage()
        {
            Cart c = new Cart();
            Product p = new Product();
            Discount d = new Discount();
                        
            p.Price = 10;
            d.Amount = 50;
            d.Type = "percentage";            

            c.Add(p);
            c.ApplyDiscount(d);

            var total = c.ProcessCart();

            Assert.IsTrue(total == 15);

        }

        [TestMethod]
        public void TestDiscountFixed()
        {
            Cart c = new Cart();
            Product p = new Product();
            Discount d = new Discount();

            p.Price = 10;
            d.Amount = 5;
            d.Type = "fixed";

            c.Add(p);
            c.ApplyDiscount(d);

            var total = c.ProcessCart();

            Assert.IsTrue(total == 5);

        }
    }
}
