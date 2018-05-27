namespace Checkout
{
    using System.Collections.Generic;
    using Checkout.Models;

    public class CheckoutEngine : ICheckoutEngine
    {
        public decimal CalculateBasket(List<Product> products)
        {
            throw new System.NotImplementedException();
        }

        public bool SaveBasket(List<Product> products)
        {
            // Database code here !! call unit of work/ repo etc
            throw new System.NotImplementedException();
        }

        private decimal ApplyProductDiscount(Product product)
        {
            throw new System.NotImplementedException();
        }
    }
}