namespace Checkout
{
    using Models;
    using System.Collections.Generic;

    interface ICheckoutEngine
    {
        decimal CalculateBasket(List<Product> products);
        bool SaveBasket(List<Product> products);
    }
}
