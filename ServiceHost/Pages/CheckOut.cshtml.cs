using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyFramework.Tools;
using MyFramework.Tools.Authentication;
using Nancy.Json;
using ShopManagement.Application.Contracts.Orders;
using ShopManagement.Contracts.Orders;
using ShopManagement.Query.Contracts.Cart;
using ShopManagement.Query.Contracts.Product;

namespace ServiceHost.Pages
{
    [Authorize]
    public class CheckOutModel : PageModel
    {
        public const string CookieName = "Cart-items";
        public CartDetail? Cart { get; set; }

        private readonly ICartService _cartService;
        private readonly ICartCalculator _cartCalculator;
        private readonly IProductQuery _productQuery;
        private readonly IZarinPalFactory _zarinPalFactory;
        private readonly IOrderApplication _orderApplication;

        public CheckOutModel(ICartCalculator cartCalculator, ICartService cartService, IProductQuery productQuery, IZarinPalFactory zarinPalFactory, IOrderApplication orderApplication)
        {
            Cart = new CartDetail();
            _cartCalculator = cartCalculator;
            _cartService = cartService;
            _productQuery = productQuery;
            _zarinPalFactory = zarinPalFactory;
            _orderApplication = orderApplication;
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

        public IActionResult OnPostPayThePrice(int paymentMethod)
        {
            var cart = _cartService.Get();

            cart.SetPaymentMethod(paymentMethod);

            var Result = _productQuery.CheckInventoryStatus(cart.CartItems);

            var PayResult = new PaymentResultOperation();

            if (Result.Any(x => !x.IsInStock))
            {
                return RedirectToPage("/Cart");
            }

            var OrderId = _orderApplication.PlaceOrder(cart);

            if (paymentMethod == PaymentMethodOperation.Online)
            {
                var PaymentRequest = _zarinPalFactory.CreatePaymentRequest(cart.PayAmount.ToString(), "", "",
                "خرید از درگاه لوازم خانگی و دکوری", OrderId);

                return RedirectToPage($"https://{_zarinPalFactory.Prefix}.zarinpal.com/pg/rest/WebGate/{PaymentRequest.Authority}");
            }

            _orderApplication.PaymentSucceeded(OrderId,0);

            return RedirectToPage("/PaymentResult",PayResult.Succeeded("پرداخت شما به صورت نقدی میباشد " , null));
        }

        public IActionResult OnGetCallBack([FromQuery] string authority, [FromQuery] string status, long OrderId)
        {
            var PayAmount = _orderApplication.GetAmountBy(OrderId);

            var verificationResponse = _zarinPalFactory.CreateVerificationRequest(authority, PayAmount.ToMoney());

            var Result = new PaymentResultOperation();

            if (status == "OK" && verificationResponse.Status == 100)
            {
               var IssueTrackingNo =  _orderApplication.PaymentSucceeded(OrderId,verificationResponse.RefID);
                Response.Cookies.Delete("cart-items");
                return RedirectToPage("/PaymentResult" , Result.Succeeded("پرداخت شما با موفقیت انجام شد", IssueTrackingNo));
            }
            else
            {
                return RedirectToPage("/PaymentResult", Result.Failed("پرداخت شما با موفقیت انجام نشد ، در صورت کسر وجه مبلغ تا 24 ساعت دیگر به حسابتان بازگردانده خواهد شد"));
            }
        }
    }
}
