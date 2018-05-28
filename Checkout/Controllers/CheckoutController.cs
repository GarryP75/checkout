namespace Checkout.Controllers
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using System.Web.Http;

    public class CheckoutController : ApiController
    {
        public async Task<decimal> CalculateBasket(List<string> products)
        {
            var checkoutEngine = new CheckoutEngine();
            return await Task.FromResult(checkoutEngine.CalculateBasket(products));
        }
    }
}