using Microsoft.AspNetCore.Mvc.RazorPages;
using Nancy.Json;
using ShopManagement.Contracts.Orders;
using ShopManagement.Query.Contracts.Cart;

namespace ServiceHost.Pages
{
    public class CheckOutModel : PageModel
    {
        public const string CookieName = "Cart-items";
        public CartDetail? Cart { get; set; }

        private readonly ICartCalculator _cartCalculator;

        public CheckOutModel(ICartCalculator cartCalculator)
        {
            this._cartCalculator = cartCalculator;
            Cart = new CartDetail();
        }

        public void OnGet()
        {
            var Serializer = new JavaScriptSerializer();
            var value = Request.Cookies[CookieName];
            var cartItems = Serializer.Deserialize<List<CartItem>>(value);

            foreach (var item in cartItems)
            {
                item.CalculateTotalPrice();
            }

            Cart = _cartCalculator.ComputeCart(cartItems);

        }
    }
}
