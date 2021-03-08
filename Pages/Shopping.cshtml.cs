using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookList.Infrastructure;
using BookList.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookList.Pages
{
    public class ShoppingModel : PageModel
    {
        private IBookListRepository repository;


        //Constructor
        public ShoppingModel (IBookListRepository repo)
        {
            repository = repo;
        }


        //Properties
        public Cart Cart { get; set; }
        public string ReturnUrl { get; set; }


        //Methods 
        public void OnGet(string returnUrl)
        {
            ReturnUrl = returnUrl ?? "/";
            Cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();
        }

        public IActionResult OnPost(long bookId, string returnUrl)
        {
            BLP bLP = repository.BLPs
                .FirstOrDefault(p => p.BookId == bookId);

            Cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();

            Cart.AddItem(bLP, 1);

            HttpContext.Session.SetJson("cart", Cart);

            return RedirectToPage(new { returnUrl = returnUrl });
        }

        public IActionResult OnPostRemove(long bookId, string returnUrl)
        {
            BLP bLP = repository.BLPs
                .FirstOrDefault(p => p.BookId == bookId);

            Cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();

            Cart.RemoveLine(Cart.Lines.First(c =>
            c.Project.BookId == bookId).Project);

            HttpContext.Session.SetJson("cart", Cart);
  
            return RedirectToPage(new { returnUrl = returnUrl });
        }
    }
}
