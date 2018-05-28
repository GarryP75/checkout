namespace TestCheckout
{
    using Checkout;
    using Checkout.Models;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Collections.Generic;

    [TestClass]
    public class CheckoutTest
    {
        [TestMethod]
        public void TestBasketWithNoQualifyingDiscountProduct()
        {
            // arrange
            decimal expectedValue = 3.29M;

            var products = new List<Product>();
            products.Add(new Product { Id = 1, Sku = "A99", Description = "Apple", Price = 0.50M });
            products.Add(new Product { Id = 1, Sku = "C40", Description = "Coffee", Price = 1.80M });
            products.Add(new Product { Id = 1, Sku = "T23", Description = "Tissues", Price = 0.99M });

            var engine = new CheckoutEngine();

            // act
            var checkoutEngine = new CheckoutEngine();
            var result = checkoutEngine.CalculateBasket(products);

            // assert
            Assert.AreEqual(expectedValue, result);
        }

        [TestMethod]
        public void TestBasketWithOneQualifyingDiscountProduct()
        {
            // arrange
            decimal expectedValue = 4.09M;

            var products = new List<Product>();
            products.Add(new Product { Id = 1, Sku = "A99", Description = "Apple", Price = 0.50M });
            products.Add(new Product { Id = 1, Sku = "A99", Description = "Apple", Price = 0.50M });
            products.Add(new Product { Id = 1, Sku = "A99", Description = "Apple", Price = 0.50M });
            products.Add(new Product { Id = 1, Sku = "C40", Description = "Coffee", Price = 1.80M });
            products.Add(new Product { Id = 1, Sku = "T23", Description = "Tissues", Price = 0.99M });

            var engine = new CheckoutEngine();

            // act
            var checkoutEngine = new CheckoutEngine();
            var result = checkoutEngine.CalculateBasket(products);

            // assert
            Assert.AreEqual(expectedValue, result);
        }

        [TestMethod]
        public void TestBasketWithMultipleQualifyingDistcountProduct()
        {
            // arrange
            decimal expectedValue = 1.75M;

            var products = new List<Product>();
            products.Add(new Product { Id = 1, Sku = "A99", Description = "Apple", Price = 0.50M });
            products.Add(new Product { Id = 1, Sku = "A99", Description = "Apple", Price = 0.50M });
            products.Add(new Product { Id = 1, Sku = "A99", Description = "Apple", Price = 0.50M });
            products.Add(new Product { Id = 1, Sku = "B15", Description = "Biscuits", Price = 0.30M });
            products.Add(new Product { Id = 1, Sku = "B15", Description = "Biscuits", Price = 0.30M });

            var engine = new CheckoutEngine();

            // act
            var checkoutEngine = new CheckoutEngine();
            var result = checkoutEngine.CalculateBasket(products);

            // assert
            Assert.AreEqual(expectedValue, result);

        }
    }
}
