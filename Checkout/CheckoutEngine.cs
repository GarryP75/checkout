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

            var basketTotal = 0.00M;
            var availableProducts = from p in GetAvailableProducts()
                                    where products.Contains(p.Sku)
                                    select p;

            if (availableProducts.Any())
            {
                var totalProductsPurchased = 0;
                var purchasedProducts = new List<Product>();

                foreach (var avProd in availableProducts)
                {
                    totalProductsPurchased = products.Count(p => p == avProd.Sku);
                    for(var i=0; i< totalProductsPurchased; i++)
                    {
                        purchasedProducts.Add(avProd);
                    }
                    basketTotal += avProd.Price * totalProductsPurchased;
                }
                
                basketTotal -= ApplyProductDiscount(purchasedProducts);
            }

            return basketTotal;
        }

        public bool SaveBasket(List<string> products)
        {
            // Database code here !! call unit of work/ repo etc
            throw new NotImplementedException();
        }

        private decimal ApplyProductDiscount(List<Product> products)
        {
            var discount = 0.00M;
            var discountProducts = GetProductDiscounts().Where(p => products.Any(p2 => p2.Id == p.ProductId));

            if (discountProducts.Any())
            {
                foreach (var discProd in discountProducts)
                {
                    switch (discProd.Type)
                    {
                        case DiscountType.Quantity:
                            discount += CalcProductDiscount(
                                                    products.Where(p => p.Id == discProd.ProductId).Count(),
                                                    discProd.DiscountAmount,
                                                    discProd.Quantity);
                            break;
                    }
                }
            }
            return discount;
        }

        private decimal CalcProductDiscount(int purchaseQty, decimal discountPrice, int discountQty)
        {
            var totalProductDiscount = 0.00M;
            if(purchaseQty >= discountQty)
            {
                if (purchaseQty > 1)
                {
                    var qualifyingProductPurchase = purchaseQty / discountQty;
                    var totalQualifyingProductPurchase = Math.Round((decimal)qualifyingProductPurchase, 1);
                    totalProductDiscount = totalQualifyingProductPurchase * discountPrice;
                }
                else
                {
                    totalProductDiscount = discountPrice;
                }
            }

            return totalProductDiscount;
        }

        // Hardcoded data for now, will come from database:
        private List<Product> GetAvailableProducts() => new List<Product> {
            new Product { Id = 1, Sku = "A99", Description = "Apple", Price = 0.50M },
            new Product { Id = 2, Sku = "B15", Description = "Biscuits", Price = 0.30M },
            new Product { Id = 3, Sku = "C40", Description = "Coffee", Price = 1.80M },
            new Product { Id = 4, Sku = "T23", Description = "Tissues", Price = 0.99M }};

        // Hardcoded data for now, will come from database:
        private List<ProductDiscount> GetProductDiscounts() => new List<ProductDiscount>{
            new ProductDiscount { Id=1, ProductId=1, Description="3 for 1.30", Quantity =3, DiscountAmount = 0.20M, Type = DiscountType.Quantity},
            new ProductDiscount { Id=2, ProductId=2, Description="2 for 0.45", Quantity =2, DiscountAmount = 0.15M, Type = DiscountType.Quantity}};
    }
}