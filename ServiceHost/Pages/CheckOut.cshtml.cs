using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Nancy.Json;
using ShopManagement.Application.Contracts.Orders;
using ShopManagement.Contracts.Orders;
using ShopManagement.Query.Contracts.Cart;
using ShopManagement.Query.Contracts.Product;

namespace ServiceHost.Pages
{
    public class CheckOutModel : PageModel
    {
        public const string CookieName = "Cart-items";
        public CartDetail? Cart { get; set; }

        private readonly ICartService _cartService;
        private readonly ICartCalculator _cartCalculator;
        private readonly IProductQuery _productQuery;

        public CheckOutModel(ICartCalculator cartCalculator, ICartService cartService, IProductQuery productQuery)
        {
            this._cartCalculator = cartCalculator;
            Cart = new CartDetail();
            _cartService = cartService;
            _productQuery = productQuery;
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
            _cartService.Set(Cart);
        }

        public IActionResult OnGetPay()
        {
            var cart = _cartService.Get();

            var Result = _productQuery.CheckInventoryStatus(cart.CartItems);

            if (Result.Any(x => !x.IsInStock))
            {
                return RedirectToPage("/Cart");
            }

            return RedirectToPage("/Checkout");
        }

    }
}
