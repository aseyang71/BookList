using BookList.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using BookList.Models.ViewModels;

namespace BookList.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        // Set PageSize to 5 so that each page only displays up to 5 items 
        private IBookListRepository _repository;
        public int PageSize = 5; 

        public HomeController(ILogger<HomeController> logger, IBookListRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        public IActionResult Index(string category, int pageNum = 1)
        {
            return View
            (new ProjectListViewModel
            {
/*                Added the ability to filter by category in the Controller
*/                BLPs = _repository.BLPs
                        .Where(b => category == null || b.Category1 == category)
                        .OrderBy(b => b.BookId)
                        .Skip((pageNum - 1) * PageSize)
                        .Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = pageNum,
                    ItemsPerPage = PageSize,

                    //Fix the page numbering to match the number ofitems by category

                    // When there's no category selected, we use  the total number of page counts to be displayed on the website
                    TotalNumItems = category == null ? _repository.BLPs.Count() :

                    // Otherwise, we re-calculate the total number of pages for the selected category and display it
                    _repository.BLPs.Where(x => x.Category1 == category).Count()

                },

                CurCat = category
            }
            ) ;
        }

            public IActionResult Video()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public ViewResult Summary(Cart cart)

        { 
            return View(cart);
        }
    }
}
