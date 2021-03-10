using Microsoft.AspNetCore.Mvc;
using BookList.Models;


// using cartService component to store the cart info and display in the razor page by return the view with the cart parameter
namespace BookList.Components
{
    public class CartSummaryViewComponent : ViewComponent
    {
        private Cart cart;
        public CartSummaryViewComponent(Cart cartService)
        {
            cart = cartService;
        }
        public IViewComponentResult Invoke()
        {
            return View(cart);
        }
    }
}

