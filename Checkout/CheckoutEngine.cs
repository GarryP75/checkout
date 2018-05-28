namespace Checkout
{
    using System;
    using System.Collections.Generic;
    using Checkout.Models;
    using System.Linq;

    public class CheckoutEngine : ICheckoutEngine
    {
        public decimal CalculateBasket(List<string> products)
        {
            if (products == null || products.Count == 0)
            {
                throw new ArgumentNullException("Products cannot be null or empty.");
            }

            var basketTotal = decimal.MinValue;

            var availableProducts = from p in GetAvailableProducts()
                        where products.Contains(p.Sku)
                        select p;

            if (availableProducts.Any())
            {
                basketTotal = availableProducts.Sum(d => d.Price);
            }
            
            return basketTotal;
        }

        public bool SaveBasket(List<string> products)
        {
            // Database code here !! call unit of work/ repo etc
            throw new System.NotImplementedException();
        }

        private decimal ApplyProductDiscount(Product product)
        {
            throw new NotImplementedException();
        }

        // Hardcoded data for now, will come from database:
        private List<Product> GetAvailableProducts() => new List<Product> {
            new Product { Id = 1, Sku = "A99", Description = "Apple", Price = 0.50M },
            new Product { Id = 2, Sku = "B15", Description = "Biscuits", Price = 0.30M },
            new Product { Id = 3, Sku = "C40", Description = "Coffee", Price = 1.80M },
            new Product { Id = 1, Sku = "T23", Description = "Tissues", Price = 0.99M }};

        // Hardcoded data for now, will come from database:
        private List<ProductDiscount> GetProductDiscounts() => new List<ProductDiscount>{
            new ProductDiscount { Id=1, ProductId=1, Description="3 for 1.30", Quantity =3, DiscountAmount = 0.20M, Type = DiscountType.Quantity},
            new ProductDiscount { Id=2, ProductId=2, Description="2 for 0.45", Quantity =2, DiscountAmount = 0.15M, Type = DiscountType.Quantity}};
    }
}