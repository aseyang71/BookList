using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookList.Models;

namespace BookList.Components
{
    public class NavigationMenuViewComponents : ViewComponent
    {
        private IBookListRepository repository;

        //Build the partial viewused by the View Component to dynamicallydisplay the list of categories
        public NavigationMenuViewComponents (IBookListRepository r)
        {
            repository = r;
        }

        // •Insert the category menu using the View Component method 
        // I use the Category1 property to divide books into different categories following the Professor's videos 
        public IViewComponentResult Invoke()
        {
            // The url value is the same as the category string value 
            ViewBag.SelectedType = RouteData?.Values["category"];

            // Filter the results by "category1"
            return View(repository.BLPs
                .Select(x => x.Category1)
                // using Distinct() to avoid creating duplicate categories
                .Distinct()
                .OrderBy(x => x));
                
        }
    }
}
