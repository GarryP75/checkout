namespace Checkout
{
    using Models;
    using System.Collections.Generic;

    public interface ICheckoutEngine
    {
        decimal CalculateBasket(List<string> products);
        bool SaveBasket(List<string> products);
    }
}
