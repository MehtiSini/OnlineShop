﻿using Blog.Domain.Tools;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Nancy.Json;
using ShopManagement.Contracts.Orders;
using ShopManagement.Query.Contracts.Product;

namespace ServiceHost.Pages
{
    public class CartModel : PageModel
    {
        public const string CookieName = "Cart-items";
        public List<CartItem>? CartItems;

        private readonly IProductQuery _productQuery;

        public CartModel(IProductQuery productQuery)
        {
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

            CartItems = _productQuery.CheckInventoryStatus(cartItems);

        }

        public IActionResult OnGetRemoveFromCart(long id)
        {
            var serializer = new JavaScriptSerializer();
            var value = Request.Cookies[CookieName];
            Response.Cookies.Delete(CookieName);
            var cartItems = serializer.Deserialize<List<CartItem>>(value);
            var itemToRemove = cartItems.FirstOrDefault(x => x.Id == id);
            cartItems.Remove(itemToRemove);
            var options = new CookieOptions { Expires = DateTime.Now.AddDays(2) };
            Response.Cookies.Append(CookieName, serializer.Serialize(cartItems), options);
            return RedirectToPage("/Cart");
        }


        public IActionResult OnGetGoToCheckOut()
        {
            var serializer = new JavaScriptSerializer();
            var value = Request.Cookies[CookieName];
            var cartItems = serializer.Deserialize<List<CartItem>>(value);
            foreach (var item in cartItems)
            {
                item.TotalPrice = item.UnitPrice * item.Count;
            }

            CartItems = _productQuery.CheckInventoryStatus(cartItems);

            //if (CartItems.Any(x => !x.IsInStock))
            //    return RedirectToPage("/Cart");
            //return RedirectToPage("/Checkout");

            return RedirectToPage(CartItems.Any(x => !x.IsInStock) ? "/Cart" : "/Checkout");
        }

    }
}
