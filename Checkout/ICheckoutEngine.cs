namespace Checkout
{
    using Models;
    using System.Collections.Generic;

    public interface ICheckoutEngine
    {
        decimal CalculateBasket(List<Product> products);
        bool SaveBasket(List<Product> products);
    }
}
