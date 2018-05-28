namespace TestCheckout
{
    using Checkout;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
    using System.Collections.Generic;

    [TestClass]
    public class CheckoutTest
    {
        [TestMethod]
        public void TestBasketWithNoQualifyingDiscountProduct()
        {
            // arrange
            decimal expectedValue = 3.29M;

            var products = new List<string>();
            products.Add("A99");
            products.Add("C40");
            products.Add("T23");

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

            var products = new List<string>();
            products.Add("A99");
            products.Add("A99");
            products.Add("A99");
            products.Add("C40");
            products.Add("T23");

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

            var products = new List<string>();
            products.Add("A99");
            products.Add("A99");
            products.Add("A99");
            products.Add("B15");
            products.Add("B15");

            var engine = new CheckoutEngine();

            // act
            var checkoutEngine = new CheckoutEngine();
            var result = checkoutEngine.CalculateBasket(products);

            // assert
            Assert.AreEqual(expectedValue, result);

        }

        [TestMethod]
        public void TestBasketWithUnknownProduct()
        {
            // arrange
            decimal expectedValue = decimal.MinValue;

            var products = new List<string>();
            products.Add("A88");

            var engine = new CheckoutEngine();

            // act
            var checkoutEngine = new CheckoutEngine();
            var result = checkoutEngine.CalculateBasket(products);

            // assert
            Assert.AreEqual(expectedValue, result);
        }

        [TestMethod]
        public void TestNullProductList()
        {
            // arrange
            var expectedError = "Products cannot be null or empty.";

            try
            {
                // act
                var checkoutEngine = new CheckoutEngine();
                var result = checkoutEngine.CalculateBasket(null);
            }
            catch (ArgumentException ex)
            {
                // assert
                Assert.AreEqual(expectedError, ex.ParamName);
            }
        }

        [TestMethod]
        public void TestEmptyProductList()
        {
            // arrange
            var expectedError = "Products cannot be null or empty.";

            try
            {
                // act
                var checkoutEngine = new CheckoutEngine();
                var products = new List<string>();
                var result = checkoutEngine.CalculateBasket(products);
            }
            catch (ArgumentException ex)
            {
                // assert
                Assert.AreEqual(expectedError, ex.ParamName);
            }
        }
    }
}
